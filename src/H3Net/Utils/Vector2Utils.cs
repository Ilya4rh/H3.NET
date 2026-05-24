using H3Net.Models;

namespace H3Net.Utils;

internal class Vector2Utils
{
    public static Vector2 Intersect(
        Vector2 v0,
        Vector2 v1,
        Vector2 v2,
        Vector2 v3)
    {
        var s1X = v1.X - v0.X;
        var s1Y = v1.Y - v0.Y;

        var s2X = v3.X - v2.X;
        var s2Y = v3.Y - v2.Y;

        var t =
            (s2X * (v0.Y - v2.Y) - s2Y * (v0.X - v2.X)) /
            (-s2X * s1Y + s1X * s2Y);

        return new Vector2(v0.X + t * s1X, v0.Y + t * s1Y);
    }
}