using System;

namespace SnakesAndLadders.Interfaces
{
    public enum IBoardCellType : byte
    {
        Plain,
        Ladder,
        Snake
    }
    public interface IBoardCell
    {
        IBoardCellType BoardCellType { get; }
        int GetPosition();
    }
}
