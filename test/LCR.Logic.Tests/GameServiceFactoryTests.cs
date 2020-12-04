using LCR.Logic.Factories;
using LCR.Logic.Models;
using LCR.Logic.Services;
using Xunit;

namespace LCR.Logic.Tests
{
    public class GameServiceFactoryTests
    {
        [Fact]
        public void Correct_GameSettings_ReturnsNoErrorMessage()
        {
            var gameSettings = new GameSettings
            {
                PlayerCount = 3,
                ChipsPerPlayer = 1
            };

            (string message, GameService service) = GameFactory.CreateGameService(gameSettings, null);
            Assert.Empty(message);
            Assert.NotNull(service);
        }

        [Fact]
        public void LessThanThree_PlayerCount_ReturnsErrorMessage()
        {
            var gameSettings = new GameSettings { PlayerCount = 2 };

            (string message, GameService service) = GameFactory.CreateGameService(gameSettings, null);
            Assert.NotNull(message);
            Assert.Null(service);
        }

        [Fact]
        public void LessOrEqualThanZero_ChipsPerPlayer_ReturnsErrorMessage()
        {
            var gameSettings = new GameSettings { ChipsPerPlayer = 0 };

            (string message, GameService service) = GameFactory.CreateGameService(gameSettings, null);
            Assert.NotNull(message);
            Assert.Null(service);
        }
    }
}
