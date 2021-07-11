using Terraria.ModLoader;
using TomatUtilities.Core.Logging;

namespace TomatUtilities.Core.NewLoader
{
    public abstract class TomatMod : Mod
    {
        public IModLogger ModLogger { get; }

        protected TomatMod()
        {
            ModLogger = new ModLogger(Logger);
        }
    }
}