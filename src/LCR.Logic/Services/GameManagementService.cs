using LCR.Logic.Factories;
using LCR.Logic.Models;
using System.Collections.Generic;
using System.Linq;

namespace LCR.Logic.Services
{
    public class GameManagementService : IGameManagementService
    {
        private readonly GameSettings _settings;

        public GameManagementService(GameSettings settings)
        {
            _settings = settings;
        }

        public RunResults RunGames()
        {
            var diceService = DiceFactory.CreateDiceService();
            var gameService = GameFactory.CreateGameService(diceService);

            var results = new List<int>();
            for (int i = 0; i < _settings.GameCount; i++)
            {
                gameService.Initialize(_settings);
                gameService.PlayGame();
                results.Add(gameService.GameData.TurnNumber);
            }

            return new RunResults
            {
                Minimum = results.Min(),
                Maximum = results.Max(),
                Average = results.Average()
            };
        }
    }
}
