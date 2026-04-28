namespace H3Net.Models;

internal readonly struct Vector3
{
    private readonly double _x;

    private readonly double _y;

    private readonly double _z;

    public Vector3(double x, double y, double z)
    {
        _x = x;
        _y = y;
        _z = z;
    }

    public double DistanceSquaredTo(Vector3 vector3)
    {
        return Square(_x - vector3._x) + Square(_y - vector3._y) + Square(_z - vector3._z);
    }

    private static double Square(double x)
    {
        return x * x;
    }
}