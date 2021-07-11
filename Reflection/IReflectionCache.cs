using System;
using System.Reflection;

namespace TomatUtilities.Reflection
{
    public interface IReflectionCache
    {
        object InvokeUnderlyingMethod(FieldInfo info, string methodName, object instance,
            params object[] parameters);

        object InvokeUnderlyingMethod(PropertyInfo info, string methodName, object instance,
            params object[] parameters);

        FieldInfo GetCachedField(Type type, string key);

        PropertyInfo GetCachedProperty(Type type, string key);

        MethodInfo GetCachedMethod(Type type, string key);

        ConstructorInfo GetCachedConstructor(Type type, params Type[] identity);

        Type GetCachedType(Assembly assembly, string key);

        Type GetCachedNestedType(Type type, string key);

        string GetUniqueFieldKey(Type type, string key);

        string GetUniquePropertyKey(Type type, string key);

        string GetUniqueMethodKey(Type type, string key);

        string GetUniqueConstructorKey(Type type, params Type[] identity);

        string GetUniqueTypeKey(Assembly assembly, string key);

        string GetUniqueNestedTypeKey(Type type, string key);

        TReturn RetrieveFromCache<TReturn>(ReflectionType refType, string key, Func<TReturn> fallback);

        void ReplaceInfoInstance(FieldInfo info, object instance = null, object replacementInstance = null);

        void ReplaceInfoInstance(PropertyInfo info, object instance = null, object replacementInstance = null);

        TReturn GetValue<TReturn>(FieldInfo info, object instance = null);

        TReturn GetValue<TReturn>(PropertyInfo info, object instance = null);

        void SetValue(FieldInfo info, object fieldInstance = null, object fieldValue = null);

        void SetValue(PropertyInfo info, object fieldInstance = null, object fieldValue = null);

        TReturn GetFieldValue<TType, TReturn>(TType instance, string field, object fieldInstance = null);

        TReturn GetPropertyValue<TType, TReturn>(TType instance, string property, object fieldInstance = null);

        void SetFieldValue<TType>(TType instance, string field, object fieldInstance = null, object fieldValue = null);

        void SetPropertyValue<TType>(TType instance, string property, object fieldInstance = null,
            object fieldValue = null);
    }
}