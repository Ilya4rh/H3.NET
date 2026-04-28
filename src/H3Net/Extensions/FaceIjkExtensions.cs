using H3Net.Models;

namespace H3Net.Extensions;

internal static class FaceIjkExtensions
{
    public static GeoCoordinate ToGeoCoordinate(this FaceIjk faceIjk, int resolution)
    {
        var vector2 = faceIjk.CoordinateIjk.ToVector2();

        var coordinate = vector2.ToGeoCoordinate(faceIjk.Face, resolution, false);

        return coordinate;
    }
}