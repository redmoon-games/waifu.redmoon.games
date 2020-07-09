using TournamentLibrary.Models;

namespace TournamentLibrary.Rewards
{
    public class ClickReward : IMoneyReward
    {
        public BigNumber MoneyToAdd { get; }

        public ClickReward(BigNumber moneyToAdd)
        {
            MoneyToAdd = moneyToAdd;
        }
    }
}