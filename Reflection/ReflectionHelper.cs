using System.Reflection;

namespace TomatUtilities.Reflection
{
    public static class ReflectionHelper
    {
        public static BindingFlags PublicityFlags => BindingFlags.Public | BindingFlags.NonPublic;

        public static BindingFlags InstancedFlags => BindingFlags.Instance | BindingFlags.Static;

        public static BindingFlags UniversalFlags => PublicityFlags | InstancedFlags;
    }
}