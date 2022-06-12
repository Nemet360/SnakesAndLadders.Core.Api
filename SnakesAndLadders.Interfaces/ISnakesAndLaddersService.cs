namespace SnakesAndLadders.Interfaces
{
    public interface ISnakesAndLaddersService
    {
        Task<IPlayer> StartNewPlayerGame(string name);
        IPlayer GetPlayerStatus(int playerId);
        IEnumerable<IPlayer> GetPlayers();
    }
}
