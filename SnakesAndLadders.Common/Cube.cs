using SnakesAndLadders.Interfaces;

namespace SnakesAndLadders.Common
{
    public class Cube : ICube
    {
        public int RollCube()
        {
            return new Random().Next(1, 6);
        }
    }
}
