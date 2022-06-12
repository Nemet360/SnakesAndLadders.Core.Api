using SnakesAndLadders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.SnakesAndLadders.BE
{
    internal class MockCube : ICube
    {
        private int _value;
        public void SetCubeValue(int value)
        {
            _value = value;
        }
        public int RollCube()
        {
            return _value;
        }
    }
}
