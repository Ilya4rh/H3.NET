using H3Net.Models;

namespace H3Net.Constants;

internal static class BaseCellConstants
{
    public const int NumBaseCells = 122;

    public const int InvalidBaseCell = 127;
    
    public static readonly BaseCellRotation[,,,] FaceIjkBaseCells =
    {
        {
            // face 0
            {
                // i 0
                { new(16, 0), new(18, 0), new(24, 0) }, // j 0
                { new(33, 0), new(30, 0), new(32, 3) }, // j 1
                { new(49, 1), new(48, 3), new(50, 3) } // j 2
            },
            {
                // i 1
                { new(8, 0), new(5, 5), new(10, 5) }, // j 0
                { new(22, 0), new(16, 0), new(18, 0) }, // j 1
                { new(41, 1), new(33, 0), new(30, 0) } // j 2
            },
            {
                // i 2
                { new(4, 0), new(0, 5), new(2, 5) }, // j 0
                { new(15, 1), new(8, 0), new(5, 5) }, // j 1
                { new(31, 1), new(22, 0), new(16, 0) } // j 2
            }
        },
        {
            // face 1
            {
                // i 0
                { new(2, 0), new(6, 0), new(14, 0) }, // j 0
                { new(10, 0), new(11, 0), new(17, 3) }, // j 1
                { new(24, 1), new(23, 3), new(25, 3) } // j 2
            },
            {
                // i 1
                { new(0, 0), new(1, 5), new(9, 5) }, // j 0
                { new(5, 0), new(2, 0), new(6, 0) }, // j 1
                { new(18, 1), new(10, 0), new(11, 0) } // j 2
            },
            {
                // i 2
                { new(4, 1), new(3, 5), new(7, 5) }, // j 0
                { new(8, 1), new(0, 0), new(1, 5) }, // j 1
                { new(16, 1), new(5, 0), new(2, 0) } // j 2
            }
        },
        {
            // face 2
            {
                // i 0
                { new(7, 0), new(21, 0), new(38, 0) }, // j 0
                { new(9, 0), new(19, 0), new(34, 3) }, // j 1
                { new(14, 1), new(20, 3), new(36, 3) } // j 2
            },
            {
                // i 1
                { new(3, 0), new(13, 5), new(29, 5) }, // j 0
                { new(1, 0), new(7, 0), new(21, 0) }, // j 1
                { new(6, 1), new(9, 0), new(19, 0) } // j 2
            },
            {
                // i 2
                { new(4, 2), new(12, 5), new(26, 5) }, // j 0
                { new(0, 1), new(3, 0), new(13, 5) }, // j 1
                { new(2, 1), new(1, 0), new(7, 0) } // j 2
            }
        },
        {
            // face 3
            {
                // i 0
                { new(26, 0), new(42, 0), new(58, 0) }, // j 0
                { new(29, 0), new(43, 0), new(62, 3) }, // j 1
                { new(38, 1), new(47, 3), new(64, 3) } // j 2
            },
            {
                // i 1
                { new(12, 0), new(28, 5), new(44, 5) }, // j 0
                { new(13, 0), new(26, 0), new(42, 0) }, // j 1
                { new(21, 1), new(29, 0), new(43, 0) } // j 2
            },
            {
                // i 2
                { new(4, 3), new(15, 5), new(31, 5) }, // j 0
                { new(3, 1), new(12, 0), new(28, 5) }, // j 1
                { new(7, 1), new(13, 0), new(26, 0) } // j 2
            }
        },
        {
            // face 4
            {
                // i 0
                { new(31, 0), new(41, 0), new(49, 0) }, // j 0
                { new(44, 0), new(53, 0), new(61, 3) }, // j 1
                { new(58, 1), new(65, 3), new(75, 3) } // j 2
            },
            {
                // i 1
                { new(15, 0), new(22, 5), new(33, 5) }, // j 0
                { new(28, 0), new(31, 0), new(41, 0) }, // j 1
                { new(42, 1), new(44, 0), new(53, 0) } // j 2
            },
            {
                // i 2
                { new(4, 4), new(8, 5), new(16, 5) }, // j 0
                { new(12, 1), new(15, 0), new(22, 5) }, // j 1
                { new(26, 1), new(28, 0), new(31, 0) } // j 2
            }
        },
        {
            // face 5
            {
                // i 0
                { new(50, 0), new(48, 0), new(49, 3) }, // j 0
                { new(32, 0), new(30, 3), new(33, 3) }, // j 1
                { new(24, 3), new(18, 3), new(16, 3) } // j 2
            },
            {
                // i 1
                { new(70, 0), new(67, 0), new(66, 3) }, // j 0
                { new(52, 3), new(50, 0), new(48, 0) }, // j 1
                { new(37, 3), new(32, 0), new(30, 3) } // j 2
            },
            {
                // i 2
                { new(83, 0), new(87, 3), new(85, 3) }, // j 0
                { new(74, 3), new(70, 0), new(67, 0) }, // j 1
                { new(57, 1), new(52, 3), new(50, 0) } // j 2
            }
        },
        {
            // face 6
            {
                // i 0
                { new(25, 0), new(23, 0), new(24, 3) }, // j 0
                { new(17, 0), new(11, 3), new(10, 3) }, // j 1
                { new(14, 3), new(6, 3), new(2, 3) } // j 2
            },
            {
                // i 1
                { new(45, 0), new(39, 0), new(37, 3) }, // j 0
                { new(35, 3), new(25, 0), new(23, 0) }, // j 1
                { new(27, 3), new(17, 0), new(11, 3) } // j 2
            },
            {
                // i 2
                { new(63, 0), new(59, 3), new(57, 3) }, // j 0
                { new(56, 3), new(45, 0), new(39, 0) }, // j 1
                { new(46, 3), new(35, 3), new(25, 0) } // j 2
            }
        },
        {
            // face 7
            {
                // i 0
                { new(36, 0), new(20, 0), new(14, 3) }, // j 0
                { new(34, 0), new(19, 3), new(9, 3) }, // j 1
                { new(38, 3), new(21, 3), new(7, 3) } // j 2
            },
            {
                // i 1
                { new(55, 0), new(40, 0), new(27, 3) }, // j 0
                { new(54, 3), new(36, 0), new(20, 0) }, // j 1
                { new(51, 3), new(34, 0), new(19, 3) } // j 2
            },
            {
                // i 2
                { new(72, 0), new(60, 3), new(46, 3) }, // j 0
                { new(73, 3), new(55, 0), new(40, 0) }, // j 1
                { new(71, 3), new(54, 3), new(36, 0) } // j 2
            }
        },
        {
            // face 8
            {
                // i 0
                { new(64, 0), new(47, 0), new(38, 3) }, // j 0
                { new(62, 0), new(43, 3), new(29, 3) }, // j 1
                { new(58, 3), new(42, 3), new(26, 3) } // j 2
            },
            {
                // i 1
                { new(84, 0), new(69, 0), new(51, 3) }, // j 0
                { new(82, 3), new(64, 0), new(47, 0) }, // j 1
                { new(76, 3), new(62, 0), new(43, 3) } // j 2
            },
            {
                // i 2
                { new(97, 0), new(89, 3), new(71, 3) }, // j 0
                { new(98, 3), new(84, 0), new(69, 0) }, // j 1
                { new(96, 3), new(82, 3), new(64, 0) } // j 2
            }
        },
        {
            // face 9
            {
                // i 0
                { new(75, 0), new(65, 0), new(58, 3) }, // j 0
                { new(61, 0), new(53, 3), new(44, 3) }, // j 1
                { new(49, 3), new(41, 3), new(31, 3) } // j 2
            },
            {
                // i 1
                { new(94, 0), new(86, 0), new(76, 3) }, // j 0
                { new(81, 3), new(75, 0), new(65, 0) }, // j 1
                { new(66, 3), new(61, 0), new(53, 3) } // j 2
            },
            {
                // i 2
                { new(107, 0), new(104, 3), new(96, 3) }, // j 0
                { new(101, 3), new(94, 0), new(86, 0) }, // j 1
                { new(85, 3), new(81, 3), new(75, 0) } // j 2
            }
        },
        {
            // face 10
            {
                // i 0
                { new(57, 0), new(59, 0), new(63, 3) }, // j 0
                { new(74, 0), new(78, 3), new(79, 3) }, // j 1
                { new(83, 3), new(92, 3), new(95, 3) } // j 2
            },
            {
                // i 1
                { new(37, 0), new(39, 3), new(45, 3) }, // j 0
                { new(52, 0), new(57, 0), new(59, 0) }, // j 1
                { new(70, 3), new(74, 0), new(78, 3) } // j 2
            },
            {
                // i 2
                { new(24, 0), new(23, 3), new(25, 3) }, // j 0
                { new(32, 3), new(37, 0), new(39, 3) }, // j 1
                { new(50, 3), new(52, 0), new(57, 0) } // j 2
            }
        },
        {
            // face 11
            {
                // i 0
                { new(46, 0), new(60, 0), new(72, 3) }, // j 0
                { new(56, 0), new(68, 3), new(80, 3) }, // j 1
                { new(63, 3), new(77, 3), new(90, 3) } // j 2
            },
            {
                // i 1
                { new(27, 0), new(40, 3), new(55, 3) }, // j 0
                { new(35, 0), new(46, 0), new(60, 0) }, // j 1
                { new(45, 3), new(56, 0), new(68, 3) } // j 2
            },
            {
                // i 2
                { new(14, 0), new(20, 3), new(36, 3) }, // j 0
                { new(17, 3), new(27, 0), new(40, 3) }, // j 1
                { new(25, 3), new(35, 0), new(46, 0) } // j 2
            }
        },
        {
            // face 12
            {
                // i 0
                { new(71, 0), new(89, 0), new(97, 3) }, // j 0
                { new(73, 0), new(91, 3), new(103, 3) }, // j 1
                { new(72, 3), new(88, 3), new(105, 3) } // j 2
            },
            {
                // i 1
                { new(51, 0), new(69, 3), new(84, 3) }, // j 0
                { new(54, 0), new(71, 0), new(89, 0) }, // j 1
                { new(55, 3), new(73, 0), new(91, 3) } // j 2
            },
            {
                // i 2
                { new(38, 0), new(47, 3), new(64, 3) }, // j 0
                { new(34, 3), new(51, 0), new(69, 3) }, // j 1
                { new(36, 3), new(54, 0), new(71, 0) } // j 2
            }
        },
        {
            // face 13
            {
                // i 0
                { new(96, 0), new(104, 0), new(107, 3) }, // j 0
                { new(98, 0), new(110, 3), new(115, 3) }, // j 1
                { new(97, 3), new(111, 3), new(119, 3) } // j 2
            },
            {
                // i 1
                { new(76, 0), new(86, 3), new(94, 3) }, // j 0
                { new(82, 0), new(96, 0), new(104, 0) }, // j 1
                { new(84, 3), new(98, 0), new(110, 3) } // j 2
            },
            {
                // i 2
                { new(58, 0), new(65, 3), new(75, 3) }, // j 0
                { new(62, 3), new(76, 0), new(86, 3) }, // j 1
                { new(64, 3), new(82, 0), new(96, 0) } // j 2
            }
        },
        {
            // face 14
            {
                // i 0
                { new(85, 0), new(87, 0), new(83, 3) }, // j 0
                { new(101, 0), new(102, 3), new(100, 3) }, // j 1
                { new(107, 3), new(112, 3), new(114, 3) } // j 2
            },
            {
                // i 1
                { new(66, 0), new(67, 3), new(70, 3) }, // j 0
                { new(81, 0), new(85, 0), new(87, 0) }, // j 1
                { new(94, 3), new(101, 0), new(102, 3) } // j 2
            },
            {
                // i 2
                { new(49, 0), new(48, 3), new(50, 3) }, // j 0
                { new(61, 3), new(66, 0), new(67, 3) }, // j 1
                { new(75, 3), new(81, 0), new(85, 0) } // j 2
            }
        },
        {
            // face 15
            {
                // i 0
                { new(95, 0), new(92, 0), new(83, 0) }, // j 0
                { new(79, 0), new(78, 0), new(74, 3) }, // j 1
                { new(63, 1), new(59, 3), new(57, 3) } // j 2
            },
            {
                // i 1
                { new(109, 0), new(108, 0), new(100, 5) }, // j 0
                { new(93, 1), new(95, 0), new(92, 0) }, // j 1
                { new(77, 1), new(79, 0), new(78, 0) } // j 2
            },
            {
                // i 2
                { new(117, 4), new(118, 5), new(114, 5) }, // j 0
                { new(106, 1), new(109, 0), new(108, 0) }, // j 1
                { new(90, 1), new(93, 1), new(95, 0) } // j 2
            }
        },
        {
            // face 16
            {
                // i 0
                { new(90, 0), new(77, 0), new(63, 0) }, // j 0
                { new(80, 0), new(68, 0), new(56, 3) }, // j 1
                { new(72, 1), new(60, 3), new(46, 3) } // j 2
            },
            {
                // i 1
                { new(106, 0), new(93, 0), new(79, 5) }, // j 0
                { new(99, 1), new(90, 0), new(77, 0) }, // j 1
                { new(88, 1), new(80, 0), new(68, 0) } // j 2
            },
            {
                // i 2
                { new(117, 3), new(109, 5), new(95, 5) }, // j 0
                { new(113, 1), new(106, 0), new(93, 0) }, // j 1
                { new(105, 1), new(99, 1), new(90, 0) } // j 2
            }
        },
        {
            // face 17
            {
                // i 0
                { new(105, 0), new(88, 0), new(72, 0) }, // j 0
                { new(103, 0), new(91, 0), new(73, 3) }, // j 1
                { new(97, 1), new(89, 3), new(71, 3) } // j 2
            },
            {
                // i 1
                { new(113, 0), new(99, 0), new(80, 5) }, // j 0
                { new(116, 1), new(105, 0), new(88, 0) }, // j 1
                { new(111, 1), new(103, 0), new(91, 0) } // j 2
            },
            {
                // i 2
                { new(117, 2), new(106, 5), new(90, 5) }, // j 0
                { new(121, 1), new(113, 0), new(99, 0) }, // j 1
                { new(119, 1), new(116, 1), new(105, 0) } // j 2
            }
        },
        {
            // face 18
            {
                // i 0
                { new(119, 0), new(111, 0), new(97, 0) }, // j 0
                { new(115, 0), new(110, 0), new(98, 3) }, // j 1
                { new(107, 1), new(104, 3), new(96, 3) } // j 2
            },
            {
                // i 1
                { new(121, 0), new(116, 0), new(103, 5) }, // j 0
                { new(120, 1), new(119, 0), new(111, 0) }, // j 1
                { new(112, 1), new(115, 0), new(110, 0) } // j 2
            },
            {
                // i 2
                { new(117, 1), new(113, 5), new(105, 5) }, // j 0
                { new(118, 1), new(121, 0), new(116, 0) }, // j 1
                { new(114, 1), new(120, 1), new(119, 0) } // j 2
            }
        },
        {
            // face 19
            {
                // i 0
                { new(114, 0), new(112, 0), new(107, 0) }, // j 0
                { new(100, 0), new(102, 0), new(101, 3) }, // j 1
                { new(83, 1), new(87, 3), new(85, 3) } // j 2
            },
            {
                // i 1
                { new(118, 0), new(120, 0), new(115, 5) }, // j 0
                { new(108, 1), new(114, 0), new(112, 0) }, // j 1
                { new(92, 1), new(100, 0), new(102, 0) } // j 2
            },
            {
                // i 2
                { new(117, 0), new(121, 5), new(119, 5) }, // j 0
                { new(109, 1), new(118, 0), new(120, 0) }, // j 1
                { new(95, 1), new(108, 1), new(114, 0) } // j 2
            }
        }
    };

    public static readonly BaseCellData[] BaseCells =
    {
        new(new FaceIjk(1, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 0
        new(new FaceIjk(2, new CoordinateIjk(1, 1, 0)), false, (0, 0)), // base cell 1
        new(new FaceIjk(1, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 2
        new(new FaceIjk(2, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 3
        new(new FaceIjk(0, new CoordinateIjk(2, 0, 0)), true, (-1, -1)), // base cell 4
        new(new FaceIjk(1, new CoordinateIjk(1, 1, 0)), false, (0, 0)), // base cell 5
        new(new FaceIjk(1, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 6
        new(new FaceIjk(2, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 7
        new(new FaceIjk(0, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 8
        new(new FaceIjk(2, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 9
        new(new FaceIjk(1, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 10
        new(new FaceIjk(1, new CoordinateIjk(0, 1, 1)), false, (0, 0)), // base cell 11
        new(new FaceIjk(3, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 12
        new(new FaceIjk(3, new CoordinateIjk(1, 1, 0)), false, (0, 0)), // base cell 13
        new(new FaceIjk(11, new CoordinateIjk(2, 0, 0)), true, (2, 6)), // base cell 14
        new(new FaceIjk(4, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 15
        new(new FaceIjk(0, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 16
        new(new FaceIjk(6, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 17
        new(new FaceIjk(0, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 18
        new(new FaceIjk(2, new CoordinateIjk(0, 1, 1)), false, (0, 0)), // base cell 19
        new(new FaceIjk(7, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 20
        new(new FaceIjk(2, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 21
        new(new FaceIjk(0, new CoordinateIjk(1, 1, 0)), false, (0, 0)), // base cell 22
        new(new FaceIjk(6, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 23
        new(new FaceIjk(10, new CoordinateIjk(2, 0, 0)), true, (1, 5)), // base cell 24
        new(new FaceIjk(6, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 25
        new(new FaceIjk(3, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 26
        new(new FaceIjk(11, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 27
        new(new FaceIjk(4, new CoordinateIjk(1, 1, 0)), false, (0, 0)), // base cell 28
        new(new FaceIjk(3, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 29
        new(new FaceIjk(0, new CoordinateIjk(0, 1, 1)), false, (0, 0)), // base cell 30
        new(new FaceIjk(4, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 31
        new(new FaceIjk(5, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 32
        new(new FaceIjk(0, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 33
        new(new FaceIjk(7, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 34
        new(new FaceIjk(11, new CoordinateIjk(1, 1, 0)), false, (0, 0)), // base cell 35
        new(new FaceIjk(7, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 36
        new(new FaceIjk(10, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 37
        new(new FaceIjk(12, new CoordinateIjk(2, 0, 0)), true, (3, 7)), // base cell 38
        new(new FaceIjk(6, new CoordinateIjk(1, 0, 1)), false, (0, 0)), // base cell 39
        new(new FaceIjk(7, new CoordinateIjk(1, 0, 1)), false, (0, 0)), // base cell 40
        new(new FaceIjk(4, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 41
        new(new FaceIjk(3, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 42
        new(new FaceIjk(3, new CoordinateIjk(0, 1, 1)), false, (0, 0)), // base cell 43
        new(new FaceIjk(4, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 44
        new(new FaceIjk(6, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 45
        new(new FaceIjk(11, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 46
        new(new FaceIjk(8, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 47
        new(new FaceIjk(5, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 48
        new(new FaceIjk(14, new CoordinateIjk(2, 0, 0)), true, (0, 9)), // base cell 49
        new(new FaceIjk(5, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 50
        new(new FaceIjk(12, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 51
        new(new FaceIjk(10, new CoordinateIjk(1, 1, 0)), false, (0, 0)), // base cell 52
        new(new FaceIjk(4, new CoordinateIjk(0, 1, 1)), false, (0, 0)), // base cell 53
        new(new FaceIjk(12, new CoordinateIjk(1, 1, 0)), false, (0, 0)), // base cell 54
        new(new FaceIjk(7, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 55
        new(new FaceIjk(11, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 56
        new(new FaceIjk(10, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 57
        new(new FaceIjk(13, new CoordinateIjk(2, 0, 0)), true, (4, 8)), // base cell 58
        new(new FaceIjk(10, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 59
        new(new FaceIjk(11, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 60
        new(new FaceIjk(9, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 61
        new(new FaceIjk(8, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 62
        new(new FaceIjk(6, new CoordinateIjk(2, 0, 0)), true, (11, 15)), // base cell 63
        new(new FaceIjk(8, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 64
        new(new FaceIjk(9, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 65
        new(new FaceIjk(14, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 66
        new(new FaceIjk(5, new CoordinateIjk(1, 0, 1)), false, (0, 0)), // base cell 67
        new(new FaceIjk(16, new CoordinateIjk(0, 1, 1)), false, (0, 0)), // base cell 68
        new(new FaceIjk(8, new CoordinateIjk(1, 0, 1)), false, (0, 0)), // base cell 69
        new(new FaceIjk(5, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 70
        new(new FaceIjk(12, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 71
        new(new FaceIjk(7, new CoordinateIjk(2, 0, 0)), true, (12, 16)), // base cell 72
        new(new FaceIjk(12, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 73
        new(new FaceIjk(10, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 74
        new(new FaceIjk(9, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 75
        new(new FaceIjk(13, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 76
        new(new FaceIjk(16, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 77
        new(new FaceIjk(15, new CoordinateIjk(0, 1, 1)), false, (0, 0)), // base cell 78
        new(new FaceIjk(15, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 79
        new(new FaceIjk(16, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 80
        new(new FaceIjk(14, new CoordinateIjk(1, 1, 0)), false, (0, 0)), // base cell 81
        new(new FaceIjk(13, new CoordinateIjk(1, 1, 0)), false, (0, 0)), // base cell 82
        new(new FaceIjk(5, new CoordinateIjk(2, 0, 0)), true, (10, 19)), // base cell 83
        new(new FaceIjk(8, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 84
        new(new FaceIjk(14, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 85
        new(new FaceIjk(9, new CoordinateIjk(1, 0, 1)), false, (0, 0)), // base cell 86
        new(new FaceIjk(14, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 87
        new(new FaceIjk(17, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 88
        new(new FaceIjk(12, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 89
        new(new FaceIjk(16, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 90
        new(new FaceIjk(17, new CoordinateIjk(0, 1, 1)), false, (0, 0)), // base cell 91
        new(new FaceIjk(15, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 92
        new(new FaceIjk(16, new CoordinateIjk(1, 0, 1)), false, (0, 0)), // base cell 93
        new(new FaceIjk(9, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 94
        new(new FaceIjk(15, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 95
        new(new FaceIjk(13, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 96
        new(new FaceIjk(8, new CoordinateIjk(2, 0, 0)), true, (13, 17)), // base cell 97
        new(new FaceIjk(13, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 98
        new(new FaceIjk(17, new CoordinateIjk(1, 0, 1)), false, (0, 0)), // base cell 99
        new(new FaceIjk(19, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 100
        new(new FaceIjk(14, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 101
        new(new FaceIjk(19, new CoordinateIjk(0, 1, 1)), false, (0, 0)), // base cell 102
        new(new FaceIjk(17, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 103
        new(new FaceIjk(13, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 104
        new(new FaceIjk(17, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 105
        new(new FaceIjk(16, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 106
        new(new FaceIjk(9, new CoordinateIjk(2, 0, 0)), true, (14, 18)), // base cell 107
        new(new FaceIjk(15, new CoordinateIjk(1, 0, 1)), false, (0, 0)), // base cell 108
        new(new FaceIjk(15, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 109
        new(new FaceIjk(18, new CoordinateIjk(0, 1, 1)), false, (0, 0)), // base cell 110
        new(new FaceIjk(18, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 111
        new(new FaceIjk(19, new CoordinateIjk(0, 0, 1)), false, (0, 0)), // base cell 112
        new(new FaceIjk(17, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 113
        new(new FaceIjk(19, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 114
        new(new FaceIjk(18, new CoordinateIjk(0, 1, 0)), false, (0, 0)), // base cell 115
        new(new FaceIjk(18, new CoordinateIjk(1, 0, 1)), false, (0, 0)), // base cell 116
        new(new FaceIjk(19, new CoordinateIjk(2, 0, 0)), true, (-1, -1)), // base cell 117
        new(new FaceIjk(19, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 118
        new(new FaceIjk(18, new CoordinateIjk(0, 0, 0)), false, (0, 0)), // base cell 119
        new(new FaceIjk(19, new CoordinateIjk(1, 0, 1)), false, (0, 0)), // base cell 120
        new(new FaceIjk(18, new CoordinateIjk(1, 0, 0)), false, (0, 0)), // base cell 121
    };

    public static readonly int[,] BaseCellNeighbors =
    {
        { 0, 1, 5, 2, 4, 3, 8 }, // base cell 0
        { 1, 7, 6, 9, 0, 3, 2 }, // base cell 1
        { 2, 6, 10, 11, 0, 1, 5 }, // base cell 2
        { 3, 13, 1, 7, 4, 12, 0 }, // base cell 3
        { 4, InvalidBaseCell, 15, 8, 3, 0, 12 }, // base cell 4 (pentagon)
        { 5, 2, 18, 10, 8, 0, 16 }, // base cell 5
        { 6, 14, 11, 17, 1, 9, 2 }, // base cell 6
        { 7, 21, 9, 19, 3, 13, 1 }, // base cell 7
        { 8, 5, 22, 16, 4, 0, 15 }, // base cell 8
        { 9, 19, 14, 20, 1, 7, 6 }, // base cell 9
        { 10, 11, 24, 23, 5, 2, 18 }, // base cell 10
        { 11, 17, 23, 25, 2, 6, 10 }, // base cell 11
        { 12, 28, 13, 26, 4, 15, 3 }, // base cell 12
        { 13, 26, 21, 29, 3, 12, 7 }, // base cell 13
        { 14, InvalidBaseCell, 17, 27, 9, 20, 6 }, // base cell 14 (pentagon)
        { 15, 22, 28, 31, 4, 8, 12 }, // base cell 15
        { 16, 18, 33, 30, 8, 5, 22 }, // base cell 16
        { 17, 11, 14, 6, 35, 25, 27 }, // base cell 17
        { 18, 24, 30, 32, 5, 10, 16 }, // base cell 18
        { 19, 34, 20, 36, 7, 21, 9 }, // base cell 19
        { 20, 14, 19, 9, 40, 27, 36 }, // base cell 20
        { 21, 38, 19, 34, 13, 29, 7 }, // base cell 21
        { 22, 16, 41, 33, 15, 8, 31 }, // base cell 22
        { 23, 24, 11, 10, 39, 37, 25 }, // base cell 23
        { 24, InvalidBaseCell, 32, 37, 10, 23, 18 }, // base cell 24 (pentagon)
        { 25, 23, 17, 11, 45, 39, 35 }, // base cell 25
        { 26, 42, 29, 43, 12, 28, 13 }, // base cell 26
        { 27, 40, 35, 46, 14, 20, 17 }, // base cell 27
        { 28, 31, 42, 44, 12, 15, 26 }, // base cell 28
        { 29, 43, 38, 47, 13, 26, 21 }, // base cell 29
        { 30, 32, 48, 50, 16, 18, 33 }, // base cell 30
        { 31, 41, 44, 53, 15, 22, 28 }, // base cell 31
        { 32, 30, 24, 18, 52, 50, 37 }, // base cell 32
        { 33, 30, 49, 48, 22, 16, 41 }, // base cell 33
        { 34, 19, 38, 21, 54, 36, 51 }, // base cell 34
        { 35, 46, 45, 56, 17, 27, 25 }, // base cell 35
        { 36, 20, 34, 19, 55, 40, 54 }, // base cell 36
        { 37, 39, 52, 57, 24, 23, 32 }, // base cell 37
        { 38, InvalidBaseCell, 34, 51, 29, 47, 21 }, // base cell 38 (pentagon)
        { 39, 37, 25, 23, 59, 57, 45 }, // base cell 39
        { 40, 27, 36, 20, 60, 46, 55 }, // base cell 40
        { 41, 49, 53, 61, 22, 33, 31 }, // base cell 41
        { 42, 58, 43, 62, 28, 44, 26 }, // base cell 42
        { 43, 62, 47, 64, 26, 42, 29 }, // base cell 43
        { 44, 53, 58, 65, 28, 31, 42 }, // base cell 44
        { 45, 39, 35, 25, 63, 59, 56 }, // base cell 45
        { 46, 60, 56, 68, 27, 40, 35 }, // base cell 46
        { 47, 38, 43, 29, 69, 51, 64 }, // base cell 47
        { 48, 49, 30, 33, 67, 66, 50 }, // base cell 48
        { 49, InvalidBaseCell, 61, 66, 33, 48, 41 }, // base cell 49 (pentagon)
        { 50, 48, 32, 30, 70, 67, 52 }, // base cell 50
        { 51, 69, 54, 71, 38, 47, 34 }, // base cell 51
        { 52, 57, 70, 74, 32, 37, 50 }, // base cell 52
        { 53, 61, 65, 75, 31, 41, 44 }, // base cell 53
        { 54, 71, 55, 73, 34, 51, 36 }, // base cell 54
        { 55, 40, 54, 36, 72, 60, 73 }, // base cell 55
        { 56, 68, 63, 77, 35, 46, 45 }, // base cell 56
        { 57, 59, 74, 78, 37, 39, 52 }, // base cell 57
        { 58, InvalidBaseCell, 62, 76, 44, 65, 42 }, // base cell 58 (pentagon)
        { 59, 63, 78, 79, 39, 45, 57 }, // base cell 59
        { 60, 72, 68, 80, 40, 55, 46 }, // base cell 60
        { 61, 53, 49, 41, 81, 75, 66 }, // base cell 61
        { 62, 43, 58, 42, 82, 64, 76 }, // base cell 62
        { 63, InvalidBaseCell, 56, 45, 79, 59, 77 }, // base cell 63 (pentagon)
        { 64, 47, 62, 43, 84, 69, 82 }, // base cell 64
        { 65, 58, 53, 44, 86, 76, 75 }, // base cell 65
        { 66, 67, 81, 85, 49, 48, 61 }, // base cell 66
        { 67, 66, 50, 48, 87, 85, 70 }, // base cell 67
        { 68, 56, 60, 46, 90, 77, 80 }, // base cell 68
        { 69, 51, 64, 47, 89, 71, 84 }, // base cell 69
        { 70, 67, 52, 50, 83, 87, 74 }, // base cell 70
        { 71, 89, 73, 91, 51, 69, 54 }, // base cell 71
        { 72, InvalidBaseCell, 73, 55, 80, 60, 88 }, // base cell 72 (pentagon)
        { 73, 91, 72, 88, 54, 71, 55 }, // base cell 73
        { 74, 78, 83, 92, 52, 57, 70 }, // base cell 74
        { 75, 65, 61, 53, 94, 86, 81 }, // base cell 75
        { 76, 86, 82, 96, 58, 65, 62 }, // base cell 76
        { 77, 63, 68, 56, 93, 79, 90 }, // base cell 77
        { 78, 74, 59, 57, 95, 92, 79 }, // base cell 78
        { 79, 78, 63, 59, 93, 95, 77 }, // base cell 79
        { 80, 68, 72, 60, 99, 90, 88 }, // base cell 80
        { 81, 85, 94, 101, 61, 66, 75 }, // base cell 81
        { 82, 96, 84, 98, 62, 76, 64 }, // base cell 82
        { 83, InvalidBaseCell, 74, 70, 100, 87, 92 }, // base cell 83 (pentagon)
        { 84, 69, 82, 64, 97, 89, 98 }, // base cell 84
        { 85, 87, 101, 102, 66, 67, 81 }, // base cell 85
        { 86, 76, 75, 65, 104, 96, 94 }, // base cell 86
        { 87, 83, 102, 100, 67, 70, 85 }, // base cell 87
        { 88, 72, 91, 73, 99, 80, 105 }, // base cell 88
        { 89, 97, 91, 103, 69, 84, 71 }, // base cell 89
        { 90, 77, 80, 68, 106, 93, 99 }, // base cell 90
        { 91, 73, 89, 71, 105, 88, 103 }, // base cell 91
        { 92, 83, 78, 74, 108, 100, 95 }, // base cell 92
        { 93, 79, 90, 77, 109, 95, 106 }, // base cell 93
        { 94, 86, 81, 75, 107, 104, 101 }, // base cell 94
        { 95, 92, 79, 78, 109, 108, 93 }, // base cell 95
        { 96, 104, 98, 110, 76, 86, 82 }, // base cell 96
        { 97, InvalidBaseCell, 98, 84, 103, 89, 111 }, // base cell 97 (pentagon)
        { 98, 110, 97, 111, 82, 96, 84 }, // base cell 98
        { 99, 80, 105, 88, 106, 90, 113 }, // base cell 99
        { 100, 102, 83, 87, 108, 114, 92 }, // base cell 100
        { 101, 102, 107, 112, 81, 85, 94 }, // base cell 101
        { 102, 101, 87, 85, 114, 112, 100 }, // base cell 102
        { 103, 91, 97, 89, 116, 105, 111 }, // base cell 103
        { 104, 107, 110, 115, 86, 94, 96 }, // base cell 104
        { 105, 88, 103, 91, 113, 99, 116 }, // base cell 105
        { 106, 93, 99, 90, 117, 109, 113 }, // base cell 106
        { 107, InvalidBaseCell, 101, 94, 115, 104, 112 }, // base cell 107 (pentagon)
        { 108, 100, 95, 92, 118, 114, 109 }, // base cell 108
        { 109, 108, 93, 95, 117, 118, 106 }, // base cell 109
        { 110, 98, 104, 96, 119, 111, 115 }, // base cell 110
        { 111, 97, 110, 98, 116, 103, 119 }, // base cell 111
        { 112, 107, 102, 101, 120, 115, 114 }, // base cell 112
        { 113, 99, 116, 105, 117, 106, 121 }, // base cell 113
        { 114, 112, 100, 102, 118, 120, 108 }, // base cell 114
        { 115, 110, 107, 104, 120, 119, 112 }, // base cell 115
        { 116, 103, 119, 111, 113, 105, 121 }, // base cell 116
        { 117, InvalidBaseCell, 109, 118, 113, 121, 106 }, // base cell 117 (pentagon)
        { 118, 120, 108, 114, 117, 121, 109 }, // base cell 118
        { 119, 111, 115, 110, 121, 116, 120 }, // base cell 119
        { 120, 115, 114, 112, 121, 119, 118 }, // base cell 120
        { 121, 116, 120, 119, 117, 113, 118 }, // base cell 121
    };

    public static readonly int[,] BaseCellNeighbor60CcwRots =
    {
        { 0, 5, 0, 0, 1, 5, 1 }, // base cell 0
        { 0, 0, 1, 0, 1, 0, 1 }, // base cell 1
        { 0, 0, 0, 0, 0, 5, 0 }, // base cell 2
        { 0, 5, 0, 0, 2, 5, 1 }, // base cell 3
        { 0, -1, 1, 0, 3, 4, 2 }, // base cell 4 (pentagon)
        { 0, 0, 1, 0, 1, 0, 1 }, // base cell 5
        { 0, 0, 0, 3, 5, 5, 0 }, // base cell 6
        { 0, 0, 0, 0, 0, 5, 0 }, // base cell 7
        { 0, 5, 0, 0, 0, 5, 1 }, // base cell 8
        { 0, 0, 1, 3, 0, 0, 1 }, // base cell 9
        { 0, 0, 1, 3, 0, 0, 1 }, // base cell 10
        { 0, 3, 3, 3, 0, 0, 0 }, // base cell 11
        { 0, 5, 0, 0, 3, 5, 1 }, // base cell 12
        { 0, 0, 1, 0, 1, 0, 1 }, // base cell 13
        { 0, -1, 3, 0, 5, 2, 0 }, // base cell 14 (pentagon)
        { 0, 5, 0, 0, 4, 5, 1 }, // base cell 15
        { 0, 0, 0, 0, 0, 5, 0 }, // base cell 16
        { 0, 3, 3, 3, 3, 0, 3 }, // base cell 17
        { 0, 0, 0, 3, 5, 5, 0 }, // base cell 18
        { 0, 3, 3, 3, 0, 0, 0 }, // base cell 19
        { 0, 3, 3, 3, 0, 3, 0 }, // base cell 20
        { 0, 0, 0, 3, 5, 5, 0 }, // base cell 21
        { 0, 0, 1, 0, 1, 0, 1 }, // base cell 22
        { 0, 3, 3, 3, 0, 3, 0 }, // base cell 23
        { 0, -1, 3, 0, 5, 2, 0 }, // base cell 24 (pentagon)
        { 0, 0, 0, 3, 0, 0, 3 }, // base cell 25
        { 0, 0, 0, 0, 0, 5, 0 }, // base cell 26
        { 0, 3, 0, 0, 0, 3, 3 }, // base cell 27
        { 0, 0, 1, 0, 1, 0, 1 }, // base cell 28
        { 0, 0, 1, 3, 0, 0, 1 }, // base cell 29
        { 0, 3, 3, 3, 0, 0, 0 }, // base cell 30
        { 0, 0, 0, 0, 0, 5, 0 }, // base cell 31
        { 0, 3, 3, 3, 3, 0, 3 }, // base cell 32
        { 0, 0, 1, 3, 0, 0, 1 }, // base cell 33
        { 0, 3, 3, 3, 3, 0, 3 }, // base cell 34
        { 0, 0, 3, 0, 3, 0, 3 }, // base cell 35
        { 0, 0, 0, 3, 0, 0, 3 }, // base cell 36
        { 0, 3, 0, 0, 0, 3, 3 }, // base cell 37
        { 0, -1, 3, 0, 5, 2, 0 }, // base cell 38 (pentagon)
        { 0, 3, 0, 0, 3, 3, 0 }, // base cell 39
        { 0, 3, 0, 0, 3, 3, 0 }, // base cell 40
        { 0, 0, 0, 3, 5, 5, 0 }, // base cell 41
        { 0, 0, 0, 3, 5, 5, 0 }, // base cell 42
        { 0, 3, 3, 3, 0, 0, 0 }, // base cell 43
        { 0, 0, 1, 3, 0, 0, 1 }, // base cell 44
        { 0, 0, 3, 0, 0, 3, 3 }, // base cell 45
        { 0, 0, 0, 3, 0, 3, 0 }, // base cell 46
        { 0, 3, 3, 3, 0, 3, 0 }, // base cell 47
        { 0, 3, 3, 3, 0, 3, 0 }, // base cell 48
        { 0, -1, 3, 0, 5, 2, 0 }, // base cell 49 (pentagon)
        { 0, 0, 0, 3, 0, 0, 3 }, // base cell 50
        { 0, 3, 0, 0, 0, 3, 3 }, // base cell 51
        { 0, 0, 3, 0, 3, 0, 3 }, // base cell 52
        { 0, 3, 3, 3, 0, 0, 0 }, // base cell 53
        { 0, 0, 3, 0, 3, 0, 3 }, // base cell 54
        { 0, 0, 3, 0, 0, 3, 3 }, // base cell 55
        { 0, 3, 3, 3, 0, 0, 3 }, // base cell 56
        { 0, 0, 0, 3, 0, 3, 0 }, // base cell 57
        { 0, -1, 3, 0, 5, 2, 0 }, // base cell 58 (pentagon)
        { 0, 3, 3, 3, 3, 3, 0 }, // base cell 59
        { 0, 3, 3, 3, 3, 3, 0 }, // base cell 60
        { 0, 3, 3, 3, 3, 0, 3 }, // base cell 61
        { 0, 3, 3, 3, 3, 0, 3 }, // base cell 62
        { 0, -1, 3, 0, 5, 2, 0 }, // base cell 63 (pentagon)
        { 0, 0, 0, 3, 0, 0, 3 }, // base cell 64
        { 0, 3, 3, 3, 0, 3, 0 }, // base cell 65
        { 0, 3, 0, 0, 0, 3, 3 }, // base cell 66
        { 0, 3, 0, 0, 3, 3, 0 }, // base cell 67
        { 0, 3, 3, 3, 0, 0, 0 }, // base cell 68
        { 0, 3, 0, 0, 3, 3, 0 }, // base cell 69
        { 0, 0, 3, 0, 0, 3, 3 }, // base cell 70
        { 0, 0, 0, 3, 0, 3, 0 }, // base cell 71
        { 0, -1, 3, 0, 5, 2, 0 }, // base cell 72 (pentagon)
        { 0, 3, 3, 3, 0, 0, 3 }, // base cell 73
        { 0, 3, 3, 3, 0, 0, 3 }, // base cell 74
        { 0, 0, 0, 3, 0, 0, 3 }, // base cell 75
        { 0, 3, 0, 0, 0, 3, 3 }, // base cell 76
        { 0, 0, 0, 3, 0, 5, 0 }, // base cell 77
        { 0, 3, 3, 3, 0, 0, 0 }, // base cell 78
        { 0, 0, 1, 3, 1, 0, 1 }, // base cell 79
        { 0, 0, 1, 3, 1, 0, 1 }, // base cell 80
        { 0, 0, 3, 0, 3, 0, 3 }, // base cell 81
        { 0, 0, 3, 0, 3, 0, 3 }, // base cell 82
        { 0, -1, 3, 0, 5, 2, 0 }, // base cell 83 (pentagon)
        { 0, 0, 3, 0, 0, 3, 3 }, // base cell 84
        { 0, 0, 0, 3, 0, 3, 0 }, // base cell 85
        { 0, 3, 0, 0, 3, 3, 0 }, // base cell 86
        { 0, 3, 3, 3, 3, 3, 0 }, // base cell 87
        { 0, 0, 0, 3, 0, 5, 0 }, // base cell 88
        { 0, 3, 3, 3, 3, 3, 0 }, // base cell 89
        { 0, 0, 0, 0, 0, 0, 1 }, // base cell 90
        { 0, 3, 3, 3, 0, 0, 0 }, // base cell 91
        { 0, 0, 0, 3, 0, 5, 0 }, // base cell 92
        { 0, 5, 0, 0, 5, 5, 0 }, // base cell 93
        { 0, 0, 3, 0, 0, 3, 3 }, // base cell 94
        { 0, 0, 0, 0, 0, 0, 1 }, // base cell 95
        { 0, 0, 0, 3, 0, 3, 0 }, // base cell 96
        { 0, -1, 3, 0, 5, 2, 0 }, // base cell 97 (pentagon)
        { 0, 3, 3, 3, 0, 0, 3 }, // base cell 98
        { 0, 5, 0, 0, 5, 5, 0 }, // base cell 99
        { 0, 0, 1, 3, 1, 0, 1 }, // base cell 100
        { 0, 3, 3, 3, 0, 0, 3 }, // base cell 101
        { 0, 3, 3, 3, 0, 0, 0 }, // base cell 102
        { 0, 0, 1, 3, 1, 0, 1 }, // base cell 103
        { 0, 3, 3, 3, 3, 3, 0 }, // base cell 104
        { 0, 0, 0, 0, 0, 0, 1 }, // base cell 105
        { 0, 0, 1, 0, 3, 5, 1 }, // base cell 106
        { 0, -1, 3, 0, 5, 2, 0 }, // base cell 107 (pentagon)
        { 0, 5, 0, 0, 5, 5, 0 }, // base cell 108
        { 0, 0, 1, 0, 4, 5, 1 }, // base cell 109
        { 0, 3, 3, 3, 0, 0, 0 }, // base cell 110
        { 0, 0, 0, 3, 0, 5, 0 }, // base cell 111
        { 0, 0, 0, 3, 0, 5, 0 }, // base cell 112
        { 0, 0, 1, 0, 2, 5, 1 }, // base cell 113
        { 0, 0, 0, 0, 0, 0, 1 }, // base cell 114
        { 0, 0, 1, 3, 1, 0, 1 }, // base cell 115
        { 0, 5, 0, 0, 5, 5, 0 }, // base cell 116
        { 0, -1, 1, 0, 3, 4, 2 }, // base cell 117 (pentagon)
        { 0, 0, 1, 0, 0, 5, 1 }, // base cell 118
        { 0, 0, 0, 0, 0, 0, 1 }, // base cell 119
        { 0, 5, 0, 0, 5, 5, 0 }, // base cell 120
        { 0, 0, 1, 0, 1, 5, 1 }, // base cell 121
    };
}