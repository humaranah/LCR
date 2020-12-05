using LCR.Logic.Models;
using LCR.Logic.Services;
using Microsoft.Xaml.Behaviors.Core;
using System.Text;
using System.Windows.Input;

namespace LCR.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly GameSettings _gameSettings;
        private readonly StringBuilder _output;

        public MainWindowViewModel()
        {
            _gameSettings = new GameSettings();
            _output = new StringBuilder();

            RunCommand = new ActionCommand(Run);
        }

        public int PlayerCount
        {
            get => _gameSettings.PlayerCount;
            set
            {
                if (_gameSettings.PlayerCount != value)
                {
                    _gameSettings.PlayerCount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int ChipsPerPlayer
        {
            get => _gameSettings.ChipsPerPlayer;
            set
            {
                if (_gameSettings.ChipsPerPlayer != value)
                {
                    _gameSettings.ChipsPerPlayer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int GameCount
        {
            get => _gameSettings.GameCount;
            set
            {
                if (_gameSettings.GameCount != value)
                {
                    _gameSettings.GameCount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Output
        {
            get => _output.ToString();
            set
            {
                _output.AppendLine(value);
                NotifyPropertyChanged();
            }
        }

        public ICommand RunCommand { get; }

        private void Run()
        {
            var gameManagement = new GameManagementService(_gameSettings);
            var results = gameManagement.RunGames();
            Output = $"Min: {results.Minimum}, Max: {results.Maximum}, Avg: {results.Average}";
        }
    }
}
