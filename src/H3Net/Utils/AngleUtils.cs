using System;

namespace H3Net.Utils;

internal static class AngleUtils
{
    public static double NormalizeRadians(double radians)
    {
        const double twoPi = 2 * Math.PI;

        var normalizeRadians = radians < 0 ? radians + twoPi : radians;

        if (radians >= twoPi)
        {
            normalizeRadians -= twoPi;
        }

        return normalizeRadians;
    }
}