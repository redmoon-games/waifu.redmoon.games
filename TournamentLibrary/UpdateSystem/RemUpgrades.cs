using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public class RemUpgrades : UpgradesBundle
    {
        private static UpgradeItem[] upgrades = new UpgradeItem[]
        {
            //Why "Score.Zero" dont work?
            new UpgradeItem(0, "Уборка особняка", new BigNumber(0, 0), new BigNumber(0, 0), 1f, IncomeType.PerClick), 
            new UpgradeItem(1, "Удар моргенштерном", new BigNumber(0, 0), new BigNumber(0, 0), 1f, IncomeType.PerSec),
            new UpgradeItem(2, "Водная магия", new BigNumber(0, 0), new BigNumber(0, 0), 1f, IncomeType.PerSec),
            new UpgradeItem(3, "Демоническая форма", new BigNumber(0, 0), new BigNumber(0, 0), 1f, IncomeType.PerSec),
        };

        public RemUpgrades() : base(upgrades)
        {
        }
    }
}
