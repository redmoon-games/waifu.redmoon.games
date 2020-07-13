using TournamentLibrary.Models;
using TournamentLibrary.UpgradeSys;

namespace TournamentLibrary.Rewards
{
    public class TimeReward : IMoneyReward
    {
        public BigNumber MoneyToAdd { get; }

        public TimeReward(IUpgradeSystem upgrades, float time)
        {
            MoneyToAdd = upgrades.MoneyPerSec * time;
        }
    }
}