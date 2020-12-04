using LCR.Logic.Enums;
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

        public Player CurrentPlayer =>
            GameData.Players[_currentIndex];

        public Player RightPlayer =>
            GameData.Players[(_currentIndex + 1) % GameData.Players.Count];

        public Player LeftPlayer =>
            GameData.Players[(_currentIndex + GameData.Players.Count - 1) % GameData.Players.Count];

        public void PlayGame()
        {
            while (GameData.EmptyPlayers < GameData.Players.Count)
            {
                _currentIndex = (_currentIndex + 1) % GameData.Players.Count;
                DoPlayerTurn();
                ++GameData.TurnNumber;
            }
        }

        private void DoPlayerTurn()
        {
            if (CurrentPlayer.ChipsCount == 0)
            {
                return;
            }

            var rollTimes = Math.Min(CurrentPlayer.ChipsCount, 3);
            foreach (var result in _diceService.RollDice(rollTimes))
            {
                UpdateChips(result);
            }

            if (CurrentPlayer.ChipsCount == 0)
            {
                GameData.EmptyPlayers++;
            }
        }

        private void UpdateChips(DiceFace face)
        {
            switch (face)
            {
                case DiceFace.Dot:
                    return;
                case DiceFace.Center:
                    ++GameData.CenterPotCount;
                    break;
                case DiceFace.Left:
                    ++RightPlayer.ChipsCount;
                    break;
                case DiceFace.Right:
                    ++LeftPlayer.ChipsCount;
                    break;
            }

            --CurrentPlayer.ChipsCount;
        }
    }
}
