using System;
using H3Net.Constants;
using H3Net.Models;
using H3Net.Utils;

namespace H3Net.Extensions;

internal static class Vector2Extensions
{
    public static GeoCoordinate ToGeoCoordinate(this Vector2 vector2, int face, int resolution, bool isSubstrate)
    {
        var magnitude = vector2.CalculateMagnitude();
        var icosahedronFace = new IcosahedronFace(face);
        
        if (magnitude < CalculateConstants.Epsilon)
        {
            return icosahedronFace.CenterCoordinate;
        }

        var theta = Math.Atan2(vector2.Y, vector2.X);

        for (var i = 0; i < resolution; i++)
        {
            magnitude *= Math.Sqrt(1.0 / 7.0);
        }

        if (isSubstrate)
        {
            magnitude *= 1.0 / 3.0;
            
            if (ResolutionUtils.IsResolutionThirdClass(resolution))
            {
                magnitude *= Math.Sqrt(1.0 / 7.0);
            }
        }

        magnitude *= CalculateConstants.Res0UGnomonic;

        magnitude = Math.Atan(magnitude);

        if (!isSubstrate && ResolutionUtils.IsResolutionThirdClass(resolution))
        {
            theta = AngleUtils.NormalizeRadians(theta + Math.Asin(Math.Sqrt(3.0 / 28.0)));
        }

        theta = AngleUtils.NormalizeRadians(icosahedronFace.BaseAxisAzimuthRadians - theta);

        var coordinate = icosahedronFace.CenterCoordinate.MoveByAzimuthAndDistance(theta, magnitude);

        return coordinate;
    }
    
    public static CoordinateIjk ToCoordinateIjk(this Vector2 vector)
    {
        int i, j;

        var a1 = Math.Abs(vector.X);
        var a2 = Math.Abs(vector.Y);

        var x2 = a2 * (1.0 / Math.Sin(Math.PI / 3.0)); // 1/sin(60°)
        var x1 = a1 + x2 / 2.0;

        var m1 = (int)x1;
        var m2 = (int)x2;

        var r1 = x1 - m1;
        var r2 = x2 - m2;

        if (r1 < 0.5)
        {
            if (r1 < 1.0 / 3.0)
            {
                i = m1;
                if (r2 < (1.0 + r1) / 2.0)
                {
                    j = m2;
                }
                else
                {
                    j = m2 + 1;
                }
            }
            else
            {
                if (r2 < 1.0 - r1)
                {
                    j = m2;
                }
                else
                {
                    j = m2 + 1;
                }

                if (1.0 - r1 <= r2 && r2 < 2.0 * r1)
                {
                    i = m1 + 1;
                }
                else
                {
                    i = m1;
                }
            }
        }
        else
        {
            if (r1 < 2.0 / 3.0)
            {
                if (r2 < 1.0 - r1)
                {
                    j = m2;
                }
                else
                {
                    j = m2 + 1;
                }

                if (2.0 * r1 - 1.0 < r2 && r2 < 1.0 - r1)
                {
                    i = m1;
                }
                else
                {
                    i = m1 + 1;
                }
            }
            else
            {
                if (r2 < r1 / 2.0)
                {
                    i = m1 + 1;
                    j = m2;
                }
                else
                {
                    i = m1 + 1;
                    j = m2 + 1;
                }
            }
        }

        if (vector.X < 0.0)
        {
            if (j % 2 == 0)
            {
                long axisi = j / 2;
                var diff = i - axisi;
                i = (int)(i - 2 * diff);
            }
            else
            {
                long axisi = (j + 1) / 2;
                var diff = i - axisi;
                i = (int)(i - (2 * diff + 1));
            }
        }

        if (vector.Y < 0.0)
        {
            i -= (2 * j + 1) / 2;
            j = -j;
        }

        var coordinate = new CoordinateIjk(i, j, 0);

        var normalizedCoordinate = coordinate.Normalize();

        return normalizedCoordinate;
    }
}