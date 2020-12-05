using LCR.Logic.Factories;
using LCR.Logic.Models;
using Xunit;

namespace LCR.Logic.Tests
{
    public class GameFactoryTests
    {
        [Fact]
        public void Correct_GameSettings_ReturnsNoErrorMessage()
        {
            var gameSettings = new GameSettings
            {
                PlayerCount = 3,
                ChipsPerPlayer = 1
            };

            (string message, Game game) = GameFactory.CreateGame(gameSettings);
            Assert.Empty(message);
            Assert.NotNull(game);
        }

        [Fact]
        public void LessThanThree_PlayerCount_ReturnsErrorMessage()
        {
            var gameSettings = new GameSettings { PlayerCount = 2 };

            (string message, Game game) = GameFactory.CreateGame(gameSettings);
            Assert.NotNull(message);
            Assert.Null(game);
        }

        [Fact]
        public void LessOrEqualThanZero_ChipsPerPlayer_ReturnsErrorMessage()
        {
            var gameSettings = new GameSettings { ChipsPerPlayer = 0 };

            (string message, Game game) = GameFactory.CreateGame(gameSettings);
            Assert.NotNull(message);
            Assert.Null(game);
        }
    }
}
