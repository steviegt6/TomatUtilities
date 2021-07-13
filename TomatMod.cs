using System;
using Terraria.ModLoader;
using TomatUtilities.Core.Drawing.GlowMask;
using TomatUtilities.Core.Logging;
using TomatUtilities.Reflection;

namespace TomatUtilities
{
    public class TomatMod : Mod
    {
        public IModLogger ModLogger { get; protected set; }

        public TomatMod()
        {
            ExecutePrivately(() =>
            {
                ReflectionCache.Instance = new ReflectionCache();
                GlowMaskRepository.Instance = new GlowMaskRepository();
            });
        }

        public override void Load()
        {
            base.Load();

            ModLogger = new ModLogger(Logger);
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