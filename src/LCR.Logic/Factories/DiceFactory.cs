using LCR.Logic.Services;

namespace LCR.Logic.Factories
{
    public static class DiceFactory
    {
        public static IDiceService CreateDiceService() => new DiceService();
    }
}
