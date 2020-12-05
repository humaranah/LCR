using LCR.Logic.Models;

namespace LCR.Logic.Services
{
    public interface IGameService
    {
        Game GameData { get; }

        void Initialize(GameSettings settings);

        void PlayGame();
    }
}
