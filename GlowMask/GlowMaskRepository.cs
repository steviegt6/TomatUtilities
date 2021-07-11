using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using TomatUtilities.Core.Extensions;

namespace TomatUtilities.GlowMask
{
    public class GlowMaskRepository : IGlowMaskRepository
    {
        public static IGlowMaskRepository Instance { get; internal set; }

        public readonly Dictionary<string, short> GlowMaskCollection;

        public GlowMaskRepository()
        {
            GlowMaskCollection = new Dictionary<string, short>();
        }

        public short GetGlowMask(string key)
        {
            if (GlowMaskCollection.TryGetValue(key, out short found))
                return found;

            return -1;
        }

        public short Register(Mod mod, string assetPath) => Register($"{mod.Name}/{assetPath}");

        public short Register(string assetPath)
        {
            short count = (short) Main.glowMaskTexture.Length;
            Texture2D texture = ModContent.GetTexture(assetPath);
            texture.Name = $"AddedByTomat{texture.Name}";

            Main.glowMaskTexture.AddToArray(ModContent.GetTexture(assetPath));
            GlowMaskCollection.Add(assetPath, count);
            return count;
        }

        public void RemoveGlowMasks()
        {
            Main.glowMaskTexture =
                Main.glowMaskTexture.Where(x => !x?.Name.StartsWith("AddedByTomat") ?? true).ToArray();
            GlowMaskCollection.Clear();
        }
    }
}