using LCR.Logic.Models;

namespace LCR.Logic.Services
{
    public interface IGameService
    {
        Game GameData { get; }

        void PlayGame();
    }
}
