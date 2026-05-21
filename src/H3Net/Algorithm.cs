using System;
using System.Collections.Generic;
using System.Linq;
using H3Net.Constants;
using H3Net.Enums;
using H3Net.Extensions;
using H3Net.Models;
using H3Net.Utils;

namespace H3Net;

internal static class Algorithm
{
    private static readonly Direction[] Directions =
    [
        Direction.JAxesDigit,
        Direction.JkAxesDigit,
        Direction.KAxesDigit,
        Direction.IkAxesDigit,
        Direction.AxesDigit,
        Direction.IjAxesDigit
    ];
    
    public static IEnumerable<H3Index> TryGetGridDisk(H3Index origin, int diskSize)
    {
        if (TryGridDiskWithoutPentagons(origin, diskSize, out var result))
            return result;

        if (!TryGetMaxIndexesCount(diskSize, out var maxIndexesCount))
        {
            return [];
        }
        
        var newResult = new H3Index[maxIndexesCount];
        var distances = new int[maxIndexesCount];

        return GetGridDiskInternal(origin, diskSize, newResult, distances, maxIndexesCount, 0)
            ? newResult.Where(index => index.ToString() != "0")
            : [];
    }

    private static bool TryGridDiskWithoutPentagons(H3Index index, int diskSize, out List<H3Index> result)
    {
        result = [];
        
        if (diskSize < 0)
        {
            return false;
        }

        result.Add(index);

        if (index.IsPentagon())
        {
            return false;
        }

        var ring = 1;
        var direction = 0;
        var i = 0;
        var rotations = 0;

        while (ring <= diskSize)
        {
            if ((Direction)direction == Direction.CenterDigit && i == 0)
            {
                if (!TryGetNeighbor(index, Direction.AxesDigit, ref rotations, ref index) || index.IsPentagon())
                {
                    return false;
                }
            }
            
            if (!TryGetNeighbor(index, Directions[direction], ref rotations, ref index))
            {
                return true;
            }
            
            result.Add(index);
            i++;

            if (i == ring)
            {
                i = 0;
                direction++;
                if ((Direction)direction == Direction.IjAxesDigit)
                {
                    direction = 0;
                    ring++;
                }
            }

            if (index.IsPentagon())
            {
                return false;
            }
        }

        return true;
    }

    private static bool TryGetNeighbor(H3Index origin, Direction direction, ref int rotations, ref H3Index neighbor)
    {
        if (direction is < Direction.CenterDigit or >= Direction.InvalidDigit)
        {
            return false;
        }

        rotations %= 6;

        for (var i = 0; i < rotations; i++)
        {
            direction = direction.Rotate60Ccw();
        }

        var newRotations = 0;
        var oldBaseCell = origin.GetBaseCell();

        if (oldBaseCell is < 0 or >= BaseCellConstants.NumBaseCells)
        {
            return false;
        }
        
        var oldLeadingDigit = origin.GetLeadingNonZeroDigit();
        var resolution = origin.GetResolution() - 1;

        while (true)
        {
            if (resolution == -1)
            {
                origin = origin.SetBaseCell(BaseCellConstants.BaseCellNeighbors[oldBaseCell, (int)direction]);
                newRotations = BaseCellConstants.BaseCellNeighbor60CcwRots[oldBaseCell, (int)direction];

                if (origin.GetBaseCell() == BaseCellConstants.InvalidBaseCell)
                {
                    origin = origin.SetBaseCell(
                        BaseCellConstants.BaseCellNeighbors[oldBaseCell, (int)Direction.IkAxesDigit]);
                    newRotations = BaseCellConstants.BaseCellNeighbor60CcwRots[oldBaseCell, (int)Direction.IkAxesDigit];

                    origin = origin.Rotate60Ccw();
                    rotations += 1;
                }
                
                break;
            }

            var oldDigit = origin.GetIndexDigit(resolution + 1);
            var oldDirection = (Direction)oldDigit;
            Direction nextDirection;
                
            if (oldDirection == Direction.InvalidDigit)
            {
                return false;
            }

            if (ResolutionUtils.IsResolutionThirdClass(resolution + 1))
            {
                origin = origin.SetIndexDigit(resolution + 1,
                    DirectionConstants.NewDigitIi[oldDigit, (int)direction]);
                nextDirection = DirectionConstants.NewAdjustmentIi[oldDigit, (int)direction];
            }
            else
            {
                origin = origin.SetIndexDigit(resolution + 1,
                    DirectionConstants.NewDigitIii[oldDigit, (int)direction]);
                nextDirection = DirectionConstants.NewAdjustmentIii[oldDigit, (int)direction];
            }

            if (nextDirection != Direction.CenterDigit)
            {
                direction = nextDirection;
                resolution--;
            }
            else
            {
                break;
            }
        }
        var newBaseCell = origin.GetBaseCell();
        var newBaseCellData = BaseCellConstants.BaseCells[newBaseCell];

        if (newBaseCellData.IsPentagon)
        {
            var alreadyAdjustedKSubsequence = 0;

            var leadingNonZeroDigit = origin.GetLeadingNonZeroDigit();

            if (leadingNonZeroDigit == Direction.KAxesDigit)
            {
                if (oldBaseCell != newBaseCell)
                {
                    var oldBaseCellData = BaseCellConstants.BaseCells[oldBaseCell];

                    origin = newBaseCellData.IsCwOffset(oldBaseCellData.HomeFaceIjk.Face)
                        ? origin.Rotate60Cw()
                        : origin.Rotate60Ccw();

                    alreadyAdjustedKSubsequence++;
                }
                else
                {
                    switch (oldLeadingDigit)
                    {
                        case Direction.CenterDigit:
                            return false;
                        case Direction.JkAxesDigit:
                            origin = origin.Rotate60Ccw();
                            rotations++;
                            break;
                        case Direction.IkAxesDigit:
                            origin = origin.Rotate60Cw();
                            rotations += 5;
                            break;
                        default:
                            return false;
                    }
                }
            }

            for (var i = 0; i < newRotations; i++)
            {
                origin = origin.RotatePent60Ccw();
            }

            if (oldBaseCell != newBaseCell)
            {
                leadingNonZeroDigit = origin.GetLeadingNonZeroDigit();
                
                if (IsBaseCellPolarPentagon(newBaseCell))
                {
                    if (oldBaseCell != 118 && oldBaseCell != 8 && leadingNonZeroDigit != Direction.JkAxesDigit)
                    {
                        rotations++;
                    }
                }
                else if (leadingNonZeroDigit == Direction.IkAxesDigit && alreadyAdjustedKSubsequence == 0)
                {
                    rotations++;
                }
            }
        }
        else
        {
            for (var i = 0; i < newRotations; i++)
            {
                origin = origin.Rotate60Ccw();
            }
        }

        neighbor = origin;
        rotations = (rotations + newRotations) % 6;
        
        return true;
    }
    
    private static bool IsBaseCellPolarPentagon(int baseCell)
    {
        return baseCell is 4 or 117;
    }
    
    private static bool TryGetMaxIndexesCount(int diskSize, out long maxIndexesCount)
    {
        maxIndexesCount = 0;
        
        switch (diskSize)
        {
            case < 0:
                return false;
            case >= ResolutionConstants.MaxCellsCount:
                return TryGetNumCells(ResolutionConstants.MaxResolution, out maxIndexesCount);
            default:
                maxIndexesCount = 3L * diskSize * (diskSize + 1L) + 1L;
        
                return true;
        }
    }

    private static bool TryGetNumCells(int res, out long result)
    {
        result = 0;
        
        if (res is < 0 or > ResolutionConstants.MaxResolution)
        {
            return false;
        }

        result = 2L + 120L * (long)Math.Pow(7, res);
        
        return true;
    }
    
    private static bool GetGridDiskInternal(
        H3Index origin, 
        int diskSize,
        H3Index[] result,
        int[] distances, 
        long maxIndexesCount, 
        int currentDiskSize)
    {
        var off = (long)(origin.Value % (ulong)maxIndexesCount);

        while (result[off].Value != 0 && result[off].Value != origin.Value)
        {
            off = (off + 1) % maxIndexesCount;
        }

        if (result[off].Value == origin.Value && distances[off] <= currentDiskSize)
        {
            return true;
        }

        result[off] = origin;
        distances[off] = currentDiskSize;

        if (currentDiskSize >= diskSize)
        {
            return true;
        }

        for (var i = 0; i < 6; i++)
        {
            var rotations = 0;
            var nextNeighbor = default(H3Index);

            var success = TryGetNeighbor(origin, Directions[i], ref rotations, ref nextNeighbor);

            if (!success)
            {
                continue;
            }
            
            if (!GetGridDiskInternal(nextNeighbor, diskSize, result, distances, maxIndexesCount, currentDiskSize + 1))
            {
                return false;
            }
        }

        return true;
    }
}