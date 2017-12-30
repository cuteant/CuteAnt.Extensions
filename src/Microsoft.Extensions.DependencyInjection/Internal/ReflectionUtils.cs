using System;
using System.Reflection;
#if NET40
using System.Linq;
#else
using System.Runtime.CompilerServices;
#endif

namespace Microsoft.Extensions.Internal
{
  internal static class ReflectionUtils
  {
#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool IsConstructedGenericType(this Type t)
    {
#if NET40
      return t.IsGenericType && !t.IsGenericTypeDefinition;
#else
      return t.IsConstructedGenericType;
#endif
    }

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static Type[] GetTypeGenericArguments(this Type type)
    {
#if NET40
      return type.IsGenericType && !type.IsGenericTypeDefinition ? type.GetGenericArguments() : Type.EmptyTypes;
#else
      return type.GenericTypeArguments;
#endif
    }

#if !NET40
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool HasDefaultValue(this ParameterInfo pi)
    {
#if NET40
      const string _DBNullType = "System.DBNull";
      var defaultValue = pi.DefaultValue;
      if (null == defaultValue && pi.ParameterType.IsValueType)
      {
        defaultValue = Activator.CreateInstance(pi.ParameterType);
      }
      return null == defaultValue || !string.Equals(_DBNullType, defaultValue.GetType().FullName, StringComparison.Ordinal);
#else
      return pi.HasDefaultValue;
#endif
    }

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
  }
}
