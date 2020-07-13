using TournamentLibrary.AchievementSys;
using TournamentLibrary.Models;
using TournamentLibrary.Rewards;
using TournamentLibrary.UpgradeSys;

namespace TournamentLibrary.Models
{
    public interface IPlayer
    {
        BigNumber CurrentBalance { get; }
        IPlayerProfile ProfileInfo { get; }
        IUpgradeSystem Upgrades { get; }
        IAchievementSystem Achievements { get; }
        ITeam Team { get; }

        void ChangeTeam(ITeam newTeam);
        void AddReward(IMoneyReward reward);
        void BuyUgrade(IUpgrade itemToUpgrade);
        bool CanPay(BigNumber priceToPay);
    }
}