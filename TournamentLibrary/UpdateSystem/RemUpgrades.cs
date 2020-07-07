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
            new UpgradeModel("Уборка особняка", new BigNumber(0, 0), new BigNumber(0, 0), 1f), 
            new UpgradeModel("Удар моргенштерном", new BigNumber(0, 0), new BigNumber(0, 0), 1f),
            new UpgradeModel("Водная магия", new BigNumber(0, 0), new BigNumber(0, 0), 1f),
            new UpgradeModel("Демоническая форма", new BigNumber(0, 0), new BigNumber(0, 0), 1f),
        };

        public RemUpgrades() : base(upgrades)
        {
        }
    }
}
