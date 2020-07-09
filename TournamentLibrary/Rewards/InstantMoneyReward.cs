using TournamentLibrary.Models;

namespace TournamentLibrary.Rewards
{
    public class InstantMoneyReward : IMoneyReward
    {
        public BigNumber MoneyToAdd { get; }

        public InstantMoneyReward(BigNumber moneyToAdd)
        {
            MoneyToAdd = moneyToAdd;
        }
    }
}