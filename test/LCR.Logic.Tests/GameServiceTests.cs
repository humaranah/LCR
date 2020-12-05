using LCR.Logic.Factories;
using LCR.Logic.Models;
using Xunit;

namespace LCR.Logic.Tests
{
    public class GameServiceTests
    {
        [Fact]
        public void BasicSettings_Game_GeneratesTurnsCount()
        {
            var settings = new GameSettings
            {
                ChipsPerPlayer = 1,
                PlayerCount = 3
            };
            var diceService = DiceFactory.CreateDiceService();
            var basicGame = GameFactory.CreateGameService(diceService);
            basicGame.Initialize(settings);
            basicGame.PlayGame();
            Assert.NotEqual(0, basicGame.GameData.TurnNumber);
        }
    }
}
