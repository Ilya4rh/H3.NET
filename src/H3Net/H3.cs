using System;
using System.Collections.Generic;
using H3Net.Extensions;
using H3Net.Models;

namespace H3Net;

public static class H3
{
    private const int MaxResolution = 15;

    public static H3Index GeoCoordinateToH3Index(double latitudeDegrees, double longitudeDegrees, int resolution)
    {
        if (resolution is < 0 or > MaxResolution)
        {
            throw new ArgumentOutOfRangeException();
        }

        var geoCoordinate = GeoCoordinate.CreateFromDegrees(latitudeDegrees, longitudeDegrees);
        
        var faceIjk = geoCoordinate.ToFaceIjk(resolution);

        var index = H3IndexCreator.FaceIjkToH3Index(faceIjk, resolution);

        return index;
    }

    public static GeoCoordinate H3IndexToGeoCoordinate(H3Index index)
    {
        var faceIjk = H3IndexCreator.H3IndexToFaceIjk(index);

        var coordinate = faceIjk.ToGeoCoordinate(index.GetResolution());

        return coordinate;
    }

    public static IEnumerable<H3Index> GetGridDisk(H3Index index, int diskSize)
    {
        return Algorithm.GetGridDisk(index, diskSize);
    }
}