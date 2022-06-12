using SnakesAndLadders.Common;
using SnakesAndLadders.Interfaces;

namespace SnakesAndLadders.BE
{
    public class SnakesAndLaddersService: ISnakesAndLaddersService
    {
        private readonly IBoard _board;
        private readonly ICube _cube;
        public SnakesAndLaddersService()
        {
            _cube = new Cube();
            _board = new Board(_cube, 100, 5, 5);
        }

        public async Task<IPlayer> StartNewPlayerGame(string name)
        {
            var player = _board.AddPlayer(name);

            await PlayGame(player);

            return player;
        }

        public async Task PlayGame(IPlayer player)
        {
            Random rnd = new Random();

            await Task.Factory.StartNew(async () =>
            {
                do
                {
                    await Task.Delay(rnd.Next(100, 200));
                    _board.PlayMove(player.PlayerId);
                }
                while (player.Status != BoardStatus.Finished);
            });
        }


        public IPlayer GetPlayerStatus(int playerId)
        {
            return _board.GetPlayer(playerId);
        }

        public IEnumerable<IPlayer> GetPlayers()
        {
            return _board.GetAllPlayers();
        }
    }
}