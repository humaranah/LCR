using LCR.Logic.Models;

namespace LCR.Logic.Services
{
    public interface IGameManagementService
    {
        public (string, RunResults) RunGames();
    }
}
