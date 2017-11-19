using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.Serialization;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace Microsoft.Extensions.DependencyInjection.Performance
{
  public delegate object EmptyCtorDelegate();

  public delegate TReturn MethodCaller<TTarget, TReturn>(TTarget target, object[] args);
  public delegate T CtorInvoker<T>(object[] parameters);

  public static class ReflectUtils
  {

    #region - CreateInstance -

    /// <summary>Creates a new instance from the default constructor of type</summary>
    public static object CreateInstance(this Type type)
    {
      if (type == null) { return null; }

      var ctorFn = GetConstructorMethod(type);
      return ctorFn();
    }

    /// <summary>Creates a new instance from the default constructor of type</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <returns></returns>
    public static T CreateInstance<T>(this Type type)
    {
      if (type == null) { return default(T); }

      var ctorFn = GetConstructorMethod(type);
      return (T)ctorFn();
    }

    #endregion

    #region - GetConstructorMethod -

    private static Dictionary<Type, EmptyCtorDelegate> s_constructorMethods = new Dictionary<Type, EmptyCtorDelegate>();
    /// <summary>GetConstructorMethod</summary>
    /// <remarks>Code taken from ServiceStack.Text Library &lt;a href="https://github.com/ServiceStack/ServiceStack.Text"&gt;</remarks>
    /// <param name="type"></param>
    /// <returns></returns>
    public static EmptyCtorDelegate GetConstructorMethod(Type type)
    {
      if (s_constructorMethods.TryGetValue(type, out EmptyCtorDelegate emptyCtorFn)) return emptyCtorFn;

      emptyCtorFn = GetConstructorMethodToCache(type);

      Dictionary<Type, EmptyCtorDelegate> snapshot, newCache;
      do
      {
        snapshot = s_constructorMethods;
        newCache = new Dictionary<Type, EmptyCtorDelegate>(s_constructorMethods)
        {
          [type] = emptyCtorFn
        };
      } while (!ReferenceEquals(
          Interlocked.CompareExchange(ref s_constructorMethods, newCache, snapshot), snapshot));

      return emptyCtorFn;
    }


    #endregion

    #region - GetConstructorMethodToCache -

    /// <summary>GetConstructorMethodToCache</summary>
    /// <remarks>Code taken from ServiceStack.Text Library &lt;a href="https://github.com/ServiceStack/ServiceStack.Text"&gt;</remarks>
    /// <param name="type"></param>
    /// <returns></returns>
    public static EmptyCtorDelegate GetConstructorMethodToCache(Type type)
    {
      if (type == typeof(string))
      {
        return () => string.Empty;
      }
      else if (type.IsInterface)
      {
        if (type.HasGenericType())
        {
          var genericType = type.GetTypeWithGenericTypeDefinitionOfAny(typeof(IDictionary<,>));

          if (genericType != null)
          {
            var keyType = genericType.GenericTypeArguments[0];
            var valueType = genericType.GenericTypeArguments[1];
            return GetConstructorMethodToCache(typeof(Dictionary<,>).MakeGenericType(keyType, valueType));
          }

          genericType = type.GetTypeWithGenericTypeDefinitionOfAny(
              typeof(IEnumerable<>),
              typeof(ICollection<>),
              typeof(IList<>));

          if (genericType != null)
          {
            var elementType = genericType.GenericTypeArguments[0];
            return GetConstructorMethodToCache(typeof(List<>).MakeGenericType(elementType));
          }
        }
      }
      else if (type.IsArray)
      {
        return () => Array.CreateInstance(type.GetElementType(), 0);
      }
      else if (type.IsGenericTypeDefinition)
      {
        var genericArgs = type.GetGenericArguments();
        var typeArgs = new Type[genericArgs.Length];
        for (var i = 0; i < genericArgs.Length; i++)
          typeArgs[i] = typeof(object);

        var realizedType = type.MakeGenericType(typeArgs);

        return realizedType.CreateInstance;
      }

      var emptyCtor = type.GetConstructor(Type.EmptyTypes);
      if (emptyCtor != null)
      {
        var dm = new System.Reflection.Emit.DynamicMethod("MyCtor", type, Type.EmptyTypes, typeof(ReflectUtils).Module, true);
        var ilgen = dm.GetILGenerator();
        ilgen.Emit(System.Reflection.Emit.OpCodes.Nop);
        ilgen.Emit(System.Reflection.Emit.OpCodes.Newobj, emptyCtor);
        ilgen.Emit(System.Reflection.Emit.OpCodes.Ret);

        return (EmptyCtorDelegate)dm.CreateDelegate(typeof(EmptyCtorDelegate));
      }

      //Anonymous types don't have empty constructors
      return () => FormatterServices.GetUninitializedObject(type);
      // return FormatterServices.GetSafeUninitializedObject(Type);
    }

    #endregion

    public static bool HasGenericType(this Type type)
    {
      while (type != null)
      {
        if (type.IsGenericType)
          return true;

        type = type.BaseType;
      }
      return false;
    }
    public static Type GetTypeWithGenericTypeDefinitionOfAny(this Type type, params Type[] genericTypeDefinitions)
    {
      foreach (var genericTypeDefinition in genericTypeDefinitions)
      {
        var genericType = type.GetTypeWithGenericTypeDefinitionOf(genericTypeDefinition);
        if (genericType == null && type == genericTypeDefinition)
        {
          genericType = type;
        }

        if (genericType != null)
          return genericType;
      }
      return null;
    }

    public static Type GetTypeWithGenericTypeDefinitionOf(this Type type, Type genericTypeDefinition)
    {
      foreach (var t in type.GetInterfaces())
      {
        if (t.IsGenericType && t.GetGenericTypeDefinition() == genericTypeDefinition)
        {
          return t;
        }
      }

      var genericType = type.FirstGenericType();
      if (genericType != null && genericType.GetGenericTypeDefinition() == genericTypeDefinition)
      {
        return genericType;
      }

      return null;
    }

    public static Type FirstGenericType(this Type type)
    {
      while (type != null)
      {
        if (type.IsGenericType)
          return type;

        type = type.BaseType;
      }
      return null;
    }
    #region - MakeDelegateForCtor / MakeDelegateForCall -

    private const string kCtorInvokerName = "CI<>";
    private const string kMethodCallerName = "MC<>";

    private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<int, Delegate>> s_ctorInvokerCache =
        new ConcurrentDictionary<Type, ConcurrentDictionary<int, Delegate>>();

    /// <summary>Generates or gets a strongly-typed open-instance delegate to the specified type constructor that takes the specified type params.</summary>
    public static CtorInvoker<T> MakeDelegateForCtor<T>(this Type type, params Type[] paramTypes)
    {
      int key = kCtorInvokerName.GetHashCode() ^ type.GetHashCode();
      for (int i = 0; i < paramTypes.Length; i++)
      {
        key ^= paramTypes[i].GetHashCode();
      }

      var cache = s_ctorInvokerCache.GetOrAdd(type, k => new ConcurrentDictionary<int, Delegate>());
      var result = cache.GetOrAdd(key, k =>
      {
        var dynMethod = new DynamicMethod(kCtorInvokerName,
          MethodAttributes.Static | MethodAttributes.Public,
          CallingConventions.Standard,
          typeof(T), new Type[] { typeof(object[]) }, type, true);

        var il = dynMethod.GetILGenerator();
        GenCtor<T>(type, il, paramTypes);

        return dynMethod.CreateDelegate(typeof(CtorInvoker<T>));
      });
      return (CtorInvoker<T>)result;
    }

    /// <summary>Generates or gets a weakly-typed open-instance delegate to the specified type constructor that takes the specified type params.</summary>
    public static CtorInvoker<object> MakeDelegateForCtor(this Type type, params Type[] ctorParamTypes)
        => MakeDelegateForCtor<object>(type, ctorParamTypes);


    /// <summary>Generates a strongly-typed open-instance delegate to invoke the specified method</summary>
    public static MethodCaller<TTarget, TReturn> MakeDelegateForCall<TTarget, TReturn>(this MethodInfo method)
    {
      int key = GetKey<TTarget, TReturn>(method, kMethodCallerName);

      return GenDelegateForMember<MethodCaller<TTarget, TReturn>, MethodInfo>(
          method, kMethodCallerName, GenMethodInvocation<TTarget>,
          typeof(TReturn), typeof(TTarget), typeof(object[]));
    }

    /// <summary>Generates a weakly-typed open-instance delegate to invoke the specified method.</summary>
    public static MethodCaller<object, object> MakeDelegateForCall(this MethodInfo method)
        => MakeDelegateForCall<object, object>(method);

    /// <summary>Executes the delegate on the specified target and arguments but only if it's not null.</summary>
    public static void SafeInvoke<TTarget, TValue>(this MethodCaller<TTarget, TValue> caller, TTarget target, params object[] args)
    {
      caller?.Invoke(target, args);
    }

    static int GetKey<T, R>(MemberInfo member, string dynMethodName)
    {
      return member.GetHashCode() ^ dynMethodName.GetHashCode() ^ typeof(T).GetHashCode() ^ typeof(R).GetHashCode();
    }

    static TDelegate GenDelegateForMember<TDelegate, TMember>(TMember member, string dynMethodName,
      Action<TMember, ILGenerator> generator, Type returnType, params Type[] paramTypes)
      where TMember : MemberInfo where TDelegate : class
    {
      var dynMethod = new DynamicMethod(dynMethodName, returnType, paramTypes, true);

      var il = dynMethod.GetILGenerator();
      generator(member, il);

      var result = dynMethod.CreateDelegate(typeof(TDelegate));
      return (TDelegate)(object)result;
    }

    static void GenCtor<T>(Type type, ILGenerator il, Type[] paramTypes)
    {
      // arg0: object[] arguments
      // goal: return new T(arguments)
      Type targetType = typeof(T) == typeof(object) ? type : typeof(T);

      if (targetType.IsValueType && paramTypes.Length == 0)
      {
        var tmp = il.declocal(targetType);
        il.ldloca(tmp)
            .initobj(targetType)
            .ldloc(0);
      }
      else
      {
        var ctor = targetType.GetConstructor(paramTypes);
        if (ctor == null)
          throw new Exception("Generating constructor for type: " + targetType +
              (paramTypes.Length == 0 ? "No empty constructor found!" :
              "No constructor found that matches the following parameter types: " +
              string.Join(",", paramTypes.Select(x => x.Name).ToArray())));

        // push parameters in order to then call ctor
        for (int i = 0, imax = paramTypes.Length; i < imax; i++)
        {
          il.ldarg0()         // push args array
              .ldc_i4(i)          // push index
              .ldelem_ref()       // push array[index]
              .unbox_any(paramTypes[i]);  // cast
        }

        il.newobj(ctor);
      }

      if (typeof(T) == typeof(object) && targetType.IsValueType)
        il.box(targetType);

      il.ret();
    }

    static void GenMethodInvocation<TTarget>(MethodInfo method, ILGenerator il)
    {
      var weaklyTyped = typeof(TTarget) == typeof(object);

      // push target if not static (instance-method. in that case first arg is always 'this')
      if (!method.IsStatic)
      {
        var targetType = weaklyTyped ? method.DeclaringType : typeof(TTarget);
        il.declocal(targetType);
        il.ldarg0();
        if (weaklyTyped)
          il.unbox_any(targetType);
        il.stloc0()
            .ifclass_ldloc_else_ldloca(0, targetType);
      }

      // push arguments in order to call method
      var prams = method.GetParameters();
      for (int i = 0, imax = prams.Length; i < imax; i++)
      {
        il.ldarg1()   // push array
            .ldc_i4(i)    // push index
            .ldelem_ref();  // pop array, index and push array[index]

        var param = prams[i];
        var dataType = param.ParameterType;

        if (dataType.IsByRef)
          dataType = dataType.GetElementType();

        var tmp = il.declocal(dataType);
        il.unbox_any(dataType)
            .stloc(tmp)
            .ifbyref_ldloca_else_ldloc(tmp, param.ParameterType);
      }

      // perform the correct call (pushes the result)
      il.callorvirt(method);

      // if method wasn't static that means we declared a temp local to load the target
      // that means our local variables index for the arguments start from 1
      int localVarStart = method.IsStatic ? 0 : 1;
      for (int i = 0; i < prams.Length; i++)
      {
        var paramType = prams[i].ParameterType;
        if (paramType.IsByRef)
        {
          var byRefType = paramType.GetElementType();
          il.ldarg1()
              .ldc_i4(i)
              .ldloc(i + localVarStart);
          if (byRefType.IsValueType)
            il.box(byRefType);
          il.stelem_ref();
        }
      }

      if (method.ReturnType == typeof(void))
        il.ldnull();
      else if (weaklyTyped)
        il.ifvaluetype_box(method.ReturnType);

      il.ret();
    }

    #endregion
  }
}
