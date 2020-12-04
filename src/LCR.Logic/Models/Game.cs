using System.Collections.Generic;

namespace LCR.Logic.Models
{
    public class Game
    {
        public int CenterPotCount { get; set; }

        public List<Player> Players { get; set; }

        public int TurnNumber { get; set; }

        public int EmptyPlayers { get; set; }
    }
}
