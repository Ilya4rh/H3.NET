namespace H3Net.Models;

internal struct FaceOrientIjk
{
    public readonly int Face;

    public readonly CoordinateIjk CoordinateIjk;

    public readonly int CcwRotation60;

    public FaceOrientIjk(int face, CoordinateIjk coordinateIjk, int ccwRotation60)
    {
        Face = face;
        CoordinateIjk = coordinateIjk;
        CcwRotation60 = ccwRotation60;
    }
}