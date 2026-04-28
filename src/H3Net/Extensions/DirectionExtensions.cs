using H3Net.Enums;

namespace H3Net.Extensions;

internal static class DirectionExtensions
{
    public static Direction Rotate60Cw(this Direction direction)
    {
        return direction switch
        {
            Direction.KAxesDigit => Direction.JkAxesDigit,
            Direction.JkAxesDigit => Direction.JAxesDigit,
            Direction.JAxesDigit => Direction.IjAxesDigit,
            Direction.IjAxesDigit => Direction.AxesDigit,
            Direction.AxesDigit => Direction.IkAxesDigit,
            Direction.IkAxesDigit => Direction.KAxesDigit,
            _ => direction
        };
    }
    
    public static Direction Rotate60Ccw(this Direction direction)
    {
        return direction switch
        {
            Direction.KAxesDigit => Direction.IkAxesDigit,
            Direction.IkAxesDigit => Direction.AxesDigit,
            Direction.AxesDigit => Direction.IjAxesDigit,
            Direction.IjAxesDigit => Direction.JAxesDigit,
            Direction.JAxesDigit => Direction.JkAxesDigit,
            Direction.JkAxesDigit => Direction.KAxesDigit,
            _ => direction
        };
    }
}