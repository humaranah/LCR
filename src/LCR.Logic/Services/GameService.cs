using LCR.Logic.Models;
using System;

namespace LCR.Logic.Services
{
    public class GameService : IGameService
    {
        private readonly IDiceService _diceService;

        private int _currentIndex = -1;

        public GameService(IDiceService diceService)
        {
            _diceService = diceService;
        }

        public Game GameData { get; set; }

        public void PlayGame()
        {
            while (GameData.EmptyPlayers < GameData.Players.Count)
            {
                _currentIndex = GetRight();
                DoPlayerTurn();
            }
        }

        private int GetRight() => (_currentIndex + 1) % GameData.Players.Count;

        private int GetLeft() => (_currentIndex + GameData.Players.Count - 1) % GameData.Players.Count;

        private void DoPlayerTurn()
        {
            var player = GameData.Players[_currentIndex];
            if (player.ChipsCount == 0)
            {
                return;
            }

            var rollTimes = Math.Min(player.ChipsCount, 3);
            foreach (var result in _diceService.RollDice(rollTimes))
            {
                switch (result)
                {
                    case Enums.DiceFace.Left:
                        --player.ChipsCount;
                        ++GameData.Players[GetLeft()].ChipsCount;
                        break;
                    case Enums.DiceFace.Center:
                        --player.ChipsCount;
                        ++GameData.CenterPotCount;
                        break;
                    case Enums.DiceFace.Right:
                        --player.ChipsCount;
                        ++GameData.Players[GetRight()].ChipsCount;
                        break;
                }
            }

            if (player.ChipsCount == 0)
            {
                GameData.EmptyPlayers++;
            }
        }
    }
}
