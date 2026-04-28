namespace H3Net.Models;

internal struct BaseCellRotation
{
    public readonly int BaseCell;
    public readonly int Rotation;

    public BaseCellRotation(int baseCell, int rotation)
    {
        BaseCell = baseCell;
        Rotation = rotation;
    }
}