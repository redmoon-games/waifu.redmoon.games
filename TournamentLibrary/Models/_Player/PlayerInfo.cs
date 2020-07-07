using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary.Models._Player
{
    abstract class PlayerInfo
    {
        public string Name { get; set; }
        public BigNumber Money { get; set; }
    }
}
