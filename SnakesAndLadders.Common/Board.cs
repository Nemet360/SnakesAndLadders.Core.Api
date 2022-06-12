using SnakesAndLadders.Interfaces;

namespace SnakesAndLadders.Common
{
    public class Board : IBoard
    {
        private const int _totalBoardCells = 100;
        private const int _ladders = 5;
        private const int _snakes = 5;
        private List<IBoardCell> BoardLayout { get; set; }

        private readonly ICube _cube;
        private readonly List<Player> _players;

        public Board(ICube rollingCube , int totalCells = _totalBoardCells, int ladders = _ladders, int snakes = _snakes)
        {
            _players = new List<Player>();
            _cube = rollingCube;
            BoardLayout = new List<IBoardCell>(totalCells);
            var unAllocatedCells = new List<int>(totalCells);
            for (int i = 0 ; i < totalCells; i++)
            {
                BoardLayout.Add(new Cell(i));
                unAllocatedCells.Add(i);
            }

            for (int i = 0; i < ladders; i++)
            {
                var head = popRandomFromCollection(ref unAllocatedCells,0, unAllocatedCells.Count-2);
                var tail = popRandomFromCollection(ref unAllocatedCells, head, unAllocatedCells.Count-2);//ladders goes only up

                BoardLayout[head] = new Cell(tail, IBoardCellType.Ladder);
            }

            for (int i = 0; i < snakes; i++)
            {
                var head = popRandomFromCollection(ref unAllocatedCells, 2, unAllocatedCells.Count);
                var tail = popRandomFromCollection(ref unAllocatedCells, 0, head);//snakes can go only down

                BoardLayout[head] = new Cell(tail, IBoardCellType.Snake);
            }
        }

        private int popRandomFromCollection(ref List<int> unAllocated, int startPoint, int endPoint)
        {
            Random rnd = new Random();
            var ret = rnd.Next(startPoint, endPoint);

            unAllocated.RemoveAt(ret);
            return ret;
        }

        public IPlayer PlayMove(int playerId)
        {
            var player = GetPlayer(playerId);

            if (player.Status == BoardStatus.Finished)
                throw new Exception("game is done");

            var cubeResult = _cube.RollCube();
            var currentCell = player.CurrentPlace.GetPosition();
            var status = BoardStatus.InGame;
            IBoardCell nextCell;
            if ((currentCell + cubeResult) >= BoardLayout.Count)
            {
                status = BoardStatus.Finished;
                nextCell = BoardLayout.Last();
            }
            else
            {
                nextCell = BoardLayout[(currentCell + cubeResult)];
            }
            ((Player)player).UpdateMove(cubeResult, nextCell, status);

            return player;
        }

        public IPlayer AddPlayer(string name)
        {
            var player = new Player(_players.Count, name, BoardLayout[0]);
            _players.Add(player);
            return player;
        }

        public IPlayer GetPlayer(int playerId)
        {
            var player = _players.FirstOrDefault(e => e.PlayerId == playerId);
            if (player == null)
                throw new InvalidOperationException("player not found " + playerId);

            var allFinishedPlayers = _players.Where(e => e.Status == BoardStatus.Finished).ToList(); //materializing collection in order to prevent multiple iterations ahead
            if (allFinishedPlayers.Count > 0)
            {
                var lowestFinisedGames = allFinishedPlayers.Min(e => e.MovesPlayed);
                var firstPlaces = allFinishedPlayers.Where(e => e.MovesPlayed == lowestFinisedGames).ToArray();

                if (firstPlaces.Contains(player))
                {
                    player.IsFirstPlace = true;
                }
            }

            return player;
        }

        public IEnumerable<IPlayer> GetAllPlayers()
        {
            return _players.AsEnumerable();
        }
    }
}