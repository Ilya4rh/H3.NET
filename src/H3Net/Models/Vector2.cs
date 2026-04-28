using System;

namespace H3Net.Models;

internal readonly struct Vector2
{
    public readonly double X;
    
    public readonly double Y;

    public Vector2(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double CalculateMagnitude()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
}