using System.Collections.Generic;
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
    
    public static List<H3Index> GetGridDisk(H3Index index, int diskSize)
    {
        if (diskSize < 0)
        {
            return [];
        }

        var result = new List<H3Index> { index };
        var distances = new List<double> { 0d };

        if (index.IsPentagon())
        {
            return [];
        }

        var ring = 1;
        var direction = 0;
        var i = 0;
        var rotations = 0;

        while (ring <= diskSize)
        {
            if ((Direction)direction == Direction.CenterDigit && i == 0)
            {
                if (!TryGetNeighbor(Direction.AxesDigit, ref rotations, ref index) || index.IsPentagon())
                {
                    return [];
                }
            }
            
            if (!TryGetNeighbor(Directions[direction], ref rotations, ref index))
            {
                return result;
            }
            
            result.Add(index);
            distances.Add(ring);

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
                return [];
            }
        }

        return result;
    }

    private static bool TryGetNeighbor(Direction direction, ref int rotations, ref H3Index neighbor)
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
        var oldBaseCell = neighbor.GetBaseCell();

        if (oldBaseCell is < 0 or >= BaseCellConstants.NumBaseCells)
        {
            return false;
        }
        
        var oldLeadingDigit = neighbor.GetLeadingNonZeroDigit();
        var resolution = neighbor.GetResolution() - 1;

        while (true)
        {
            if (resolution == -1)
            {
                neighbor = neighbor.SetBaseCell(BaseCellConstants.BaseCellNeighbors[oldBaseCell, (int)direction]);
                newRotations = BaseCellConstants.BaseCellNeighbor60CcwRots[oldBaseCell, (int)direction];

                if (neighbor.GetBaseCell() == BaseCellConstants.InvalidBaseCell)
                {
                    neighbor = neighbor.SetBaseCell(
                        BaseCellConstants.BaseCellNeighbors[oldBaseCell, (int)Direction.IkAxesDigit]);
                    newRotations = BaseCellConstants.BaseCellNeighbor60CcwRots[oldBaseCell, (int)Direction.IkAxesDigit];

                    neighbor = neighbor.Rotate60Ccw();
                    rotations += 1;
                }
                
                break;
            }

            var oldDigit = neighbor.GetIndexDigit(resolution + 1);
            var oldDirection = (Direction)oldDigit;
            Direction nextDirection;
                
            if (oldDirection == Direction.InvalidDigit)
            {
                return false;
            }

            if (ResolutionUtils.IsResolutionThirdClass(resolution + 1))
            {
                neighbor = neighbor.SetIndexDigit(resolution + 1,
                    DirectionConstants.NewDigitIi[oldDigit, (int)direction]);
                nextDirection = DirectionConstants.NewAdjustmentIi[oldDigit, (int)direction];
            }
            else
            {
                neighbor = neighbor.SetIndexDigit(resolution + 1,
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
        var newBaseCell = neighbor.GetBaseCell();
        var newBaseCellData = BaseCellConstants.BaseCells[newBaseCell];

        if (newBaseCellData.IsPentagon)
        {
            var alreadyAdjustedKSubsequence = 0;

            var leadingNonZeroDigit = neighbor.GetLeadingNonZeroDigit();

            if (leadingNonZeroDigit == Direction.KAxesDigit)
            {
                if (oldBaseCell != newBaseCell)
                {
                    var oldBaseCellData = BaseCellConstants.BaseCells[oldBaseCell];

                    neighbor = newBaseCellData.IsCwOffset(oldBaseCellData.HomeFaceIjk.Face)
                        ? neighbor.Rotate60Cw()
                        : neighbor.Rotate60Ccw();

                    alreadyAdjustedKSubsequence++;
                }
                else
                {
                    switch (oldLeadingDigit)
                    {
                        case Direction.CenterDigit:
                            return false;
                        case Direction.JkAxesDigit:
                            neighbor = neighbor.Rotate60Ccw();
                            rotations++;
                            break;
                        case Direction.IkAxesDigit:
                            neighbor = neighbor.Rotate60Cw();
                            rotations += 5;
                            break;
                        default:
                            return false;
                    }
                }
            }

            for (var i = 0; i < newRotations; i++)
            {
                neighbor = neighbor.RotatePent60Ccw();
            }

            if (oldBaseCell != newBaseCell)
            {
                leadingNonZeroDigit = neighbor.GetLeadingNonZeroDigit();
                
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
                neighbor = neighbor.Rotate60Ccw();
            }
        }

        rotations = (rotations + newRotations) % 6;
        
        return true;
    }
    
    private static bool IsBaseCellPolarPentagon(int baseCell)
    {
        return baseCell is 4 or 117;
    }
}