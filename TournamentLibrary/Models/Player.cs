using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using TournamentLibrary.AchievementSys;
using TournamentLibrary.CustomTeam;
using TournamentLibrary.Models;
using TournamentLibrary.MoneySys;
using TournamentLibrary.Rewards;
using TournamentLibrary.UpgradeSys;

namespace TournamentLibrary.Models
{
    public abstract class Player : IPlayer, IEquatable<Player>
    {
        public BigNumber CurrentBalance => _moneySystem.Money;
        public IPlayerProfile ProfileInfo { get; }
        public IUpgradeSystem Upgrades { get; internal set; }
        public IAchievementSystem Achievements { get; }

        private readonly IMoneySystem _moneySystem;

        public event EventHandler<PlayerEventArgs> PlayerHasBeenUpdated;

        private void OnPlayerHasBeenUpdated()
        {
            PlayerEventArgs playerEventArgs = new PlayerEventArgs();
            playerEventArgs.Name = this.ProfileInfo.Name;
            PlayerHasBeenUpdated?.Invoke(this, playerEventArgs);
        }

        private void OnPlayerHasBeenUpdated(BigNumber scoreToAdd)
        {
            PlayerEventArgs playerEventArgs = new PlayerEventArgs();
            playerEventArgs.Name = this.ProfileInfo.Name;
            playerEventArgs.MoneyToAdd = scoreToAdd;
            PlayerHasBeenUpdated?.Invoke(this, playerEventArgs);
        }

        public Player(
            IPlayerProfile playeProfile,
            IUpgradeSystem playerUpgradesBundle,
            IMoneySystem playerMoneySystem,
            IAchievementSystem achievementSystem)
        {
            ProfileInfo = playeProfile;
            Upgrades = playerUpgradesBundle;
            _moneySystem = playerMoneySystem;
            Achievements = achievementSystem;
        }

        public void AddReward(IMoneyReward reward)
        {
            BigNumber moneyToAdd = reward.MoneyToAdd;

            _moneySystem.AddMoney(moneyToAdd);
            OnPlayerHasBeenUpdated(moneyToAdd);
        }

        public void BuyUgrade(IUpgrade itemToUpdate)
        {
            BigNumber updateCost = itemToUpdate.Price;

            if (CanPay(updateCost) == false)
                throw new InvalidExpressionException("Player profile dont't have enouth money to pay! Can't make transaction.");

            _moneySystem.SubstructMoney(updateCost);
            itemToUpdate.LvlUp();
        }

        public bool CanPay(BigNumber fullCost)
        {
            return _moneySystem.Money > fullCost;
        }

        public bool Equals(Player other)
        {
            return Equals((object)other);
        }

        public override bool Equals(object obj)
        {
            if(obj is Player player)
            {
                return player.ProfileInfo.Name == this.ProfileInfo.Name;

            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ProfileInfo.Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {this.ProfileInfo.Name}, Money: {this.CurrentBalance}";
        }
    }
}
