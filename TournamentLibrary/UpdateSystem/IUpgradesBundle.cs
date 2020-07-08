using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public interface IUpgradesBundle
    {
        BigNumber MoneyPerClick { get; }
        BigNumber MoneyPerSec { get; }
        UpgradeModel[] Upgrades { get; }

        void AddLvlToUpgrade(int updateId, int numberOfUpgrades = 1);
    }
}