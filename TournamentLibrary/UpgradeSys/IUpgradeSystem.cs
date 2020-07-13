using TournamentLibrary.Models;

namespace TournamentLibrary.UpgradeSys
{
    public interface IUpgradeSystem
    {
        BigNumber MoneyPerClick { get; }
        BigNumber MoneyPerSec { get; }
        Upgrade[] Bundle { get; }

        void AddLvlToUpgrade(int updateId, int numberOfUpgrades = 1);
    }
}