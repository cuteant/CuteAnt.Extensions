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
#if NET40
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
    public static bool HasDefaultValueEx(this ParameterInfo pi)
    {
#if NET40
      const string _DBNullType = "System.DBNull";
      return pi.DefaultValue == null || pi.DefaultValue.GetType().FullName != _DBNullType;
#else
      return pi.HasDefaultValue;
#endif
    }
  }
}
