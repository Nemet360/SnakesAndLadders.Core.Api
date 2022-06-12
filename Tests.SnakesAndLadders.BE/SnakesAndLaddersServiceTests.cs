using SnakesAndLadders.BE;
using SnakesAndLadders.Interfaces;

namespace Tests.SnakesAndLadders.BE
{
    [TestClass]
    public class SnakesAndLaddersServiceTests
    {
        [TestMethod]
        public async Task PlayerNotStartedGame()
        {
            var config = new MockConfigurationProvider(new Dictionary<string, string>
            {
                { "TotalBoardSlots" , "10" },
                { "NumberOfLadders" , "0" },
                { "NumberOfSnakes" , "0" }
            }).Build();


            MockCube cube = new MockCube();
            SnakesAndLaddersService service = new SnakesAndLaddersService(config, cube);
            var player = await service.StartNewPlayerGame("foo");

            Assert.AreEqual(BoardStatus.NotStarted, player.Status);
        }

        [TestMethod]
        public async Task PlayerFinishedGame()
        {
            var config = new MockConfigurationProvider(new Dictionary<string, string>
            {
                { "TotalBoardSlots" , "1" },
                { "NumberOfLadders" , "0" },
                { "NumberOfSnakes" , "0" }
            }).Build();


            MockCube cube = new MockCube();
            cube.SetCubeValue(2);

            SnakesAndLaddersService service = new SnakesAndLaddersService(config, cube);
            var player = await service.StartNewPlayerGame("foo");
            Assert.AreEqual(BoardStatus.NotStarted, player.Status);

            await Task.Delay(1000);
            var finalStatus = service.GetPlayerStatus(player.PlayerId);
            Assert.AreEqual(BoardStatus.Finished, finalStatus.Status);
            Assert.AreEqual(1, finalStatus.MovesPlayed);
            Assert.AreEqual(true, finalStatus.IsFirstPlace);
        }
    }
}