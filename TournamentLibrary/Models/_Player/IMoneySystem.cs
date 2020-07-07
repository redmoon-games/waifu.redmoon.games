namespace TournamentLibrary.Models
{
    internal interface IMoneySystem
    {
        BigNumber Money { get; }

        void AddMoney(BigNumber money, RewardType rewardType);
        void SubstructMoney(BigNumber money);
    }
}