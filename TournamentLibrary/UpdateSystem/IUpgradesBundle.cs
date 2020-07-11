using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public interface IUpgradesBundle
    {
        BigNumber MoneyPerClick { get; }
        BigNumber MoneyPerSec { get; }
        UpgradeItem[] Bundle { get; }

        void AddLvlToUpgrade(int updateId, int numberOfUpgrades = 1);
    }
}