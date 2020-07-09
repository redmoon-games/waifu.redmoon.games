using TournamentLibrary.Models;
using TournamentLibrary.UpdateSystem;

namespace TournamentLibrary.Rewards
{
    public class TimeReward : IMoneyReward
    {
        public BigNumber MoneyToAdd { get; }

        public TimeReward(IUpgradesBundle upgrades, float time)
        {
            MoneyToAdd = upgrades.MoneyPerSec * time;
        }
    }
}