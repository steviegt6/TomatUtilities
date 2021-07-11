using System;
using Terraria.ModLoader;
using TomatUtilities.Core.Logging;
using TomatUtilities.GlowMask;
using TomatUtilities.Reflection;

namespace TomatUtilities
{
    public class TomatUtilities : Mod
    {
        public IModLogger ModLogger { get; }

        public TomatUtilities()
        {
            ModLogger = new ModLogger(Logger);

            ExecutePrivately(() =>
            {
                ReflectionCache.Instance = new ReflectionCache();
                GlowMaskRepository.Instance = new GlowMaskRepository();
            });
        }

        public override void Unload()
        {
            base.Unload();

            ExecutePrivately(() =>
            {
                GlowMaskRepository.Instance.RemoveGlowMasks();

                ReflectionCache.Instance = null;
                GlowMaskRepository.Instance = null;
            });
        }

        private void ExecutePrivately(Action action)
        {
            if (GetType().Assembly.FullName.StartsWith("TomatUtilities, "))
                action?.Invoke();
        }
    }
}