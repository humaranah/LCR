using LCR.Logic.Constants;
using LCR.Logic.Models;
using LCR.Logic.Services;
using System.Collections.Generic;
using System.Linq;

namespace LCR.Logic.Factories
{
    public static class GameFactory
    {
        // Using DI with WPF implies adding code-behind in App.xaml to initialize the container.
        // I'm trying to keep clean the models.
        public static GameService CreateGameService(IDiceService diceService) => new GameService(diceService);

        public static (string, Game) CreateGame(GameSettings settings)
        {
            if (settings.PlayerCount < 3)
            {
                return (ErrorMessages.PlayerCount, null);
            }

            if (settings.ChipsPerPlayer <= 0)
            {
                return (ErrorMessages.ChipsCount, null);
            }

            return (string.Empty,
                new Game
                {
                    Players = new List<Player>(
                                Enumerable.Range(0, settings.PlayerCount)
                                    .Select(i => PlayerFactory.CreatePlayer(i, settings.ChipsPerPlayer)))
                });
        }
    }
}
