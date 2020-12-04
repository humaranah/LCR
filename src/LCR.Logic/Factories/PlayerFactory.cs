using LCR.Logic.Models;

namespace LCR.Logic.Factories
{
    public static class PlayerFactory
    {
        // Using DI with WPF implies adding code-behind in App.xaml to initialize the container.
        // I'm trying to keep clean the models.
        public static Player CreatePlayer(int playerNumber, int chipsCount)
            => new Player
            {
                PlayerNumber = playerNumber,
                ChipsCount = chipsCount
            };
    }
}
