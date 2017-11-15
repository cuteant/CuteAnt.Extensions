#if NET40
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if !NET40
using System.Runtime.CompilerServices;
#endif

namespace System.Reflection
{
  #region --- class PlatformTypeHelper ---

  internal static class PlatformTypeHelper
  {
  }

  #endregion

  #region --- class BindingFlagsHelper ---

  /// <summary>BindingFlagsHelper</summary>
  internal static class BindingFlagsHelper
  {
    #region -- MS --

    /// <summary>MSRuntimeLookup - from ReferenceSource\mscorlib\system\type.cs</summary>
    internal const BindingFlags MSDefaultLookup = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

    /// <summary>MSRuntimeLookup - from ReferenceSource\mscorlib\system\type.cs</summary>
    internal const BindingFlags MSDeclaredOnlyLookup = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;

    /// <summary>MSRuntimeLookup - from ReferenceSource\mscorlib\system\reflection\RuntimeReflectionExtensions.cs</summary>
    internal const BindingFlags MSRuntimeLookup = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

    #endregion

    #region -- Static --

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Static</summary>
    internal const BindingFlags StaticDeclaredAndNonPublicOnlyLookup = BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Static;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags StaticDeclaredAndNonPublicOnlyLookupIC = BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static</summary>
    internal const BindingFlags StaticDeclaredAndPublicOnlyLookup = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags StaticDeclaredAndPublicOnlyLookupIC = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static</summary>
    internal const BindingFlags StaticDeclaredOnlyLookup = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags StaticDeclaredOnlyLookupIC = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase;


    /// <summary>BindingFlags.NonPublic | BindingFlags.Static</summary>
    internal const BindingFlags StaticNonPublicOnlyLookup = BindingFlags.NonPublic | BindingFlags.Static;

    /// <summary>BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags StaticNonPublicOnlyLookupIC = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.Public | BindingFlags.Static</summary>
    internal const BindingFlags StaticPublicOnlyLookup = BindingFlags.Public | BindingFlags.Static;

    /// <summary>BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags StaticPublicOnlyLookupIC = BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static</summary>
    internal const BindingFlags StaticLookup = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

    /// <summary>BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags StaticLookupIC = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase;


    /// <summary>BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static</summary>
    internal const BindingFlags StaticPublicOnlyLookupAll = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static;

    /// <summary>BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags StaticPublicOnlyLookupAllIC = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static</summary>
    internal const BindingFlags StaticLookupAll = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

    /// <summary>BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags StaticLookupAllIC = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase;

    #endregion

    #region -- Instance --

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance</summary>
    internal const BindingFlags InstanceDeclaredAndNonPublicOnlyLookup = BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags InstanceDeclaredAndNonPublicOnlyLookupIC = BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance</summary>
    internal const BindingFlags InstanceDeclaredAndPublicOnlyLookup = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags InstanceDeclaredAndPublicOnlyLookupIC = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance</summary>
    internal const BindingFlags InstanceDeclaredOnlyLookup = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags InstanceDeclaredOnlyLookupIC = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase;


    /// <summary>BindingFlags.NonPublic | BindingFlags.Instance</summary>
    internal const BindingFlags InstanceNonPublicOnlyLookup = BindingFlags.NonPublic | BindingFlags.Instance;

    /// <summary>BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags InstanceNonPublicOnlyLookupIC = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.Public | BindingFlags.Instance</summary>
    internal const BindingFlags InstancePublicOnlyLookup = BindingFlags.Public | BindingFlags.Instance;

    /// <summary>BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags InstancePublicOnlyLookupIC = BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance</summary>
    internal const BindingFlags InstanceLookup = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

    /// <summary>BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags InstanceLookupIC = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase;

    #endregion

    #region -- Default --

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static</summary>
    internal const BindingFlags DefaultDeclaredAndNonPublicOnlyLookup = BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags DefaultDeclaredAndNonPublicOnlyLookupIC = BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static</summary>
    internal const BindingFlags DefaultDeclaredAndPublicOnlyLookup = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags DefaultDeclaredAndPublicOnlyLookupIC = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static</summary>
    internal const BindingFlags DefaultDeclaredOnlyLookup = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

    /// <summary>BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags DefaultDeclaredOnlyLookupIC = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.IgnoreCase;


    /// <summary>BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance</summary>
    internal const BindingFlags DefaultNonPublicOnlyLookup = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

    /// <summary>BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags DefaultNonPublicOnlyLookupIC = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance</summary>
    internal const BindingFlags DefaultPublicOnlyLookup = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;

    /// <summary>BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags DefaultPublicOnlyLookupIC = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance</summary>
    internal const BindingFlags DefaultLookup = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

    /// <summary>BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags DefaultLookupIC = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase;


    /// <summary>BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance</summary>
    internal const BindingFlags DefaultPublicOnlyLookupAll = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;

    /// <summary>BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags DefaultPublicOnlyLookupAllIC = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase;

    /// <summary>BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance</summary>
    internal const BindingFlags DefaultLookupAll = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

    /// <summary>BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase</summary>
    internal const BindingFlags DefaultLookupAllIC = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase;

    #endregion
  }

  #endregion

  internal static class CaReflectionExtensions
  {
    #region -- Type --

    #region - IsConstructedGenericType -

#if NET40
    /// <summary>Wraps input type into <see cref="TypeInfo"/> structure.</summary>
    /// <param name="type">Input type.</param> <returns>Type info wrapper.</returns>
    public static TypeInfo GetTypeInfo(this Type type)
    {
      return new TypeInfo(type);
    }

    /// <summary>IsConstructedGenericType
    /// http://stackoverflow.com/questions/14476904/distinguish-between-generic-type-that-is-based-on-non-generic-value-type-and-oth
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public static bool IsConstructedGenericType(this Type t)
    {
      if (!t.IsGenericType || t.ContainsGenericParameters)
      {
        return false;
      }

      if (!t.GetGenericArguments().All(a => !a.IsGenericType || a.IsConstructedGenericType()))
      {
        return false;
      }

      return true;
    }
#endif

    #endregion

    #region - IsNull -

    /// <summary>IsNull.</summary>
    /// <param name="typeInfo">Input type.</param> <returns>Type info wrapper.</returns>
    public static bool IsNull(this TypeInfo typeInfo)
    {
#if NET40
      return null == typeInfo.AsType();
#else
      return null == typeInfo;
#endif
    }

    #endregion

    #region - IsNullableType -

    public static bool IsNullableType(this Type type)
    {
      return type.IsGenericType() && type.GetGenericTypeDefinition() == typeof(Nullable<>);
    }

    #endregion

    #region - IsInstanceOf -

    public static bool IsInstanceOf(this Type type, Type thisOrBaseType)
    {
      while (type != null)
      {
        if (type == thisOrBaseType)
          return true;

        type = type.BaseType();
      }
      return false;
    }

    #endregion

    #region - HasGenericType -

    public static bool HasGenericType(this Type type)
    {
      while (type != null)
      {
        if (type.IsGeneric())
          return true;

        type = type.BaseType();
      }
      return false;
    }

    #endregion

    #region - FirstGenericType -

    public static Type FirstGenericType(this Type type)
    {
      while (type != null)
      {
        if (type.IsGeneric())
          return type;

        type = type.BaseType();
      }
      return null;
    }

    #endregion

    #region - GetTypeWithGenericTypeDefinitionOfAny -

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

    #endregion

    #region - IsOrHasGenericInterfaceTypeOf -

    public static bool IsOrHasGenericInterfaceTypeOf(this Type type, Type genericTypeDefinition)
    {
      return (type.GetTypeWithGenericTypeDefinitionOf(genericTypeDefinition) != null)
          || (type == genericTypeDefinition);
    }

    #endregion

    #region - GetTypeWithGenericTypeDefinitionOf -

    public static Type GetTypeWithGenericTypeDefinitionOf(this Type type, Type genericTypeDefinition)
    {
      foreach (var t in type.GetTypeInterfaces())
      {
        if (t.IsGeneric() && t.GetGenericTypeDefinition() == genericTypeDefinition)
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

    #endregion

    #region - GetTypeWithInterfaceOf -

    public static Type GetTypeWithInterfaceOf(this Type type, Type interfaceType)
    {
      if (type == interfaceType) return interfaceType;

      foreach (var t in type.GetTypeInterfaces())
      {
        if (t == interfaceType)
          return t;
      }

      return null;
    }

    #endregion

    #region - HasInterface -

    public static bool HasInterface(this Type type, Type interfaceType)
    {
      foreach (var t in type.GetTypeInterfaces())
      {
        if (t == interfaceType)
          return true;
      }
      return false;
    }

    #endregion

    #region - AllHaveInterfacesOfType -

    public static bool AllHaveInterfacesOfType(this Type assignableFromType, params Type[] types)
    {
      foreach (var type in types)
      {
        if (assignableFromType.GetTypeWithInterfaceOf(type) == null) return false;
      }
      return true;
    }

    #endregion

    #region - GetUnderlyingTypeCode -

    public static TypeCode GetUnderlyingTypeCode(this Type type)
    {
      return Type.GetTypeCode(Nullable.GetUnderlyingType(type) ?? type);
    }

    #endregion

    #region - IsNumericType -

    public static bool IsNumericType(this Type type)
    {
      if (type == null) return false;

      //if (type.IsEnum()) //TypeCode can be TypeCode.Int32
      //{
      //  //return JsConfig.TreatEnumAsInteger || type.IsEnumFlags();
      //  return type.IsEnumFlags();
      //}

      switch (Type.GetTypeCode(type))
      {
        case TypeCode.Byte:
        case TypeCode.Decimal:
        case TypeCode.Double:
        case TypeCode.Int16:
        case TypeCode.Int32:
        case TypeCode.Int64:
        case TypeCode.SByte:
        case TypeCode.Single:
        case TypeCode.UInt16:
        case TypeCode.UInt32:
        case TypeCode.UInt64:
          return true;

        case TypeCode.Object:
          if (type.IsNullableType())
          {
            return IsNumericType(Nullable.GetUnderlyingType(type));
          }
          //if (type.IsEnum())
          //{
          //  //return JsConfig.TreatEnumAsInteger || type.IsEnumFlags();
          //  return type.IsEnumFlags();
          //}
          return false;
      }
      return false;
    }

    #endregion

    #region - IsIntegerType -

    public static bool IsIntegerType(this Type type)
    {
      if (type == null) return false;

      switch (Type.GetTypeCode(type))
      {
        case TypeCode.Byte:
        case TypeCode.Int16:
        case TypeCode.Int32:
        case TypeCode.Int64:
        case TypeCode.SByte:
        case TypeCode.UInt16:
        case TypeCode.UInt32:
        case TypeCode.UInt64:
          return true;

        case TypeCode.Object:
          if (type.IsNullableType())
          {
            return IsNumericType(Nullable.GetUnderlyingType(type));
          }
          return false;
      }
      return false;
    }

    #endregion

    #region - IsRealNumberType -

    public static bool IsRealNumberType(this Type type)
    {
      if (type == null) return false;

      switch (Type.GetTypeCode(type))
      {
        case TypeCode.Decimal:
        case TypeCode.Double:
        case TypeCode.Single:
          return true;

        case TypeCode.Object:
          if (type.IsNullableType())
          {
            return IsNumericType(Nullable.GetUnderlyingType(type));
          }
          return false;
      }
      return false;
    }

    #endregion

    #region - GetTypeWithGenericInterfaceOf -

    public static Type GetTypeWithGenericInterfaceOf(this Type type, Type genericInterfaceType)
    {
      foreach (var t in type.GetTypeInterfaces())
      {
        if (t.IsGeneric() && t.GetGenericTypeDefinition() == genericInterfaceType)
          return t;
      }

      if (!type.IsGeneric()) return null;

      var genericType = type.FirstGenericType();
      return genericType.GetGenericTypeDefinition() == genericInterfaceType
              ? genericType
              : null;
    }

    #endregion

    #region - GetAllProperties -

    //public static PropertyInfo[] GetAllProperties(this Type type)
    //{
    //  if (type.IsInterface())
    //  {
    //    var propertyInfos = new List<PropertyInfo>();

    //    var considered = new List<Type>();
    //    var queue = new Queue<Type>();
    //    considered.Add(type);
    //    queue.Enqueue(type);

    //    while (queue.Count > 0)
    //    {
    //      var subType = queue.Dequeue();
    //      foreach (var subInterface in subType.GetTypeInterfaces())
    //      {
    //        if (considered.Contains(subInterface)) continue;

    //        considered.Add(subInterface);
    //        queue.Enqueue(subInterface);
    //      }

    //      var typeProperties = subType.GetTypeProperties();

    //      var newPropertyInfos = typeProperties
    //          .Where(x => !propertyInfos.Contains(x));

    //      propertyInfos.InsertRange(0, newPropertyInfos);
    //    }

    //    return propertyInfos.ToArray();
    //  }

    //  return type.GetTypeProperties()
    //      .Where(t => t.GetIndexParameters().Length == 0) // ignore indexed properties
    //      .ToArray();
    //}

    #endregion

    #region - GetPublicProperties -

    //public static PropertyInfo[] GetPublicProperties(this Type type)
    //{
    //  if (type.IsInterface())
    //  {
    //    var propertyInfos = new List<PropertyInfo>();

    //    var considered = new List<Type>();
    //    var queue = new Queue<Type>();
    //    considered.Add(type);
    //    queue.Enqueue(type);

    //    while (queue.Count > 0)
    //    {
    //      var subType = queue.Dequeue();
    //      foreach (var subInterface in subType.GetTypeInterfaces())
    //      {
    //        if (considered.Contains(subInterface)) continue;

    //        considered.Add(subInterface);
    //        queue.Enqueue(subInterface);
    //      }

    //      var typeProperties = subType.GetTypePublicProperties();

    //      var newPropertyInfos = typeProperties
    //          .Where(x => !propertyInfos.Contains(x));

    //      propertyInfos.InsertRange(0, newPropertyInfos);
    //    }

    //    return propertyInfos.ToArray();
    //  }

    //  return type.GetTypePublicProperties()
    //      .Where(t => t.GetIndexParameters().Length == 0) // ignore indexed properties
    //      .ToArray();
    //}

    #endregion

    #endregion

    #region -- MemberInfo --

    /// <summary>获取包含该成员的自定义特性的集合。</summary>
    /// <param name="member"></param>
    /// <returns></returns>
#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static IEnumerable<CustomAttributeData> CustomAttributesEx(this MemberInfo member)
    {
#if !NET40
      return member.CustomAttributes;
#else
      return member.GetCustomAttributesData(); ;
#endif
    }

    #endregion

    #region -- MethodInfo --

#if NET40
    /// <summary>创建指定类型的委托从此方法的</summary>
    /// <param name="method">MethodInfo</param>
    /// <param name="delegateType">创建委托的类型</param>
    /// <returns></returns>
    public static Delegate CreateDelegate(this MethodInfo method, Type delegateType)
    {
      return Delegate.CreateDelegate(delegateType, method);
    }

    /// <summary>使用从此方法的指定目标创建指定类型的委托</summary>
    /// <param name="method">MethodInfo</param>
    /// <param name="delegateType">创建委托的类型</param>
    /// <param name="target">委托面向的对象</param>
    /// <returns></returns>
    public static Delegate CreateDelegate(this MethodInfo method, Type delegateType, Object target)
    {
      return Delegate.CreateDelegate(delegateType, target, method);
    }
#endif

    #endregion

    #region -- CustomAttributeData --

    /// <summary>获取属性的类型。</summary>
    /// <param name="attrdata"></param>
    /// <returns></returns>
#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Type AttributeTypeEx(this CustomAttributeData attrdata)
    {
#if !NET40
      return attrdata.AttributeType;
#else
      return attrdata.Constructor.DeclaringType; ;
#endif
    }

    #endregion

    #region -- PropertyInfo --

#if NET40
    /// <summary>返回指定对象的属性值</summary>
    /// <param name="property"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static Object GetValue(this PropertyInfo property, Object obj)
    {
      return property.GetValue(obj, null);
    }

    /// <summary>设置指定对象的属性值</summary>
    /// <param name="property"></param>
    /// <param name="obj"></param>
    /// <param name="value"></param>
    public static void SetValue(this PropertyInfo property, Object obj, Object value)
    {
      property.SetValue(obj, value, null);
    }
#endif

    /// <summary>获取此属性的 get 访问器。</summary>
    /// <param name="property"></param>
    /// <returns></returns>
#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static MethodInfo GetMethodEx(this PropertyInfo property)
    {
#if !NET40
      return property.GetMethod;
#else
      return property.GetGetMethod(true);
#endif
    }

    /// <summary>获取此属性的 set 访问器。</summary>
    /// <param name="property"></param>
    /// <returns></returns>
#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static MethodInfo SetMethodEx(this PropertyInfo property)
    {
#if !NET40
      return property.SetMethod;
#else
      return property.GetSetMethod(true); ;
#endif
    }

    #endregion

    #region -- ParameterInfo --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool HasDefaultValueEx(this ParameterInfo pi)
    {
#if NET40
      const string _DBNullType = "System.DBNull";
      return pi.DefaultValue == null || pi.DefaultValue.GetType().FullName != _DBNullType;
#else
      return pi.HasDefaultValue;
#endif
    }

    #endregion
  }

  internal static class CaPlatformExtensions
  {
    #region -- IsInterface --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool IsInterface(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().IsInterface;
#else
      return type.IsInterface;
#endif
    }

    #endregion

    #region -- IsArray --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool IsArray(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().IsArray;
#else
      return type.IsArray;
#endif
    }

    #endregion

    #region -- IsValueType --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool IsValueType(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().IsValueType;
#else
      return type.IsValueType;
#endif
    }

    #endregion

    #region -- IsPrimitive --

    public static bool IsPrimitive(this Type type)
    {
#if NETSTANDARD
      return type.GetTypeInfo().IsPrimitive;
#else
      return type.IsPrimitive;
#endif
    }

    #endregion

    #region -- IsGeneric --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool IsGeneric(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().IsGenericType;
#else
      return type.IsGenericType;
#endif
    }

    #endregion

    #region -- UnderlyingSystemType --

    public static Type UnderlyingSystemType(this Type type)
    {
#if NETSTANDARD
      return type.GetTypeInfo().AsType();
#else
      return type.UnderlyingSystemType;
#endif
    }

    #endregion

    #region -- BaseType --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Type BaseType(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().BaseType;
#else
      return type.BaseType;
#endif
    }

    #endregion

    #region -- GenericTypeDefinition --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Type GenericTypeDefinition(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().GetGenericTypeDefinition();
#else
      return type.GetGenericTypeDefinition();
#endif
    }

    #endregion

    #region -- GetTypeInterfaces --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Type[] GetTypeInterfaces(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().ImplementedInterfaces.ToArray();
#else
      return type.GetInterfaces();
#endif
    }

    #endregion

    #region -- GetTypeGenericArguments / GenericTypeArguments --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Type[] GetTypeGenericArguments(this Type type)
    {
#if NET40
      return type.IsGenericType && !type.IsGenericTypeDefinition ? type.GetGenericArguments() : Type.EmptyTypes;
#else
      return type.GetTypeInfo().GenericTypeArguments;
#endif
    }

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Type[] GenericTypeArguments(this Type type) => GetTypeGenericArguments(type);
    //    {
    //#if (NETFX_CORE || PCL || NETSTANDARD)
    //      return type.GenericTypeArguments;
    //#else
    //      return type.GetGenericArguments();
    //#endif
    //    }

    #endregion

    #region -- GetTypeGenericParameters --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Type[] GetTypeGenericParameters(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().GenericTypeParameters;
#else
      return type.IsGenericTypeDefinition ? type.GetGenericArguments() : Type.EmptyTypes;
#endif
    }

    #endregion

    #region -- GetEmptyConstructor --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static ConstructorInfo GetEmptyConstructor(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().DeclaredConstructors.FirstOrDefault(c => c.GetParameters().Count() == 0);
#else
      return type.GetConstructor(Type.EmptyTypes);
#endif
    }

    #endregion

    #region -- GetAllConstructors / DeclaredConstructors --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static IEnumerable<ConstructorInfo> GetAllConstructors(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().DeclaredConstructors;
#else
      return type.GetConstructors();
#endif
    }

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static ConstructorInfo[] DeclaredConstructors(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().DeclaredConstructors.ToArray();
#else
      return type.GetConstructors();
#endif
    }

    #endregion

    #region -- GetTypePublicProperties --

    //#if !NET40
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //#endif
    //    internal static PropertyInfo[] GetTypePublicProperties(this Type subType)
    //    {
    //#if (NETFX_CORE || PCL || NETSTANDARD)
    //      var pis = new List<PropertyInfo>();
    //      foreach (var pi in subType.GetRuntimeProperties())
    //      {
    //        var mi = pi.GetMethod ?? pi.SetMethod;
    //        if (mi != null && mi.IsStatic) continue;
    //        pis.Add(pi);
    //      }
    //      return pis.ToArray();
    //#else
    //      return subType.GetProperties(BindingFlagsHelper.InstancePublicOnlyLookup);
    //#endif
    //    }

    #endregion

    #region -- GetTypeProperties --

    //#if !NET40
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //#endif
    //    internal static PropertyInfo[] GetTypeProperties(this Type subType)
    //    {
    //#if (NETFX_CORE || PCL || NETSTANDARD)
    //      var pis = new List<PropertyInfo>();
    //      foreach (var pi in subType.GetRuntimeProperties())
    //      {
    //        var mi = pi.GetMethod ?? pi.SetMethod;
    //        if (mi != null && mi.IsStatic) continue;
    //        pis.Add(pi);
    //      }
    //      return pis.ToArray();
    //#else
    //      return subType.GetProperties(BindingFlagsHelper.InstanceLookup);
    //#endif
    //    }

    #endregion

    #region -- GetTypeAllProperties / Properties --

    //#if !NET40
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //#endif
    //    public static PropertyInfo[] GetTypeAllProperties(this Type type)
    //    {
    //#if (NETFX_CORE || PCL || NETSTANDARD)
    //      return type.GetRuntimeProperties().ToArray();
    //#else
    //      return type.GetProperties(BindingFlagsHelper.DefaultLookupAll);
    //#endif
    //    }

    #endregion

    #region -- GetAssembly --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Assembly GetAssembly(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().Assembly;
#else
      return type.Assembly;
#endif
    }

    #endregion

    #region -- GetMethod --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static MethodInfo GetMethod(this Type type, string methodName)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().GetDeclaredMethod(methodName);
#else
      return type.GetMethod(methodName);
#endif
    }

    #endregion

    #region -- GetTypeAllFields / GetAllFields / Fields --

    //#if !NET40
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //#endif
    //    public static FieldInfo[] GetTypeAllFields(this Type type)
    //    {
    //      if (type.IsInterface()) { return CuteAnt.EmptyArray<FieldInfo>.Instance; }

    //#if (NETFX_CORE || PCL || NETSTANDARD)
    //      return type.GetRuntimeFields().ToArray();
    //#else
    //      return type.GetFields(BindingFlagsHelper.DefaultLookupAll);
    //#endif
    //    }

    #endregion

    #region -- GetAllFields --

    //#if !NET40
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //#endif
    //    public static FieldInfo[] GetAllFields(this Type type)
    //    {
    //      if (type.IsInterface())
    //      {
    //        return CuteAnt.EmptyArray<FieldInfo>.Instance;
    //      }

    //#if (NETFX_CORE || PCL || NETSTANDARD)
    //      return type.GetRuntimeFields().ToArray();
    //#else
    //      return type.Fields();
    //#endif
    //    }

    #endregion

    #region -- GetTypeFields --

    //#if !NET40
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //#endif
    //    public static FieldInfo[] GetTypeFields(this Type type)
    //    {
    //      if (type.IsInterface()) { return CuteAnt.EmptyArray<FieldInfo>.Instance; }

    //#if (NETFX_CORE || PCL || NETSTANDARD)
    //      return type.GetRuntimeFields().Where(p => !p.IsStatic).ToArray();
    //#else
    //      return type.GetFields(BindingFlagsHelper.InstanceLookup);
    //#endif
    //    }

    #endregion

    #region -- GetTypePublicFields --

    //#if !NET40
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //#endif
    //    public static FieldInfo[] GetTypePublicFields(this Type type)
    //    {
    //      if (type.IsInterface()) { return CuteAnt.EmptyArray<FieldInfo>.Instance; }

    //#if (NETFX_CORE || PCL || NETSTANDARD)
    //      return type.GetRuntimeFields().Where(p => p.IsPublic && !p.IsStatic).ToArray();
    //#else
    //      return type.GetFields(BindingFlagsHelper.InstancePublicOnlyLookup);
    //#endif
    //    }

    #endregion

    #region -- GetPublicMembers --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static MemberInfo[] GetPublicMembers(this Type type)
    {

#if (NETFX_CORE || PCL || NETSTANDARD)
      var members = new List<MemberInfo>();
      members.AddRange(type.GetRuntimeFields().Where(p => p.IsPublic && !p.IsStatic));
      members.AddRange(type.GetPublicProperties());
      return members.ToArray();
#else
      return type.GetMembers(BindingFlagsHelper.InstancePublicOnlyLookup);
#endif
    }

    #endregion

    #region -- GetAllPublicMembers --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static MemberInfo[] GetAllPublicMembers(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      var members = new List<MemberInfo>();
      members.AddRange(type.GetRuntimeFields().Where(p => p.IsPublic && !p.IsStatic));
      members.AddRange(type.GetPublicProperties());
      return members.ToArray();
#else
      return type.GetMembers(BindingFlagsHelper.InstancePublicOnlyLookup);
#endif
    }

    #endregion

    #region -- GetStaticMethod --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static MethodInfo GetStaticMethod(this Type type, string methodName)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetMethodInfo(methodName);
#else
      return type.GetMethod(methodName, BindingFlagsHelper.StaticLookup);
#endif
    }

    #endregion

    #region -- GetInstanceMethod --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static MethodInfo GetInstanceMethod(this Type type, string methodName)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetMethodInfo(methodName);
#else
      return type.GetMethod(methodName, BindingFlagsHelper.InstanceLookup);
#endif
    }

    #endregion

    #region -- Method --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static MethodInfo Method(this Delegate fn)
    {
#if NETFX_CORE || PCL
      return fn.GetMethodInfo();
#else
      return fn.Method;
#endif
    }

    #endregion

    #region -- GetImplementedInterfaces --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static IEnumerable<Type> GetImplementedInterfaces(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().ImplementedInterfaces;
      //return type.GetTypeInfo().ImplementedInterfaces
      //    .FirstOrDefault(x => !x.GetTypeInfo().ImplementedInterfaces
      //        .Any(y => y.GetTypeInfo().ImplementedInterfaces.Contains(y)));
#else
      return type.GetInterfaces();
#endif
    }

    #endregion

    #region -- AllProperties --

    //#if !NET40
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //#endif
    //    public static PropertyInfo[] AllProperties(this Type type)
    //    {
    //#if (NETFX_CORE || PCL || NETSTANDARD)
    //      return type.GetRuntimeProperties().ToArray();
    //#else
    //      return type.GetProperties(BindingFlagsHelper.InstanceLookup);
    //#endif
    //    }

    #endregion

    #region -- IsDynamic--

    public static bool IsDynamic(this Assembly assembly)
    {
#if __IOS__ || WP || NETFX_CORE || PCL || NETSTANDARD
      return false;
#else
      try
      {
        var isDyanmic = assembly is System.Reflection.Emit.AssemblyBuilder
            || string.IsNullOrEmpty(assembly.Location);
        return isDyanmic;
      }
      catch (NotSupportedException)
      {
        //Ignore assembly.Location not supported in a dynamic assembly.
        return true;
      }
#endif
    }

    #endregion

    #region -- GetStaticMethod --

    public static MethodInfo GetStaticMethod(this Type type, string methodName, Type[] types = null)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      foreach (MethodInfo method in type.GetTypeInfo().DeclaredMethods)
      {
        if (method.IsStatic && method.Name == methodName)
        {
          return method;
        }
      }

      return null;
#else
      return types == null
          ? type.GetMethod(methodName, BindingFlagsHelper.StaticPublicOnlyLookup)
          : type.GetMethod(methodName, BindingFlagsHelper.StaticPublicOnlyLookup, null, types, null);
#endif
    }

    #endregion

    #region -- InvokeMethod --

    public static object InvokeMethod(this Delegate fn, object instance, object[] parameters = null)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return fn.GetMethodInfo().Invoke(instance, parameters ?? new object[] { });
#else
      return fn.Method.Invoke(instance, parameters ?? new object[] { });
#endif
    }

    #endregion

    #region -- GetPublicStaticField --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static FieldInfo GetPublicStaticField(this Type type, string fieldName)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetRuntimeField(fieldName);
#else
      return type.GetField(fieldName, BindingFlagsHelper.StaticPublicOnlyLookup);
#endif
    }

    #endregion

    #region -- MakeDelegate --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Delegate MakeDelegate(this MethodInfo mi, Type delegateType, bool throwOnBindFailure = true)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return mi.CreateDelegate(delegateType);
#else
      return Delegate.CreateDelegate(delegateType, mi, throwOnBindFailure);
#endif
    }

    #endregion

    #region -- AssignableFrom / IsAssignableFromType --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool AssignableFrom(this Type type, Type fromType)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().IsAssignableFrom(fromType.GetTypeInfo());
#else
      return type.IsAssignableFrom(fromType);
#endif
    }

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool IsAssignableFromType(this Type type, Type fromType)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().IsAssignableFrom(fromType.GetTypeInfo());
#else
      return type.IsAssignableFrom(fromType);
#endif
    }

    #endregion

    #region -- IsStandardClass --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool IsStandardClass(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      var typeInfo = type.GetTypeInfo();
      return typeInfo.IsClass && !typeInfo.IsAbstract && !typeInfo.IsInterface;
#else
      return type.IsClass && !type.IsAbstract && !type.IsInterface;
#endif
    }

    #endregion

    #region -- IsAbstract --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool IsAbstract(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().IsAbstract;
#else
      return type.IsAbstract;
#endif
    }

    #endregion

    #region -- GetPropertyInfo --

    //#if !NET40
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //#endif
    //    public static PropertyInfo GetPropertyInfo(this Type type, string propertyName)
    //    {
    //#if (NETFX_CORE || PCL || NETSTANDARD)
    //      return type.GetRuntimeProperty(propertyName);
    //#else
    //      return type.GetProperty(propertyName);
    //#endif
    //    }

    #endregion

    #region -- GetFieldInfo --

    //#if !NET40
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //#endif
    //    public static FieldInfo GetFieldInfo(this Type type, string fieldName)
    //    {
    //#if (NETFX_CORE || PCL || NETSTANDARD)
    //      return type.GetRuntimeField(fieldName);
    //#else
    //      return type.GetField(fieldName);
    //#endif
    //    }

    #endregion

    #region -- GetWritableFields --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static FieldInfo[] GetWritableFields(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetRuntimeFields().Where(p => !p.IsPublic && !p.IsStatic).ToArray();
#else
      return type.GetFields(BindingFlagsHelper.InstanceNonPublicOnlyLookup | BindingFlags.SetField);
#endif
    }

    #endregion

    #region -- SetMethodInfo / PropertySetMethod --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static MethodInfo PropertySetMethod(this PropertyInfo pi, bool nonPublic = true)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return pi.SetMethod;
#else
      return pi.GetSetMethod(nonPublic);
#endif
    }

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static MethodInfo SetMethodInfo(this PropertyInfo pi, bool nonPublic = true)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return pi.SetMethod;
#else
      return pi.GetSetMethod(nonPublic);
#endif
    }

    #endregion

    #region -- GetMethodInfo / PropertyGetMethod --

    public static MethodInfo GetMethodInfo(this Type type, string methodName, Type[] types = null)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetRuntimeMethods().FirstOrDefault(p => p.Name.Equals(methodName));
#else
      return types == null
          ? type.GetMethod(methodName)
          : type.GetMethod(methodName, types);
#endif
    }

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static MethodInfo GetMethodInfo(this PropertyInfo pi, bool nonPublic = true)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return pi.GetMethod;
#else
      return pi.GetGetMethod(nonPublic);
#endif
    }

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static MethodInfo PropertyGetMethod(this PropertyInfo pi, bool nonPublic = false)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      var mi = pi.GetMethod;
      return mi != null && (nonPublic || mi.IsPublic) ? mi : null;
#else
      return pi.GetGetMethod(nonPublic);
#endif
    }

    #endregion

    #region -- InstanceOfType --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool InstanceOfType(this Type type, object instance)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return instance.GetType().IsInstanceOf(type);
#else
      return type.IsInstanceOfType(instance);
#endif
    }

    #endregion

    #region -- IsClass --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool IsClass(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().IsClass;
#else
      return type.IsClass;
#endif
    }

    #endregion

    #region -- IsEnum --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool IsEnum(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().IsEnum;
#else
      return type.IsEnum;
#endif
    }

    #endregion

    #region -- IsEnumFlags --

//#if !NET40
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//#endif
//    public static bool IsEnumFlags(this Type type)
//    {
//#if (NETFX_CORE || PCL || NETSTANDARD)
//      return type.GetTypeInfo().IsEnum && type.FirstAttribute<FlagsAttribute>() != null;
//#else
//      return type.IsEnum && type.FirstAttribute<FlagsAttribute>() != null;
//#endif
//    }

    #endregion

    #region -- IsUnderlyingEnum --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool IsUnderlyingEnum(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().IsEnum;
#else
      return type.IsEnum || type.UnderlyingSystemType.IsEnum;
#endif
    }

    #endregion

    #region -- GetMethodInfos --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static MethodInfo[] GetMethodInfos(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetRuntimeMethods().ToArray();
#else
      return type.GetMethods();
#endif
    }

    #endregion

    #region -- GetPropertyInfos --

    //#if !NET40
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //#endif
    //    public static PropertyInfo[] GetPropertyInfos(this Type type)
    //    {
    //#if (NETFX_CORE || PCL || NETSTANDARD)
    //      return type.GetRuntimeProperties().ToArray();
    //#else
    //      return type.GetProperties();
    //#endif
    //    }

    #endregion

    #region -- IsGenericTypeDefinition --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool IsGenericTypeDefinition(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().IsGenericTypeDefinition;
#else
      return type.IsGenericTypeDefinition;
#endif
    }

    #endregion

    #region -- IsGenericType --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool IsGenericType(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().IsGenericType;
#else
      return type.IsGenericType;
#endif
    }

    #endregion

    #region -- ContainsGenericParameters --

    public static bool ContainsGenericParameters(this Type type)
    {
#if (NETFX_CORE || PCL || NETSTANDARD)
      return type.GetTypeInfo().ContainsGenericParameters;
#else
      return type.ContainsGenericParameters;
#endif
    }

    #endregion

    #region -- GetDeclaringTypeName --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static string GetDeclaringTypeName(this Type type)
    {
      if (type.DeclaringType != null)
        return type.DeclaringType.Name;

#if !(NETFX_CORE || WP || PCL || NETSTANDARD)
      if (type.ReflectedType != null)
        return type.ReflectedType.Name;
#endif

      return null;
    }

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static string GetDeclaringTypeName(this MemberInfo mi)
    {
      if (mi.DeclaringType != null)
        return mi.DeclaringType.Name;

#if !(NETFX_CORE || WP || PCL || NETSTANDARD)
      return mi.ReflectedType.Name;
#else
      return null;
#endif
    }

    #endregion

    #region -- GetDeclaringType --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Type GetDeclaringType(this Type type)
    {
      if (type.DeclaringType != null)
        return type.DeclaringType;

#if !(NETFX_CORE || WP || PCL || NETSTANDARD)
      if (type.ReflectedType != null)
        return type.ReflectedType;
#endif

      return null;
    }

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Type GetDeclaringType(this MemberInfo mi)
    {
      if (mi.DeclaringType != null)
        return mi.DeclaringType;

#if !(NETFX_CORE || WP || PCL || NETSTANDARD)
      return mi.ReflectedType;
#else
      return null;
#endif
    }

    #endregion

    #region -- CreateDelegate --

    //#if !NET40
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //#endif
    //    public static Delegate CreateDelegate(this MethodInfo methodInfo, Type delegateType)
    //    {
    //#if PCL || NETSTANDARD
    //      return methodInfo.CreateDelegate(delegateType);
    //#else
    //      return Delegate.CreateDelegate(delegateType, methodInfo);
    //#endif
    //    }

    //#if !NET40
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //#endif
    //    public static Delegate CreateDelegate(this MethodInfo methodInfo, Type delegateType, object target)
    //    {
    //#if PCL || NETSTANDARD
    //      return methodInfo.CreateDelegate(delegateType, target);
    //#else
    //      return Delegate.CreateDelegate(delegateType, target, methodInfo);
    //#endif
    //    }

    #endregion

    #region -- ElementType --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Type ElementType(this Type type)
    {
#if PCL
      return type.GetTypeInfo().GetElementType();
#else
      return type.GetElementType();
#endif
    }

    #endregion

    #region -- GetCollectionType --

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Type GetCollectionType(this Type type)
    {
      return type.ElementType() ?? type.GetTypeGenericArguments().FirstOrDefault();
    }

    #endregion
  }
}
#endif