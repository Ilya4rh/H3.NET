using System;
using H3Net.Constants;
using H3Net.Enums;

namespace H3Net.Models;

internal readonly struct CoordinateIjk : IEquatable<CoordinateIjk>
{
    public readonly int I;
    
    public readonly int J;
    
    public readonly int K;

    public CoordinateIjk(int i, int j, int k)
    {
        I = i;
        J = j;
        K = k;
    }

    private const double OneSeventh = 1.0 / 7.0;

    private static readonly CoordinateIjk[] Ap7DownBasis =
    [
        new(3, 0, 1),
        new(1, 3, 0),
        new(0, 1, 3)
    ];

    private static readonly CoordinateIjk[] Ap7DownBasisRotated =
    [
        new(3, 1, 0),
        new(0, 3, 1),
        new(1, 0, 3)
    ];
    
    private static readonly CoordinateIjk[] Ap3DownBasis =
    [
        new(2, 0, 1),
        new(1, 2, 0),
        new(0, 1, 2)
    ];
    
    private static readonly CoordinateIjk[] Ap3DownBasisRotated =
    [
        new(2, 1, 0),
        new(0, 2, 1),
        new(1, 0, 2)
    ];
    
    public CoordinateIjk UpAp7()
    {
        var i = I - K;
        var j = J - K;

        var newI = Round((3 * i - j) * OneSeventh);
        var newJ = Round((i + 2 * j) * OneSeventh);

        return new CoordinateIjk(newI, newJ, 0).Normalize();
    }

    public CoordinateIjk UpAp7Rotated()
    {
        var i = I - K;
        var j = J - K;

        var newI = Round((2 * i + j) * OneSeventh);
        var newJ = Round((3 * j - i) * OneSeventh);

        return new CoordinateIjk(newI, newJ, 0).Normalize();
    }

    public CoordinateIjk DownAp3()
    {
        var i = Ap3DownBasis[0] * I;
        var j = Ap3DownBasis[1] * J;
        var k = Ap3DownBasis[2] * K;

        var newCoordinate = i + j + k;

        return newCoordinate.Normalize();
    }
    
    public CoordinateIjk DownAp3Rotated()
    {
        var i = Ap3DownBasisRotated[0] * I;
        var j = Ap3DownBasisRotated[1] * J;
        var k = Ap3DownBasisRotated[2] * K;

        var newCoordinate = i + j + k;

        return newCoordinate.Normalize();
    }
    
    public CoordinateIjk Normalize()
    {
        var i = I;
        var j = J;
        var k = K;

        if (i < 0)
        {
            j -= i;
            k -= i;
            i = 0;
        }

        if (j < 0)
        {
            i -= j;
            k -= j;
            j = 0;
        }

        if (k < 0)
        {
            i -= k;
            j -= k;
            k = 0;
        }

        var min = i;
        if (j < min) min = j;
        if (k < min) min = k;

        if (min > 0)
        {
            i -= min;
            j -= min;
            k -= min;
        }

        return new CoordinateIjk(i, j, k);
    }
    
    public CoordinateIjk DownAp7()
    {
        var iVec = Ap7DownBasis[0] * I;
        var jVec = Ap7DownBasis[1] * J;
        var kVec = Ap7DownBasis[2] * K;

        var result = iVec + jVec + kVec;

        return result.Normalize();
    }
    
    public CoordinateIjk DownAp7Rotated()
    {
        var iVec = Ap7DownBasisRotated[0] * I;
        var jVec = Ap7DownBasisRotated[1] * J;
        var kVec = Ap7DownBasisRotated[2] * K;

        var result = iVec + jVec + kVec;

        return result.Normalize();
    }

    public static CoordinateIjk operator +(CoordinateIjk coordinate1, CoordinateIjk coordinate2)
    {
        var i = coordinate1.I + coordinate2.I;
        var j = coordinate1.J + coordinate2.J;
        var k = coordinate1.K + coordinate2.K;
        
        return new CoordinateIjk(i, j, k);
    }

    public static CoordinateIjk operator -(CoordinateIjk coordinate1, CoordinateIjk coordinate2)
    {
        var i = coordinate1.I - coordinate2.I;
        var j = coordinate1.J - coordinate2.J;
        var k = coordinate1.K - coordinate2.K;
        
        return new CoordinateIjk(i, j, k);
    }

    public static bool operator ==(CoordinateIjk coordinate1, CoordinateIjk coordinate2)
    {
        return coordinate1.I == coordinate2.I && coordinate1.J == coordinate2.J && coordinate1.K == coordinate2.K;
    }

    public static bool operator !=(CoordinateIjk coordinate1, CoordinateIjk coordinate2)
    {
        return !(coordinate1 == coordinate2);
    }
    
    public static CoordinateIjk operator *(CoordinateIjk coordinate, int factor)
    {
        var i = coordinate.I * factor;
        var j = coordinate.J * factor;
        var k = coordinate.K * factor; 
        
        return new CoordinateIjk(i, j, k);
    }
    
    public bool Equals(CoordinateIjk other)
    {
        return I == other.I && J == other.J && K == other.K;
    }

    public override bool Equals(object? obj)
    {
        return obj is CoordinateIjk other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(I, J, K);
    }
    
    public bool IsEmpty()
    {
        return I == 0 && J == 0 && K == 0;
    }

    public CoordinateIjk GetNeighbor(int digit)
    {
        if (digit is > (int)Direction.CenterDigit and < DirectionConstants.DirectionCount)
        {
            var neighbor = this + CoordinateIjkConstants.UnitVectors[digit];

            return neighbor.Normalize();
        }
        
        return this;
    }

    public CoordinateIjk Rotate60Cw()
    {
        var iVec = new CoordinateIjk(1, 0, 1);
        var jVec = new CoordinateIjk(1, 1, 0);
        var kVec = new CoordinateIjk(0, 1, 1);

        iVec *= I;
        jVec *= J;
        kVec *= K;

        var result = iVec + jVec + kVec;

        return result.Normalize();
    }

    public CoordinateIjk Rotate60Ccw()
    {
        var iVec = new CoordinateIjk(1, 1, 0);
        var jVec = new CoordinateIjk(0, 1, 1);
        var kVec = new CoordinateIjk(1, 0, 1);

        iVec *= I;
        jVec *= J;
        kVec *= K;

        var result = iVec + jVec + kVec;

        return result.Normalize();
    }
    
    private static int Round(double value)
    {
        return (int)Math.Round(value, MidpointRounding.AwayFromZero);
    }
}