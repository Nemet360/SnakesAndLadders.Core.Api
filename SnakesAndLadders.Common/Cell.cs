using SnakesAndLadders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders.Common
{
    public class Cell : IBoardCell
    {
        private readonly int _position;
        public IBoardCellType BoardCellType { get; private set; }
        public Cell(int position, IBoardCellType type = IBoardCellType.Plain)
        {
            _position = position;
            BoardCellType = type;
        }

        public int GetPosition()
        {
            return _position;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", BoardCellType, _position);
        }
    }
}
