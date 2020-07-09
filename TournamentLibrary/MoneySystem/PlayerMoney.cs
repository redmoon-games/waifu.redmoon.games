using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.MoneySystem
{
    public class PlayerMoney : IMoneySystem
    {
        public BigNumber Money { get; private set; }

        public PlayerMoney()
        {
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
