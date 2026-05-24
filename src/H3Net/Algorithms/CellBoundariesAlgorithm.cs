using System;
using System.Collections.Generic;
using H3Net.Constants;
using H3Net.Enums;
using H3Net.Extensions;
using H3Net.Models;
using H3Net.Utils;

namespace H3Net.Algorithms;

internal class CellBoundariesAlgorithm
{
    private const int PentagonBoundaryCount = 5;
    private const int HexagonBoundaryCount = 6;
    
    public static List<GeoCoordinate> GetCoordinates(H3Index index)
    {
        var faceIjk = H3IndexCreator.H3IndexToFaceIjk(index);

        var boundaries = index.IsPentagon()
            ? GetPentagonCellBoundaries(faceIjk, index.GetResolution(), 0, PentagonBoundaryCount)
            : GetHexagonCellBoundaries(faceIjk, index.GetResolution(), 0, HexagonBoundaryCount);

        return boundaries;
    }

    private static List<GeoCoordinate> GetPentagonCellBoundaries(FaceIjk faceIjk, int resolution, int firstBoundary, int boundaryCount)
    {
        var result = new List<GeoCoordinate>();
        var adjustedResolution = resolution;
        var centerFaceIjk = faceIjk;
        var boundariesFaceIjk = GetPentagonBoundariesFaceIjk(centerFaceIjk, ref adjustedResolution);

        var additionalIteration = boundaryCount == PentagonBoundaryCount ? 1 : 0;

        var lastFaceIjk = new FaceIjk();

        for (var i = firstBoundary; i < firstBoundary + boundaryCount + additionalIteration; i++)
        {
            var currentBoundary = i % PentagonBoundaryCount;
            
            var currentFaceIjk = boundariesFaceIjk[currentBoundary];

            GetAdjustedPentagonBoundaryOverage(ref currentFaceIjk, adjustedResolution);

            if (ResolutionUtils.IsResolutionThirdClass(resolution) && i > firstBoundary)
            {
                var tempFaceIjk = currentFaceIjk;
                var lastFaceIjkVector2 = lastFaceIjk.CoordinateIjk.ToVector2();
                var currentToLastDir =
                    IcosahedronFaceConstants.IcosahedronFaceAdjacencyDirections[tempFaceIjk.Face, lastFaceIjk.Face];
                
                var faceOrientIjk = FaceOrientIjkConstants.FaceNeighbors[tempFaceIjk.Face, currentToLastDir];

                
                tempFaceIjk = new FaceIjk(faceOrientIjk.Face, tempFaceIjk.CoordinateIjk);
                var coordinateIjk = tempFaceIjk.CoordinateIjk;

                for (var j = 0; j < faceOrientIjk.CcwRotation60; j++)
                {
                    coordinateIjk = coordinateIjk.Rotate60Ccw();
                }
                
                var transformedCoordinateIjk = faceOrientIjk.CoordinateIjk;
                transformedCoordinateIjk *=
                    ResolutionConstants.UnitScaleBySecondClassResolution[adjustedResolution] * 3;
                coordinateIjk += transformedCoordinateIjk;
                coordinateIjk = coordinateIjk.Normalize();
                
                var tempVector2 = coordinateIjk.ToVector2();
                
                var maxDim = ResolutionConstants.MaxDimBySecondClassResolution[adjustedResolution];

                var v0 = new Vector2(3.0 * maxDim, 0.0);
                var v1 = new Vector2(-1.5 * maxDim, 3.0 * (Math.Sqrt(3) / 2.0) * maxDim);
                var v2 = new Vector2(-1.5 * maxDim, -3.0 * (Math.Sqrt(3) / 2.0) * maxDim);

                Vector2 edge0;
                Vector2 edge1;

                switch (IcosahedronFaceConstants.IcosahedronFaceAdjacencyDirections[tempFaceIjk.Face, currentFaceIjk.Face])
                {
                    case 1: // IJ
                        edge0 = v0;
                        edge1 = v1;
                        break;
                    case 3: // JK
                        edge0 = v1;
                        edge1 = v2;
                        break;
                    default: // KI
                        edge0 = v2;
                        edge1 = v0;
                        break;
                    
                }

                var intersectVector = Vector2Utils.Intersect(lastFaceIjkVector2, tempVector2, edge0, edge1);
                var geoCoordinate = intersectVector.ToGeoCoordinate(tempFaceIjk.Face, adjustedResolution, true);
                result.Add(geoCoordinate);
            }

            if (i < firstBoundary + PentagonBoundaryCount)
            {
                var vector2 = currentFaceIjk.CoordinateIjk.ToVector2();
                var geoCoordinate = vector2.ToGeoCoordinate(currentFaceIjk.Face, adjustedResolution, true);
                result.Add(geoCoordinate);
            }

            lastFaceIjk = currentFaceIjk;
        }

        return result;
    }

    private static List<FaceIjk> GetPentagonBoundariesFaceIjk(FaceIjk centerCellFaceIjk, ref int resolution)
    {
        var boundariesFaceIjk = new List<FaceIjk>();
        
        var secondClassBoundaryCoordinateIjk = new CoordinateIjk[]
        {
            new(2,1,0),
            new(1,2,0),
            new(0,2,1),
            new(0,1,2),
            new(1,0,2),
        };
        
        var thirdClassBoundaryCoordinateIjk = new CoordinateIjk[]
        {
            new(5,4,0),
            new(1,5,0),
            new(0,5,4),
            new(0,1,5),
            new(4,0,5),
        };

        var boundaryCoordinatesIjk = ResolutionUtils.IsResolutionThirdClass(resolution)
            ? thirdClassBoundaryCoordinateIjk
            : secondClassBoundaryCoordinateIjk;

        var centerCellCoordinateIjk = centerCellFaceIjk.CoordinateIjk;
        centerCellCoordinateIjk = centerCellCoordinateIjk.DownAp3();
        centerCellCoordinateIjk = centerCellCoordinateIjk.DownAp3Rotated();

        if (ResolutionUtils.IsResolutionThirdClass(resolution))
        {
            centerCellCoordinateIjk = centerCellCoordinateIjk.DownAp7Rotated();
            resolution++;
        }
        
        for (var i = 0; i < PentagonBoundaryCount; i++)
        {
            var boundaryCoordinateIjk = centerCellCoordinateIjk + boundaryCoordinatesIjk[i];
            boundaryCoordinateIjk = boundaryCoordinateIjk.Normalize();
            var boundaryFaceIjk = new FaceIjk(centerCellFaceIjk.Face, boundaryCoordinateIjk);
            boundariesFaceIjk.Add(boundaryFaceIjk);
        }

        return boundariesFaceIjk;
    }

    private static Overage GetAdjustedPentagonBoundaryOverage(ref FaceIjk boundaryFaceIjk, int resolution)
    {
        Overage overage;
        
        do
        {
            overage = H3IndexCreator.AdjustOverageSecondClass(resolution, false, true, ref boundaryFaceIjk);
        } while (overage == Overage.NewFace);
        
        return overage;
    }

    private static List<GeoCoordinate> GetHexagonCellBoundaries(FaceIjk faceIjk, int resolution, int firstBoundary,
        int boundaryCount)
    {
        var result = new List<GeoCoordinate>();
        var adjustedResolution = resolution;
        var boundariesFaceIjk = GetHexagonBoundariesFaceIjk(faceIjk, ref adjustedResolution);

        var additionalIteration = boundaryCount == HexagonBoundaryCount ? 1 : 0;

        var lastFace = -1;
        var lastOverage = Overage.NoOverage;

        for (var i = firstBoundary; i < firstBoundary + boundaryCount + additionalIteration; i++)
        {
            var currentBoundary = i % HexagonBoundaryCount;
            var currentFaceIjk = boundariesFaceIjk[currentBoundary];

            var overage = H3IndexCreator.AdjustOverageSecondClass(adjustedResolution, false, true, ref currentFaceIjk);

            if (ResolutionUtils.IsResolutionThirdClass(resolution) && i > firstBoundary &&
                currentFaceIjk.Face != lastFace && lastOverage != Overage.FaceEdge)
            {
                var lastBoundary = (currentBoundary + 5) % HexagonBoundaryCount;
                var lastVector2 = boundariesFaceIjk[lastBoundary].CoordinateIjk.ToVector2();
                var currentVector2 = boundariesFaceIjk[currentBoundary].CoordinateIjk.ToVector2();

                var maxDim = ResolutionConstants.MaxDimBySecondClassResolution[adjustedResolution];
                
                var v0 = new Vector2(3.0 * maxDim, 0.0);
                var v1 = new Vector2(-1.5 * maxDim, 3.0 * (Math.Sqrt(3) / 2.0) * maxDim);
                var v2 = new Vector2(-1.5 * maxDim, -3.0 * (Math.Sqrt(3) / 2.0) * maxDim);
                
                var face2 = lastFace == faceIjk.Face ? currentFaceIjk.Face : lastFace;
                
                Vector2 edge0;
                Vector2 edge1;
                
                switch (IcosahedronFaceConstants.IcosahedronFaceAdjacencyDirections[faceIjk.Face, face2])
                {
                    case 1: // IJ
                        edge0 = v0;
                        edge1 = v1;
                        break;
                    case 2: // JK
                        edge0 = v1;
                        edge1 = v2;
                        break;
                    default: // KI
                        edge0 = v2;
                        edge1 = v0;
                        break;
                }
                
                var intersectVector = Vector2Utils.Intersect(lastVector2, currentVector2, edge0, edge1);

                var isIntersectionInBoundary = lastVector2 == intersectVector || currentVector2 == intersectVector;

                if (!isIntersectionInBoundary)
                {
                    var coordinate = intersectVector.ToGeoCoordinate(faceIjk.Face, adjustedResolution, true);
                    result.Add(coordinate);
                }
            }

            if (i < firstBoundary + HexagonBoundaryCount)
            {
                var vector = currentFaceIjk.CoordinateIjk.ToVector2();
                var coordinate = vector.ToGeoCoordinate(currentFaceIjk.Face, adjustedResolution, true);
                result.Add(coordinate);
            }
            
            lastFace = currentFaceIjk.Face;
            lastOverage = overage;
        }
        
        return result;
    }
    
    private static List<FaceIjk> GetHexagonBoundariesFaceIjk(FaceIjk centerCellFaceIjk, ref int resolution)
    {
        var boundariesFaceIjk = new List<FaceIjk>();
        
        var secondClassBoundaryCoordinateIjk = new CoordinateIjk[]
        {
            new(2,1,0),
            new(1,2,0),
            new(0,2,1),
            new(0,1,2),
            new(1,0,2),
            new(2,0,1),
        };
        
        var thirdClassBoundaryCoordinateIjk = new CoordinateIjk[]
        {
            new(5,4,0),
            new(1,5,0),
            new(0,5,4),
            new(0,1,5),
            new(4,0,5),
            new(5,0,1),
        };

        var boundaryCoordinatesIjk = ResolutionUtils.IsResolutionThirdClass(resolution)
            ? thirdClassBoundaryCoordinateIjk
            : secondClassBoundaryCoordinateIjk;

        var centerCellCoordinateIjk = centerCellFaceIjk.CoordinateIjk;
        centerCellCoordinateIjk = centerCellCoordinateIjk.DownAp3();
        centerCellCoordinateIjk = centerCellCoordinateIjk.DownAp3Rotated();

        if (ResolutionUtils.IsResolutionThirdClass(resolution))
        {
            centerCellCoordinateIjk = centerCellCoordinateIjk.DownAp7Rotated();
            resolution++;
        }
        
        for (var i = 0; i < HexagonBoundaryCount; i++)
        {
            var boundaryCoordinateIjk = centerCellCoordinateIjk + boundaryCoordinatesIjk[i];
            boundaryCoordinateIjk = boundaryCoordinateIjk.Normalize();
            var boundaryFaceIjk = new FaceIjk(centerCellFaceIjk.Face, boundaryCoordinateIjk);
            boundariesFaceIjk.Add(boundaryFaceIjk);
        }

        return boundariesFaceIjk;
    }
}