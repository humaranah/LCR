using LCR.Logic.Enums;
using System;
using System.Collections.Generic;

namespace LCR.Logic.Services
{
    public class DiceService : IDiceService
    {
        private static readonly DiceFace[] _faces = new DiceFace[]
        {
            DiceFace.Left,
            DiceFace.Dot,
            DiceFace.Center,
            DiceFace.Dot,
            DiceFace.Right,
            DiceFace.Dot
        };

        private readonly Random _random;

        public DiceService()
        {
            _random = new Random(DateTime.Now.Millisecond);
        }

        public IEnumerable<DiceFace> RollDice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                yield return _faces[_random.Next(6)];
            }
        }
    }
}
