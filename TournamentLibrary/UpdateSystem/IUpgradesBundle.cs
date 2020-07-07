using System.Collections.Generic;
using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public interface IUpgradesBundle
    {
        Dictionary<int, int> UpgradeLvlByID { get; }

        int GetUpgradeLvl(int updateId);
        BigNumber GetUpgradePrice(int upgradeId);
        void AddLvlToUpgrade(int updateId, int numberOfUpgrades = 1);
    }
}