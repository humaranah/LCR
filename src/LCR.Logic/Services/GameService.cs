using LCR.Logic.Enums;
using LCR.Logic.Factories;
using LCR.Logic.Models;
using System;

namespace LCR.Logic.Services
{
    public class GameService : IGameService
    {
        #region Dependencies
        private readonly IDiceService _diceService;
        #endregion

        #region Attributes
        private int _currentIndex = -1;
        #endregion

        #region Constructor
        public GameService(IDiceService diceService) => _diceService = diceService;
        #endregion

        #region Properties
        public string Error { get; set; }
        public Game GameData { get; set; }

        public Player CurrentPlayer =>
            GameData.Players[_currentIndex];

        public Player RightPlayer =>
            GameData.Players[(_currentIndex + 1) % GameData.Players.Count];

        public Player LeftPlayer =>
            GameData.Players[(_currentIndex + GameData.Players.Count - 1) % GameData.Players.Count];
        #endregion

        #region Public methods
        public void Initialize(GameSettings settings)
        {
            (Error, GameData) = GameFactory.CreateGame(settings);
            _currentIndex = -1;
        }

        public void PlayGame()
        {
            if (GameData == null)
            {
                return;
            }

            while (GameData.EmptyPlayers < GameData.Players.Count)
            {
                _currentIndex = (_currentIndex + 1) % GameData.Players.Count;
                DoPlayerTurn();
                ++GameData.TurnNumber;
            }
        }
        #endregion

        #region Utility methods
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
        #endregion
    }
}
