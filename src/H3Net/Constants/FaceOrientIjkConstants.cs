using H3Net.Models;

namespace H3Net.Constants;

internal static class FaceOrientIjkConstants
{
    public static readonly FaceOrientIjk[,] FaceNeighbors = 
    {
        {
            // face 0
            new(0, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(4, new CoordinateIjk(2, 0, 2), 1),  // ij quadrant
            new(1, new CoordinateIjk(2, 2, 0), 5),  // ki quadrant
            new(5, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 1
            new(1, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(0, new CoordinateIjk(2, 0, 2), 1),  // ij quadrant
            new(2, new CoordinateIjk(2, 2, 0), 5),  // ki quadrant
            new(6, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 2
            new(2, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(1, new CoordinateIjk(2, 0, 2), 1),  // ij quadrant
            new(3, new CoordinateIjk(2, 2, 0), 5),  // ki quadrant
            new(7, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 3
            new(3, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(2, new CoordinateIjk(2, 0, 2), 1),  // ij quadrant
            new(4, new CoordinateIjk(2, 2, 0), 5),  // ki quadrant
            new(8, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 4
            new(4, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(3, new CoordinateIjk(2, 0, 2), 1),  // ij quadrant
            new(0, new CoordinateIjk(2, 2, 0), 5),  // ki quadrant
            new(9, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 5
            new(5, new CoordinateIjk(0, 0, 0), 0),   // central face
            new(10, new CoordinateIjk(2, 2, 0), 3),  // ij quadrant
            new(14, new CoordinateIjk(2, 0, 2), 3),  // ki quadrant
            new(0, new CoordinateIjk(0, 2, 2), 3)    // jk quadrant
        },
        {
            // face 6
            new(6, new CoordinateIjk(0, 0, 0), 0),   // central face
            new(11, new CoordinateIjk(2, 2, 0), 3),  // ij quadrant
            new(10, new CoordinateIjk(2, 0, 2), 3),  // ki quadrant
            new(1, new CoordinateIjk(0, 2, 2), 3)    // jk quadrant
        },
        {
            // face 7
            new(7, new CoordinateIjk(0, 0, 0), 0),   // central face
            new(12, new CoordinateIjk(2, 2, 0), 3),  // ij quadrant
            new(11, new CoordinateIjk(2, 0, 2), 3),  // ki quadrant
            new(2, new CoordinateIjk(0, 2, 2), 3)    // jk quadrant
        },
        {
            // face 8
            new(8, new CoordinateIjk(0, 0, 0), 0),   // central face
            new(13, new CoordinateIjk(2, 2, 0), 3),  // ij quadrant
            new(12, new CoordinateIjk(2, 0, 2), 3),  // ki quadrant
            new(3, new CoordinateIjk(0, 2, 2), 3)    // jk quadrant
        },
        {
            // face 9
            new(9, new CoordinateIjk(0, 0, 0), 0),   // central face
            new(14, new CoordinateIjk(2, 2, 0), 3),  // ij quadrant
            new(13, new CoordinateIjk(2, 0, 2), 3),  // ki quadrant
            new(4, new CoordinateIjk(0, 2, 2), 3)    // jk quadrant
        },
        {
            // face 10
            new(10, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(5, new CoordinateIjk(2, 2, 0), 3),   // ij quadrant
            new(6, new CoordinateIjk(2, 0, 2), 3),   // ki quadrant
            new(15, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 11
            new(11, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(6, new CoordinateIjk(2, 2, 0), 3),   // ij quadrant
            new(7, new CoordinateIjk(2, 0, 2), 3),   // ki quadrant
            new(16, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 12
            new(12, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(7, new CoordinateIjk(2, 2, 0), 3),   // ij quadrant
            new(8, new CoordinateIjk(2, 0, 2), 3),   // ki quadrant
            new(17, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 13
            new(13, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(8, new CoordinateIjk(2, 2, 0), 3),   // ij quadrant
            new(9, new CoordinateIjk(2, 0, 2), 3),   // ki quadrant
            new(18, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 14
            new(14, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(9, new CoordinateIjk(2, 2, 0), 3),   // ij quadrant
            new(5, new CoordinateIjk(2, 0, 2), 3),   // ki quadrant
            new(19, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 15
            new(15, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(16, new CoordinateIjk(2, 0, 2), 1),  // ij quadrant
            new(19, new CoordinateIjk(2, 2, 0), 5),  // ki quadrant
            new(10, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 16
            new(16, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(17, new CoordinateIjk(2, 0, 2), 1),  // ij quadrant
            new(15, new CoordinateIjk(2, 2, 0), 5),  // ki quadrant
            new(11, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 17
            new(17, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(18, new CoordinateIjk(2, 0, 2), 1),  // ij quadrant
            new(16, new CoordinateIjk(2, 2, 0), 5),  // ki quadrant
            new(12, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 18
            new(18, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(19, new CoordinateIjk(2, 0, 2), 1),  // ij quadrant
            new(17, new CoordinateIjk(2, 2, 0), 5),  // ki quadrant
            new(13, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        },
        {
            // face 19
            new(19, new CoordinateIjk(0, 0, 0), 0),  // central face
            new(15, new CoordinateIjk(2, 0, 2), 1),  // ij quadrant
            new(18, new CoordinateIjk(2, 2, 0), 5),  // ki quadrant
            new(14, new CoordinateIjk(0, 2, 2), 3)   // jk quadrant
        }
    };
}