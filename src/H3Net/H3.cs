using System;
using System.Collections.Generic;
using System.Linq;
using H3Net.Constants;
using H3Net.Extensions;
using H3Net.Models;

namespace H3Net;

public static class H3
{
    public static H3Index GeoCoordinateToH3Index(double latitudeDegrees, double longitudeDegrees, int resolution)
    {
        if (resolution is < 0 or > ResolutionConstants.MaxResolution)
        {
            throw new ArgumentOutOfRangeException();
        }

        var geoCoordinate = GeoCoordinate.CreateFromDegrees(latitudeDegrees, longitudeDegrees);
        
        var faceIjk = geoCoordinate.ToFaceIjk(resolution);

        var index = H3IndexCreator.FaceIjkToH3Index(faceIjk, resolution);

        return index;
    }

    public static string GeoCoordinateToH3String(double latitudeDegrees, double longitudeDegrees, int resolution)
    {
        var h3Index = GeoCoordinateToH3Index(latitudeDegrees, longitudeDegrees, resolution);

        return h3Index.ToString();
    }

    public static GeoCoordinate H3IndexToGeoCoordinate(H3Index index)
    {
        var faceIjk = H3IndexCreator.H3IndexToFaceIjk(index);

        var coordinate = faceIjk.ToGeoCoordinate(index.GetResolution());

        return coordinate;
    }
    
    public static GeoCoordinate H3IndexToGeoCoordinate(string h3String)
    {
        if (!H3Index.TryParseH3String(h3String, out var h3Index))
        {
            throw new ArgumentException("Invalid H3 String", nameof(h3String));
        }

        var coordinate = H3IndexToGeoCoordinate(h3Index);

        return coordinate;
    }

    public static IEnumerable<H3Index> GetGridDisk(H3Index index, int diskSize)
    {
        return Algorithm.TryGetGridDisk(index, diskSize);
    }
    
    public static IEnumerable<string> GetGridDisk(string h3String, int diskSize)
    {
        if (!H3Index.TryParseH3String(h3String, out var h3Index))
        {
            throw new ArgumentException("Invalid H3 String", nameof(h3String));
        }
        
        var indexes = Algorithm.TryGetGridDisk(h3Index, diskSize);
        
        return indexes.Select(index => index.ToString()); 
    }
}