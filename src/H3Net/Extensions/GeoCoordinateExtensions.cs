using System;
using H3Net.Constants;
using H3Net.Models;
using H3Net.Utils;

namespace H3Net.Extensions;

internal static class GeoCoordinateExtensions
{
    public static FaceIjk ToFaceIjk(this GeoCoordinate coordinate, int resolution)
    {
        var vector2 = coordinate.ToVector2(resolution);
        
        var icosahedronFace = IcosahedronFace.GetIcosahedronFace(coordinate);

        var coordinateIjk = vector2.ToCoordinateIjk();

        return new FaceIjk(icosahedronFace.Number, coordinateIjk);
    }

    public static Vector3 ToVector3(this GeoCoordinate coordinate)
    {
        var r = Math.Cos(coordinate.LatitudeRadians);

        var x = Math.Cos(coordinate.LongitudeRadians) * r;
        var y = Math.Sin(coordinate.LongitudeRadians) * r;
        var z = Math.Sin(coordinate.LatitudeRadians);
        
        return new Vector3(x, y, z);
    }

    private static Vector2 ToVector2(this GeoCoordinate coordinate, int resolution)
    {
        var vector3 = coordinate.ToVector3();
        var icosahedronFace = IcosahedronFace.GetIcosahedronFace(coordinate);
        var faceCenterDistanceSquared = icosahedronFace.CenterPoint.DistanceSquaredTo(vector3);
        
        // Угол между вектором к исходной точке coordinate и вектором к центру икосаэдрической грани номера face
        // cos(r) = 1 - 2 * sin^2(r/2) = 1 - 2 * (sqd / 4) = 1 - sqd/2
        var angleToFaceCenter = Math.Acos(1 - faceCenterDistanceSquared * 0.5);

        if (angleToFaceCenter < CalculateConstants.Epsilon)
        {
            return new Vector2(0, 0);
        }
        
        var azimuthInRadians = icosahedronFace.CenterCoordinate.CalculateAzimuthRadians(coordinate);
        var normalizedAzimuthRadians = AngleUtils.NormalizeRadians(azimuthInRadians);
        var theta = AngleUtils.NormalizeRadians(icosahedronFace.BaseAxisAzimuthRadians - normalizedAzimuthRadians);

        if (ResolutionUtils.IsResolutionThirdClass(resolution))
        {
            // угол поворота между осями разрешения класса II и класса III
            // (asin(sqrt(3.0 / 28.0)))
            theta = AngleUtils.NormalizeRadians(theta - Math.Asin(Math.Sqrt(3.0 / 28.0)));
        }

        angleToFaceCenter = Math.Tan(angleToFaceCenter);

        angleToFaceCenter *= CalculateConstants.InvRes0UGnomonic;
        for (var i = 0; i < resolution; i++)
        {
            angleToFaceCenter *= Math.Sqrt(7);
        }

        var x = angleToFaceCenter * Math.Cos(theta);
        var y = angleToFaceCenter * Math.Sin(theta);

        return new Vector2(x, y);
    }
}