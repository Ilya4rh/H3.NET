using System;
using H3Net.Constants;

namespace H3Net.Models;

internal readonly struct Vector2 : IEquatable<Vector2>
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

    public static bool operator ==(Vector2 vector1, Vector2 vector2)
    {
        return Math.Abs(vector1.X - vector2.X) < CalculateConstants.Epsilon &&
               Math.Abs(vector1.Y - vector2.Y) < CalculateConstants.Epsilon;
    }

    public static bool operator !=(Vector2 vector1, Vector2 vector2)
    {
        return !(vector1 == vector2);
    }

    public bool Equals(Vector2 other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector2 other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}