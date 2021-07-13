namespace TomatUtilities.Core.Drawing.GlowMask
{
    public interface IGlowMaskRepository
    {
        short GetGlowMask(string key);

        void RemoveGlowMasks();
    }
}