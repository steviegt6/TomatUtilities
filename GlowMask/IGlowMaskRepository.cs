namespace TomatUtilities.GlowMask
{
    public interface IGlowMaskRepository
    {
        short GetGlowMask(string key);

        void RemoveGlowMasks();
    }
}