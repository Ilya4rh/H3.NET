using H3Net.Constants;
using H3Net.Enums;
using H3Net.Models;
using H3Net.Utils;

namespace H3Net;

internal static class H3IndexCreator
{
    public static H3Index FaceIjkToH3Index(FaceIjk faceIjk, int resolution)
    {
        var coordinate = faceIjk.CoordinateIjk;
        var face = faceIjk.Face;
        
        var index = new H3Index();

        index = index.SetMode(1).SetResolution(resolution);

        if (resolution == 0)
        {
            if (coordinate.I > 2 || coordinate.J > 2 || coordinate.K > 2)
            {
                return new H3Index(0);
            }

            var currentBaseCellRotation =
                BaseCellConstants.FaceIjkBaseCells[face, coordinate.I, coordinate.J, coordinate.K];
            
            return index.SetBaseCell(currentBaseCellRotation.BaseCell);
        }

        var baseCellFaseIjk = CreateBaseCellFaseIjk(faceIjk, resolution, ref index);

        if (baseCellFaseIjk.CoordinateIjk.I > 2 || baseCellFaseIjk.CoordinateIjk.J > 2 ||
            baseCellFaseIjk.CoordinateIjk.K > 2)
        {
            return new H3Index(0);
        }

        var baseCellRotation = BaseCellConstants.FaceIjkBaseCells[baseCellFaseIjk.Face, baseCellFaseIjk.CoordinateIjk.I,
            baseCellFaseIjk.CoordinateIjk.J, baseCellFaseIjk.CoordinateIjk.K];

        index = index.SetBaseCell(baseCellRotation.BaseCell);

        var numRotation = baseCellRotation.Rotation;

        if (BaseCellConstants.BaseCells[baseCellRotation.BaseCell].IsPentagon)
        {
            var leadingNonZeroDigit = index.GetLeadingNonZeroDigit();

            if (leadingNonZeroDigit == Direction.KAxesDigit)
            {
                index = IsCwOffsetBaseCell(baseCellRotation.BaseCell, baseCellFaseIjk.Face)
                    ? index.Rotate60Cw()
                    : index.Rotate60Ccw();
            }

            for (var i = 0; i < numRotation; i++)
            {
                index = index.RotatePent60Ccw();
            }
        }
        else
        {
            for (var i = 0; i < numRotation; i++)
            {
                index = index.Rotate60Ccw();
            }
        }
        
        return index;
    }

    public static FaceIjk H3IndexToFaceIjk(H3Index index)
    {
        var baseCell = index.GetBaseCell();

        if (baseCell is < 0 or >= BaseCellConstants.NumBaseCells)
        {
            return new FaceIjk(0, new CoordinateIjk(0, 0, 0));
        }

        var baseCellData = BaseCellConstants.BaseCells[baseCell];
        var leadingNonZeroDigit = index.GetLeadingNonZeroDigit();

        if (baseCellData.IsPentagon && leadingNonZeroDigit == Direction.IkAxesDigit)
        {
            index = index.Rotate60Cw();
        }

        var resolution = index.GetResolution();
        var faceIjk = baseCellData.HomeFaceIjk;
        
        if (!TryGetInitializedFaceIjk(index, ref faceIjk))
        {
            return faceIjk;
        }


        var origCoordinate = faceIjk.CoordinateIjk;

        if (ResolutionUtils.IsResolutionThirdClass(resolution))
        {
            var newCoordinate = faceIjk.CoordinateIjk.DownAp7Rotated();
            faceIjk = new FaceIjk(faceIjk.Face, newCoordinate);
            resolution++;
        }

        var isPentLeading4 = baseCellData.IsPentagon && index.GetLeadingNonZeroDigit() == Direction.AxesDigit;

        if (AdjustOverageSecondClass(resolution, isPentLeading4, false, ref faceIjk) != Overage.NoOverage)
        {
            if (baseCellData.IsPentagon)
            {
                while (AdjustOverageSecondClass(resolution, false, false, ref faceIjk) != Overage.NoOverage)
                { }
            }

            if (resolution != index.GetResolution())
            {
                var newCoordinate = faceIjk.CoordinateIjk.UpAp7Rotated();

                return new FaceIjk(faceIjk.Face, newCoordinate);
            }
        }
        else if (resolution != index.GetResolution())
        {
            return new FaceIjk(faceIjk.Face, origCoordinate);
        }
        
        return faceIjk;
    }

    private static bool TryGetInitializedFaceIjk(H3Index index, ref FaceIjk faceIjk)
    {
        var baseCell = index.GetBaseCell();
        var resolution = index.GetResolution();
        
        var possibleOverage = !(!BaseCellConstants.BaseCells[baseCell].IsPentagon && (resolution == 0 || faceIjk.CoordinateIjk.IsEmpty()));
        var coordinateIjk = faceIjk.CoordinateIjk;
        
        for (var i = 1; i <= resolution; i++)
        {
            coordinateIjk = ResolutionUtils.IsResolutionThirdClass(i) ? coordinateIjk.DownAp7() : coordinateIjk.DownAp7Rotated();

            var digit = index.GetIndexDigit(i);
            coordinateIjk = coordinateIjk.GetNeighbor(digit);
        }

        faceIjk = new FaceIjk(faceIjk.Face, coordinateIjk);
        
        return possibleOverage;
    }
    
    private static Overage AdjustOverageSecondClass(int resolution, bool isPentLeading4, bool isSubstrate, ref FaceIjk faceIjk)
    {
        var overage = Overage.NoOverage;
        var maxDim = ResolutionConstants.MaxDimBySecondClassResolution[resolution];
        var face = faceIjk.Face;
        var coordinateIjk = faceIjk.CoordinateIjk;
        
        if (isSubstrate)
        {
            maxDim *= 3;
        }
        
        if (isSubstrate && coordinateIjk.I + coordinateIjk.J + coordinateIjk.K == maxDim)
        {
            overage = Overage.FaceEdge;
        }
        else if (coordinateIjk.I + coordinateIjk.J + coordinateIjk.K > maxDim)
        {
            overage = Overage.NewFace;
            
            FaceOrientIjk faceOrientIjk;

            if (coordinateIjk.K > 0)
            {
                if (coordinateIjk.J > 0)
                {
                    faceOrientIjk = FaceOrientIjkConstants.FaceNeighbors[faceIjk.Face, 3]; // JK
                }
                else
                {
                    faceOrientIjk = FaceOrientIjkConstants.FaceNeighbors[faceIjk.Face, 2]; // KI

                    if (isPentLeading4)
                    {
                        var origin = new CoordinateIjk(maxDim, 0, 0);
                        var temp = coordinateIjk - origin;
                        temp = temp.Rotate60Cw();

                        coordinateIjk = temp + origin;
                    }
                }
            }
            else
            {
                faceOrientIjk = FaceOrientIjkConstants.FaceNeighbors[faceIjk.Face, 1]; // IJ
            }
            
            face = faceOrientIjk.Face;
            
            for (var i = 0; i < faceOrientIjk.CcwRotation60; i++)
            {
                coordinateIjk = coordinateIjk.Rotate60Ccw();
            }

            var faceOrientCoordinateIjk = faceOrientIjk.CoordinateIjk;

            var unitScale = ResolutionConstants.UnitScaleBySecondClassResolution[resolution];

            if (isSubstrate)
            {
                unitScale *= 3;
            }

            faceOrientCoordinateIjk *= unitScale;
            coordinateIjk += faceOrientCoordinateIjk;
            coordinateIjk = coordinateIjk.Normalize();
        
            if (isSubstrate && coordinateIjk.I + coordinateIjk.J + coordinateIjk.K == maxDim)
            {
                overage = Overage.FaceEdge;
            }
        }

        faceIjk = new FaceIjk(face, coordinateIjk);
        
        return overage;
    }
    
    private static FaceIjk CreateBaseCellFaseIjk(FaceIjk faceIjk, int resolution, ref H3Index index)
    {
        var coordinate = faceIjk.CoordinateIjk;

        for (var i = resolution - 1; i >= 0; i--)
        {
            var lastCoordinate = coordinate;
            CoordinateIjk lastCenter;

            if (ResolutionUtils.IsResolutionThirdClass(i + 1))
            {
                coordinate = coordinate.UpAp7();
                lastCenter = coordinate.DownAp7();
            }
            else
            {
                coordinate = coordinate.UpAp7Rotated();
                lastCenter = coordinate.DownAp7Rotated();
            }
            
            var diff = (lastCoordinate - lastCenter).Normalize();
            var digit = (int)UnitIjkToDigit(diff);
            
            index = index.SetIndexDigit(i + 1, digit);
        }
        
        return new FaceIjk(faceIjk.Face, coordinate);
    }

    private static Direction UnitIjkToDigit(CoordinateIjk coordinate)
    {
        var normalizedCoordinate = coordinate.Normalize();
        
        var direction = Direction.InvalidDigit;

        for (var i = (int)Direction.CenterDigit; i < DirectionConstants.DirectionCount; i++)
        {
            if (normalizedCoordinate != CoordinateIjkConstants.UnitVectors[i])
            {
                continue;
            }
            
            direction = (Direction)i;
            break;
        }

        return direction;
    }

    private static bool IsCwOffsetBaseCell(int baseCell, int face)
    {
        return BaseCellConstants.BaseCells[baseCell].IsCwOffset(face);
    }
}