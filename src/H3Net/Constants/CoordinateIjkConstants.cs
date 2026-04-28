using H3Net.Models;

namespace H3Net.Constants;

internal static class CoordinateIjkConstants
{
    public static readonly CoordinateIjk[] UnitVectors =
    [
        new(0, 0, 0),  // direction 0
        new(0, 0, 1),  // direction 1
        new(0, 1, 0),  // direction 2
        new(0, 1, 1),  // direction 3
        new(1, 0, 0),  // direction 4
        new(1, 0, 1),  // direction 5
        new(1, 1, 0)   // direction 6
    ];
}