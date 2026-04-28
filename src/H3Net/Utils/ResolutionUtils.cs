namespace H3Net.Utils;

internal static class ResolutionUtils
{
    public static bool IsResolutionThirdClass(int resolution)
    {
        return resolution % 2 == 1;
    }
}