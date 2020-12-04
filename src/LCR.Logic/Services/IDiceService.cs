using LCR.Logic.Enums;
using System.Collections.Generic;

namespace LCR.Logic.Services
{
    public interface IDiceService
    {
        IEnumerable<DiceFace> RollDice(int times);
    }
}
