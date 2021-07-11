using TomatUtilities.Core.NewLoader;
using TomatUtilities.GlowMask;
using TomatUtilities.Reflection;

namespace TomatUtilities
{
    public class TomatUtilities : TomatMod
    {
        public TomatUtilities()
        {
            ReflectionCache.Instance = new ReflectionCache();
            GlowMaskRepository.Instance = new GlowMaskRepository();
        }

        public override void Unload()
        {
            GlowMaskRepository.Instance.RemoveGlowMasks();

            ReflectionCache.Instance = null;
            GlowMaskRepository.Instance = null;
        }
    }
}