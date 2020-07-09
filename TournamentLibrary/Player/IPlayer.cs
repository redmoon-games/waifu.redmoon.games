using TournamentLibrary.Models;
using TournamentLibrary.Rewards;
using TournamentLibrary.Team;
using TournamentLibrary.UpdateSystem;

namespace TournamentLibrary.Player
{
    public interface IPlayer
    {
        BigNumber CurrentBalance { get; }
        IPlayerProfile ProfileInfo { get; set; }
        IUpgradesBundle Upgrades { get; set; }
        ITeam Team { get; set; }

        void AddReward(IMoneyReward reward);
        void BuyUgrade(UpgradeItem itemToUpdate);
        bool CanPay(BigNumber fullCost);
    }
}