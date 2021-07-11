using Terraria.ModLoader;
using TomatUtilities.Reflection;

namespace TomatUtilities
{
    public class TomatUtilities : Mod
    {
        public TomatUtilities()
        {
            ReflectionCache.Instance = new ReflectionCache();
        }
    }
}