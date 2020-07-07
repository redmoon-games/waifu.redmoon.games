using System.Collections.Generic;
using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public interface IUpgradesBundle
    {
        BigNumber MoneyPerClick { get; }
        BigNumber MoneyPerSec { get; }

        bool IdIsExist(int id);

        int GetUpgradeLvl(int updateId);
        BigNumber GetUpgradePrice(int upgradeId);
        void AddLvlToUpgrade(int updateId, int numberOfUpgrades = 1);
    }
}