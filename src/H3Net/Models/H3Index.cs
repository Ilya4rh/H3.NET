using H3Net.Constants;
using H3Net.Enums;
using H3Net.Extensions;

namespace H3Net.Models;

public readonly struct H3Index
{
    public ulong Value { get; }

    public H3Index()
    {
        Value = Init;
    }

    public H3Index(ulong value)
    {
        Value = value;
    }

    private const int H3NumBits = 64;
    private const int H3MaxOffset = 63;
    private const int H3ModeOffset = 59;
    private const int H3BcOffset = 45;
    private const int H3ResOffset = 52;
    private const int H3ReservedOffset = 56;
    private const int H3PerDigitOffset = 3;
    
    private const int MaxH3Res = 15;

    private const ulong H3HighBitMask = 1UL << H3MaxOffset;
    private const ulong H3HighBitMaskNegative = ~H3HighBitMask;

    private const ulong H3ModeMask = 15UL << H3ModeOffset;
    private const ulong H3ModeMaskNegative = ~H3ModeMask;

    private const ulong H3BcMask = 127UL << H3BcOffset;
    private const ulong H3BcMaskNegative = ~H3BcMask;

    private const ulong H3ResMask = 15UL << H3ResOffset;
    private const ulong H3ResMaskNegative = ~H3ResMask;

    private const ulong H3ReservedMask = 7UL << H3ReservedOffset;
    private const ulong H3ReservedMaskNegative = ~H3ReservedMask;

    private const ulong H3DigitMask = 7UL;
    private const ulong H3DigitMaskNegative = ~H3DigitMask;

    private const ulong Init = 35184372088831UL;

    public int GetHighBit()
    {
        return (int)((Value & H3HighBitMask) >> H3MaxOffset);
    }

    public H3Index SetHighBit(int value)
    {
        var newIndex = (Value & H3HighBitMaskNegative) | ((ulong)value << H3MaxOffset);

        return new H3Index(newIndex);
    }

    public int GetMode()
    {
        return (int)((Value & H3ModeMask) >> H3ModeOffset);
    }

    public H3Index SetMode(int value)
    {
        var newIndex = (Value & H3ModeMaskNegative) | ((ulong)value << H3ModeOffset);

        return new H3Index(newIndex);
    }

    public int GetBaseCell()
    {
        return (int)((Value & H3BcMask) >> H3BcOffset);
    }

    public H3Index SetBaseCell(int bc)
    {
        return new H3Index((Value & H3BcMaskNegative) | ((ulong)bc << H3BcOffset));
    }

    public int GetResolution()
    {
        return (int)((Value & H3ResMask) >> H3ResOffset);
    }

    public H3Index SetResolution(int res)
    {
        return new H3Index((Value & H3ResMaskNegative) |
                           ((ulong)res << H3ResOffset));
    }

    public int GetReservedBits()
    {
        return (int)((Value & H3ReservedMask) >> H3ReservedOffset);
    }

    public H3Index SetReservedBits(int value)
    {
        return new H3Index((Value & H3ReservedMaskNegative) |
                           ((ulong)value << H3ReservedOffset));
    }

    public int GetIndexDigit(int res)
    {
        var shift = (MaxH3Res - res) * H3PerDigitOffset;

        return (int)((Value >> shift) & H3DigitMask);
    }

    public bool IsPentagon()
    {
        var baseCell = GetBaseCell();
        var baseCellData = BaseCellConstants.BaseCells[baseCell];

        var leadingNonZeroDigit = GetLeadingNonZeroDigit();

        return baseCellData.IsPentagon && leadingNonZeroDigit == Direction.CenterDigit;
    }
    
    internal Direction GetLeadingNonZeroDigit()
    {
        var resolution = GetResolution();

        for (var i = 1; i <= resolution; i++)
        {
            var digit = GetIndexDigit(i);

            if (digit != 0)
            {
                return (Direction)digit;
            }
        }

        return Direction.CenterDigit;
    }

    public H3Index SetIndexDigit(int res, int digit)
    {
        var shift = (MaxH3Res - res) * H3PerDigitOffset;

        var mask = H3DigitMask << shift;

        return new H3Index((Value & ~mask) | ((ulong)digit << shift));
    }
    
    internal H3Index SetIndexDigit(int res, Direction direction)
    {
        return SetIndexDigit(res, (int)direction);
    }
    
    public H3Index Rotate60Cw()
    {
        var index = this;
        var resolution = GetResolution();

        for (var i = 1; i <= resolution; i++)
        {
            var digit = (Direction)index.GetIndexDigit(i);
            var direction = digit.Rotate60Cw();
            index = index.SetIndexDigit(i, (int)direction);
        }

        return index;
    }
    
    public H3Index Rotate60Ccw()
    {
        var index = this;
        var resolution = index.GetResolution();

        for (var i = 1; i <= resolution; i++)
        {
            var digit = (Direction) index.GetIndexDigit(i);
            var direction = digit.Rotate60Ccw();
            index = index.SetIndexDigit(i, (int)direction);
        }

        return index;
    }

    public H3Index RotatePent60Ccw()
    {
        var index = this;
        var resolution = index.GetResolution();
        var isFoundFirstNonZeroDigit = false;

        for (var i = 1; i <= resolution; i++)
        {
            var digit = (Direction)index.GetIndexDigit(i);
            index = index.SetIndexDigit(i, (int)digit.Rotate60Ccw());

            if (!isFoundFirstNonZeroDigit && index.GetIndexDigit(i) != 0)
            {
                isFoundFirstNonZeroDigit = true;

                if (index.GetLeadingNonZeroDigit() == Direction.KAxesDigit)
                {
                    index = index.Rotate60Ccw();
                }
            }
        }

        return index;
    }

    public override string ToString()
    {
        return Value.ToString("x");
    }
}