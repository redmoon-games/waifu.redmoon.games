using TournamentLibrary.Models;
using TournamentLibrary.Rewards;
using TournamentLibrary.Team;
using TournamentLibrary.UpdateSystem;

namespace TournamentLibrary.Player
{
    public interface IPlayer
    {
        BigNumber CurrentBalance { get; }
        IPlayerProfile ProfileInfo { get; }
        IUpgradesBundle Upgrades { get; }
        ITeam Team { get; set; }

        void AddReward(IMoneyReward reward);
        void BuyUgrade(IUpgradeItem itemToUpdate);
        bool CanPay(BigNumber fullCost);
    }
}