using System;
using System.Diagnostics;
using System.Reflection;
using Terraria.ModLoader;
using TomatUtilities.Core.Logging;
using TomatUtilities.GlowMask;
using TomatUtilities.Reflection;

namespace TomatUtilities
{
    public class TomatUtilities : Mod
    {
        private class Nest
        {
            public void Method(IModLogger logger) => logger.Debug("Nested log.");
        }

        public const bool TestsEnabled = false;

        public IModLogger ModLogger { get; protected set; }

        private static readonly Nest Nested = new Nest();

        public TomatUtilities()
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

            ExecutePrivately(() =>
            {
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (TestsEnabled)
                {
                    ModLogger.Info("Testing reflection...");

                    FieldInfo field = GetType().GetCachedField("Nested");
                    PropertyInfo property = GetType().GetCachedProperty("ModLogger");
                    MethodInfo method = GetType().GetCachedMethod("Load");
                    Type nest = GetType().GetCachedNestedType("Nest");
                    ConstructorInfo constructor = nest.GetCachedConstructor();
                    Type type = GetType().Assembly.GetCachedType("TomatUtilities.TomatUtilities");

                    Debug.Assert(field != null);
                    Debug.Assert(property != null);
                    Debug.Assert(method != null);
                    Debug.Assert(constructor != null);
                    Debug.Assert(nest != null);
                    Debug.Assert(type != null);

                    // property will work if field works
                    field.InvokeUnderlyingMethod("Method", Nested, ModLogger);

                    // TODO: more tests
                }
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