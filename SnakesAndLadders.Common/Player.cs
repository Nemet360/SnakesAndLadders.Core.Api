using SnakesAndLadders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders.Common
{
    public class Player : IPlayer
    {
        public int PlayerId { get; private set; }
        public BoardStatus Status { get; private set; }
        public IBoardCell CurrentPlace { get; private set; }
        public int MovesPlayed { get; private set; }
        public List<int> MovesHistory { get; private set; }
        public string Name { get; private set; }

        public bool IsFirstPlace { get; set; }

        IEnumerable<int> IPlayer.MovesHistory => MovesHistory;

        public List<string> PlacesHistory { get; private set; }
        IEnumerable<string> IPlayer.PlacesHistory => PlacesHistory;

        public Player(int playerId, string name, IBoardCell currentPlace)
        {
            Name = name;
            MovesHistory = new List<int>();
            PlayerId = playerId;
            CurrentPlace = currentPlace;
            Status = BoardStatus.NotStarted;
            PlacesHistory = new List<string>();
            PlacesHistory.Add("0 , initial");
        }

        internal void UpdateMove(int move, IBoardCell current, BoardStatus status)
        {
            MovesPlayed++;

            PlacesHistory.Add(string.Format("game status : {5}  move {0} , was at position {1} cube type {2} , rolled {0} and hit cube {3} to position {4}", move, CurrentPlace.GetPosition(), CurrentPlace.BoardCellType, current.GetPosition(), current.BoardCellType, status));

            MovesHistory.Add(move);
            CurrentPlace = current;
            Status = status;
        }
    }
}
