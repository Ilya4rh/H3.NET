using System;

namespace H3Net.Utils;

internal static class DoublePrecision
{
    private const double DefaultPrecision = 1e-6;
    
    public static bool ApproxEquals(this double x, double? y)
    {
        if (x.Equals(y))
        {
            return true;
        }

        if (y == null)
        {
            return false;
        }

        return Math.Abs(x - y.Value) < DefaultPrecision;
    }
}