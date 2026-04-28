using H3Net.Enums;

namespace H3Net.Constants;

internal static class DirectionConstants
{
    public const int DirectionCount = 7;
    
    public static readonly Direction[,] NewDigitIi =
    {
        {Direction.CenterDigit, Direction.KAxesDigit, Direction.JAxesDigit, Direction.JkAxesDigit, Direction.AxesDigit, Direction.IkAxesDigit, Direction.IjAxesDigit},
        {Direction.KAxesDigit, Direction.AxesDigit, Direction.JkAxesDigit, Direction.IjAxesDigit, Direction.IkAxesDigit, Direction.JAxesDigit, Direction.CenterDigit},
        {Direction.JAxesDigit, Direction.JkAxesDigit, Direction.KAxesDigit, Direction.AxesDigit, Direction.IjAxesDigit, Direction.CenterDigit, Direction.IkAxesDigit},
        {Direction.JkAxesDigit, Direction.IjAxesDigit, Direction.AxesDigit, Direction.IkAxesDigit, Direction.CenterDigit, Direction.KAxesDigit, Direction.JAxesDigit},
        {Direction.AxesDigit, Direction.IkAxesDigit, Direction.IjAxesDigit, Direction.CenterDigit, Direction.JAxesDigit, Direction.JkAxesDigit, Direction.KAxesDigit},
        {Direction.IkAxesDigit, Direction.JAxesDigit, Direction.CenterDigit, Direction.KAxesDigit, Direction.JkAxesDigit, Direction.IjAxesDigit, Direction.AxesDigit},
        {Direction.IjAxesDigit, Direction.CenterDigit, Direction.IkAxesDigit, Direction.JAxesDigit, Direction.KAxesDigit, Direction.AxesDigit, Direction.JkAxesDigit}
    };
    
    public static readonly Direction[,] NewAdjustmentIi =
    {
        {Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit},
        {Direction.CenterDigit, Direction.KAxesDigit, Direction.CenterDigit, Direction.KAxesDigit, Direction.CenterDigit, Direction.IkAxesDigit, Direction.CenterDigit},
        {Direction.CenterDigit, Direction.CenterDigit, Direction.JAxesDigit, Direction.JkAxesDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.JAxesDigit},
        {Direction.CenterDigit, Direction.KAxesDigit, Direction.JkAxesDigit, Direction.JkAxesDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit},
        {Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.AxesDigit, Direction.AxesDigit, Direction.IjAxesDigit},
        {Direction.CenterDigit, Direction.IkAxesDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.AxesDigit, Direction.IkAxesDigit, Direction.CenterDigit},
        {Direction.CenterDigit, Direction.CenterDigit, Direction.JAxesDigit, Direction.CenterDigit, Direction.IjAxesDigit, Direction.CenterDigit, Direction.IjAxesDigit}
    };
    
    public static readonly Direction[,] NewDigitIii =
    {
        {Direction.CenterDigit, Direction.KAxesDigit, Direction.JAxesDigit, Direction.JkAxesDigit, Direction.AxesDigit, Direction.IkAxesDigit, Direction.IjAxesDigit},
        {Direction.KAxesDigit, Direction.JAxesDigit, Direction.JkAxesDigit, Direction.AxesDigit, Direction.IkAxesDigit, Direction.IjAxesDigit, Direction.CenterDigit},
        {Direction.JAxesDigit, Direction.JkAxesDigit, Direction.AxesDigit, Direction.IkAxesDigit, Direction.IjAxesDigit, Direction.CenterDigit, Direction.KAxesDigit},
        {Direction.JkAxesDigit, Direction.AxesDigit, Direction.IkAxesDigit, Direction.IjAxesDigit, Direction.CenterDigit, Direction.KAxesDigit, Direction.JAxesDigit},
        {Direction.AxesDigit, Direction.IkAxesDigit, Direction.IjAxesDigit, Direction.CenterDigit, Direction.KAxesDigit, Direction.JAxesDigit, Direction.JkAxesDigit},
        {Direction.IkAxesDigit, Direction.IjAxesDigit, Direction.CenterDigit, Direction.KAxesDigit, Direction.JAxesDigit, Direction.JkAxesDigit, Direction.AxesDigit},
        {Direction.IjAxesDigit, Direction.CenterDigit, Direction.KAxesDigit, Direction.JAxesDigit, Direction.JkAxesDigit, Direction.AxesDigit, Direction.IkAxesDigit}
    };
    
    public static readonly Direction[,] NewAdjustmentIii =
    {
        {Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit},
        {Direction.CenterDigit, Direction.KAxesDigit, Direction.CenterDigit, Direction.JkAxesDigit, Direction.CenterDigit, Direction.KAxesDigit, Direction.CenterDigit},
        {Direction.CenterDigit, Direction.CenterDigit, Direction.JAxesDigit, Direction.JAxesDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.IjAxesDigit},
        {Direction.CenterDigit, Direction.JkAxesDigit, Direction.JAxesDigit, Direction.JkAxesDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit},
        {Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.AxesDigit, Direction.IkAxesDigit, Direction.AxesDigit},
        {Direction.CenterDigit, Direction.KAxesDigit, Direction.CenterDigit, Direction.CenterDigit, Direction.IkAxesDigit, Direction.IkAxesDigit, Direction.CenterDigit},
        {Direction.CenterDigit, Direction.CenterDigit, Direction.IjAxesDigit, Direction.CenterDigit, Direction.AxesDigit, Direction.CenterDigit, Direction.IjAxesDigit}
    };
}