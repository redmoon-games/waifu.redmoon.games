using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary.Models
{
    public class PlayerEventArgs : EventArgs
    {
        public string Name { get; set; }
        public BigNumber MoneyToAdd { get; set; }
    }
}
