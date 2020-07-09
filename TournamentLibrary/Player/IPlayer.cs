using TournamentLibrary.Models;
using TournamentLibrary.Rewards;
using TournamentLibrary.UpdateSystem;

namespace TournamentLibrary.Player
{
    public interface IPlayer
    {
        BigNumber CurrentBalance { get; }
        IPlayerProfile ProfileInfo { get; }
        IUpgradesBundle Upgrades { get; }

        void AddReward(IMoneyReward reward);
        void BuyUgrade(UpgradeItem itemToUpdate);
        bool CanPay(BigNumber fullCost);
    }
}