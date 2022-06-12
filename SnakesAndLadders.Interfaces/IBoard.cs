using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders.Interfaces
{
    
    public interface IBoard
    {
        IPlayer AddPlayer(string name);

        IPlayer PlayMove(int playerId);

        IPlayer GetPlayer(int playerId);

        IEnumerable<IPlayer> GetAllPlayers();
    }
}
