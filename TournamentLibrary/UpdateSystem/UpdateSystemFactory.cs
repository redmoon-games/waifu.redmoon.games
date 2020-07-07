using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace TournamentLibrary.UpdateSystem
{
    internal static class UpdateSystemFactory
    {
        public static IUpgradesBundle Create(UpgradeSystemType upgradeSystemType)
        {
            switch (upgradeSystemType)
            {
                case UpgradeSystemType.Rem:
                    return new RemUpgrades();
                case UpgradeSystemType.Zui:
                    throw new Exception("class is not ready.");
                default:
                    throw new Exception("class is not ready.");
            }
        }
    }
}
