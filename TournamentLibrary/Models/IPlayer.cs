using System;
using TournamentLibrary.AchievementSys;
using TournamentLibrary.Rewards;
using TournamentLibrary.UpgradeSys;

namespace TournamentLibrary.Models
{
    public interface IPlayer
    {
        IAchievementSystem Achievements { get; }
        BigNumber CurrentBalance { get; }
        IProfile ProfileInfo { get; }
        IUpgradeSystem Upgrades { get; }

        event EventHandler<PlayerEventArgs> PlayerHasBeenUpdated;

        void AddReward(IMoneyReward reward);
        void BuyUgrade(IUpgrade itemToUpdate);
        bool CanPay(BigNumber fullCost);
    }
}