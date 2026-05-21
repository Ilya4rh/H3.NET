namespace H3Net.Constants;

internal static class ResolutionConstants
{
    public const int MaxCellsCount = 13780510;

    public const int MaxResolution = 15;
    
    public static readonly int[] MaxDimBySecondClassResolution =
    [
        2,        // res  0
        -1,       // res  1
        14,       // res  2
        -1,       // res  3
        98,       // res  4
        -1,       // res  5
        686,      // res  6
        -1,       // res  7
        4802,     // res  8
        -1,       // res  9
        33614,    // res 10
        -1,       // res 11
        235298,   // res 12
        -1,       // res 13
        1647086,  // res 14
        -1,       // res 15
        11529602  // res 16
    ];
    
    public static readonly int[] UnitScaleBySecondClassResolution =
    [
        1,       // res  0
        -1,      // res  1
        7,       // res  2
        -1,      // res  3
        49,      // res  4
        -1,      // res  5
        343,     // res  6
        -1,      // res  7
        2401,    // res  8
        -1,      // res  9
        16807,   // res 10
        -1,      // res 11
        117649,  // res 12
        -1,      // res 13
        823543,  // res 14
        -1,      // res 15
        5764801  // res 16
    ];
}