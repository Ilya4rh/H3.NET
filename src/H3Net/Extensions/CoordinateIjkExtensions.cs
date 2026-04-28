using System;
using H3Net.Models;

namespace H3Net.Extensions;

internal static class CoordinateIjkExtensions
{
    public static Vector2 ToVector2(this CoordinateIjk coordinate)
    {
        var i = coordinate.I - coordinate.K;
        var j = coordinate.J - coordinate.K;

        var x = i - 0.5 * j;
        var y = j * (Math.Sqrt(3) / 2.0);

        return new Vector2(x, y);
    }
}