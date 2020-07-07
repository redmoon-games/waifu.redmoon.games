using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public class RemUpgrades : UpgradesBundle
    {
        private static UpgradeModel[] upgrades = new UpgradeModel[]
        {
            //Why "Score.Zero" dont work?
            new UpgradeModel(0, "Уборка особняка", new BigNumber(0, 0), new BigNumber(0, 0), 1f), 
            new UpgradeModel(1, "Удар моргенштерном", new BigNumber(0, 0), new BigNumber(0, 0), 1f),
            new UpgradeModel(2, "Водная магия", new BigNumber(0, 0), new BigNumber(0, 0), 1f),
            new UpgradeModel(3, "Демоническая форма", new BigNumber(0, 0), new BigNumber(0, 0), 1f),
        };

        public RemUpgrades() : base(upgrades)
        {
        }
    }
}
