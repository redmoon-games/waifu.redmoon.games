namespace TournamentLibrary.Models
{
    public interface IPlayer
    {
        IPlayerInfo ProfileInfo { get; }

        void BuyUpdate(int UpgradeID, BigNumber updateCost, int numberOfUpdates = 1);
        void AddClickReward();
        void AddSecondReward();
    }
}