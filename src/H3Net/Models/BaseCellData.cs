namespace H3Net.Models;

internal struct BaseCellData
{
    public readonly FaceIjk HomeFaceIjk;
    
    public readonly bool IsPentagon;
    
    public readonly (int, int) CwOffsetPent;

    public BaseCellData(FaceIjk homeFaceIjk, bool isPentagon, (int, int) cwOffsetPent)
    {
        HomeFaceIjk = homeFaceIjk;
        IsPentagon = isPentagon;
        CwOffsetPent = cwOffsetPent;
    }

    public bool IsCwOffset(int face)
    {
        return CwOffsetPent.Item1 == face || CwOffsetPent.Item2 == face;
    }
}