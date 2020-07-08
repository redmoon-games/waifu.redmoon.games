using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public abstract class UpgradesBundle : IUpgradesBundle
    {
        public UpgradeModel[] Upgrades { get; }
        public BigNumber MoneyPerClick
        {
            get
            {
                BigNumber moneyPerSec = BigNumber.Zero;
                foreach (var upgrade in Upgrades)
                {
                    if (upgrade.Type == UpgradeType.PerClick)
                        moneyPerSec += upgrade.Income;
                }
                return moneyPerSec;
            }
        }
        public BigNumber MoneyPerSec
        {
            get
            {
                BigNumber moneyPerSec = BigNumber.Zero;
                foreach (var upgrade in Upgrades)
                {
                    if (upgrade.Type == UpgradeType.PerSec)
                        moneyPerSec += upgrade.Income;
                }
                return moneyPerSec;
            }
        }

        public UpgradesBundle(UpgradeModel[] upgrades)
        {
            Upgrades = upgrades;
        }

        public void AddLvlToUpgrade(int updateId, int numberOfUpgrades = 1)
        {
            for (int i = 0; i < numberOfUpgrades; i++)
            {
                Upgrades[updateId].UpgradeLvl();
            }
        }
    }
}
