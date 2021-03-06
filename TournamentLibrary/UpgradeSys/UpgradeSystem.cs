﻿using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.UpgradeSys
{
    public class UpgradeSystem : IUpgradeSystem
    {
        public Upgrade[] Bundle { get; }
        public BigNumber MoneyPerClick
        {
            get
            {
                BigNumber moneyPerClick = BigNumber.Zero;
                foreach (var upgrade in Bundle)
                {
                    if (upgrade.IncomeType == IncomeType.PerClick)
                        moneyPerClick += upgrade.Income;
                }
                return moneyPerClick;
            }
        }
        public BigNumber MoneyPerSec
        {
            get
            {
                BigNumber moneyPerSec = BigNumber.Zero;
                foreach (var upgrade in Bundle)
                {
                    if (upgrade.IncomeType == IncomeType.PerSec)
                        moneyPerSec += upgrade.Income;
                }
                return moneyPerSec;
            }
        }

        public UpgradeSystem(Upgrade[] upgrades)
        {
            Bundle = upgrades;
        }

        public void AddLvlToUpgrade(int updateId, int numberOfUpgrades = 1)
        {
            for (int i = 0; i < numberOfUpgrades; i++)
            {
                Bundle[updateId].LvlUp();
            }
        }
    }
}
