using System;
using System.Reflection;

namespace TomatUtilities.Reflection
{
    public static class ReflectionExtensions
    {
        public static object InvokeUnderlyingMethod(this FieldInfo info, string methodName, object instance,
            params object[] parameters) =>
            ReflectionCache.Instance.InvokeUnderlyingMethod(info, methodName, instance, parameters);

        public static object InvokeUnderlyingMethod(this PropertyInfo info, string methodName, object instance,
            params object[] parameters) =>
            ReflectionCache.Instance.InvokeUnderlyingMethod(info, methodName, instance, parameters);

        public static FieldInfo GetCachedField(this Type type, string key) =>
            ReflectionCache.Instance.GetCachedField(type, key);

        public static PropertyInfo GetCachedProperty(this Type type, string key) =>
            ReflectionCache.Instance.GetCachedProperty(type, key);

        public static MethodInfo GetCachedMethod(this Type type, string key) =>
            ReflectionCache.Instance.GetCachedMethod(type, key);

        public static ConstructorInfo GetCachedConstructor(this Type type, params Type[] identity) =>
            ReflectionCache.Instance.GetCachedConstructor(type, identity);

        public static Type GetCachedType(this Assembly assembly, string key) =>
            ReflectionCache.Instance.GetCachedType(assembly, key);

        public static Type GetCachedNestedType(this Type type, string key) =>
            ReflectionCache.Instance.GetCachedNestedType(type, key);

        public static void ReplaceInfoInstance(this FieldInfo info, object instance = null,
            object replacementInstance = null) =>
            ReflectionCache.Instance.ReplaceInfoInstance(info, instance, replacementInstance);

        public static void ReplaceInfoInstance(this PropertyInfo info, object instance = null,
            object replacementInstance = null) =>
            ReflectionCache.Instance.ReplaceInfoInstance(info, instance, replacementInstance);

        public static TReturn GetValue<TReturn>(this FieldInfo info, object fieldInstance = null) =>
            ReflectionCache.Instance.GetValue<TReturn>(info, fieldInstance);

        public static TReturn GetValue<TReturn>(this PropertyInfo info, object fieldInstance = null) =>
            ReflectionCache.Instance.GetValue<TReturn>(info, fieldInstance);

        public static void SetValue(this FieldInfo info, object instance = null, object fieldValue = null) =>
            ReflectionCache.Instance.SetValue(info, instance, fieldValue);

        public static void SetValue(this PropertyInfo info, object instance = null, object fieldValue = null) =>
            ReflectionCache.Instance.SetValue(info, instance, fieldValue);

        public static TReturn GetFieldValue<TType, TReturn>(this TType instance, string field) =>
            ReflectionCache.Instance.GetFieldValue<TType, TReturn>(instance, field);

        public static TReturn GetPropertyValue<TType, TReturn>(this TType instance, string property) =>
            ReflectionCache.Instance.GetPropertyValue<TType, TReturn>(instance, property);

        public static void SetFieldValue<TType>(this TType instance, string field, object fieldValue = null) =>
            ReflectionCache.Instance.SetFieldValue(instance, field, fieldValue);

        public static void SetPropertyValue<TType>(this TType instance, string property, object fieldValue = null) =>
            ReflectionCache.Instance.SetPropertyValue(instance, property, fieldValue);
    }
}