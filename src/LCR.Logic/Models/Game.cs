using System.Collections.Generic;
using System.Linq;

namespace LCR.Logic.Models
{
    public class Game
    {
        public int CenterPotCount { get; set; }

        public List<Player> Players { get; set; }

        public int RoundNumber { get; set; }
    }
}
