namespace H3Net.Models;

internal readonly struct FaceIjk
{
    public readonly int Face;

    public readonly CoordinateIjk CoordinateIjk;

    public FaceIjk(int face, CoordinateIjk coordinateIjk)
    {
        Face = face;
        CoordinateIjk = coordinateIjk;
    }

    public override string ToString()
    {
        return $"Face = {Face}, CoordinateIJK: ({CoordinateIjk.I}, {CoordinateIjk.J}, {CoordinateIjk.K})";
    }
}