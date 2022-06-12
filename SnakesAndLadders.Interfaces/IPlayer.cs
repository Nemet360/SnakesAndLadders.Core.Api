using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders.Interfaces
{
    public enum BoardStatus
    {
        NotStarted,
        InGame,
        Finished
    }
    public interface IPlayer
    {
        int PlayerId { get; }
        BoardStatus Status { get; }
        IBoardCell CurrentPlace { get; }
        int MovesPlayed { get; }
        IEnumerable<int> MovesHistory { get; }

        IEnumerable<string> PlacesHistory { get; }
        string Name { get; }
        bool IsFirstPlace { get; set; }
    }
}
