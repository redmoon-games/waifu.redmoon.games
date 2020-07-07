using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary.Models
{
    public abstract class PlayerInfo : IPlayerInfo
    {
        public string Name { get; private set; }
        public BigNumber Money { get; private set; }

        public PlayerInfo(string name)
        {
            Name = name;
            Money = BigNumber.Zero;
        }

        public void AddMoney(BigNumber money)
        {
            Money += money;
        }

        public void SubstructMoney(BigNumber money)
        {
            Money -= money;
        }
    }
}
