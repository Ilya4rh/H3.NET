using System;
using System.Collections.Generic;
using System.Linq;
using H3Net.Constants;
using H3Net.Models;

namespace H3Net.Algorithms;

internal static class IndexesInRadiusAlgorithm
{
    public static List<H3Index> GetIndexes(
        double latitudeDegrees, 
        double longitudeDegrees, 
        int resolution, 
        double radiusInMeters)
    {
        var center = GeoCoordinate.CreateFromDegrees(latitudeDegrees, longitudeDegrees);
        var inputIndex = H3.GeoCoordinateToH3Index(latitudeDegrees, longitudeDegrees, resolution);

        var diskSize =
            (int)Math.Ceiling(radiusInMeters / (ResolutionConstants.AverageBoundaryLengthsInMeters[resolution] * 2));

        var indexes = GridDiskAlgorithm.GetGridDisk(inputIndex, diskSize);

        return indexes
            .Where(index => 
                CellBoundariesAlgorithm.GetCoordinates(index)
                    .Any(coordinate => coordinate.DistanceTo(center) <= radiusInMeters))
            .ToList();
    }
}