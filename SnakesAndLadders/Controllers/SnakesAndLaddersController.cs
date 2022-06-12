using Microsoft.AspNetCore.Mvc;
using SnakesAndLadders.Interfaces;

namespace SnakesAndLadders.Controllers
{
    /// <summary>
    /// Controller that handles all api calls for the snakes and ladders game
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SnakesAndLaddersController : ControllerBase
    {

        private readonly ILogger<SnakesAndLaddersController> _logger;
        private readonly ISnakesAndLaddersService _snakesAndLaddersService;

        /// <summary>
        /// controller initializer
        /// </summary>
        /// <param name="logger">logging subsystem</param>
        /// <param name="snakesAndLadders">the service backend for the game</param>
        public SnakesAndLaddersController(ILogger<SnakesAndLaddersController> logger, ISnakesAndLaddersService snakesAndLadders)
        {
            _logger = logger;
            _snakesAndLaddersService = snakesAndLadders;
        }

        /// <summary>
        /// Adds a new player and automatically plays the game
        /// </summary>
        /// <param name="Name">the player name</param>
        /// <returns>new player details</returns>
        [HttpPost]
        [Route("AddPlayer",Name ="AddPlayer")]
        public async Task<IPlayer> AddPlayer(string Name)
        {
            return await _snakesAndLaddersService.StartNewPlayerGame(Name);
        }

        /// <summary>
        /// get player status by player id
        /// </summary>
        /// <param name="playerId">the player id</param>
        /// <returns>player status and statistics</returns>
        [HttpGet]
        [Route("GetPlayer", Name = "GetPlayer")]
        public IPlayer GetPlayer(int playerId)
        {
            return _snakesAndLaddersService.GetPlayerStatus(playerId);
        }

        //[HttpGet(Name = "GetAllPlayers")]
        //public IPlayer[] GetAllPlayers()
        //{
        //    return _snakesAndLaddersService.GetPlayers().ToArray();
        //}
    }
}