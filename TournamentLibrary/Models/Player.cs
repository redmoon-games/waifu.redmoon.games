using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using TournamentLibrary.AchievementSys;
using TournamentLibrary.Models;
using TournamentLibrary.MoneySys;
using TournamentLibrary.Rewards;
using TournamentLibrary.UpgradeSys;

namespace TournamentLibrary.Models
{
    public abstract class Player : IPlayer
    {
        public BigNumber CurrentBalance => _moneySystem.Money;
        public IPlayerProfile ProfileInfo { get; }
        public IUpgradeSystem Upgrades { get; }
        public IAchievementSystem Achievements { get; }
        public ITeam Team { get; private set; }

        private readonly IMoneySystem _moneySystem;

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
            var moneyToAdd = reward.MoneyToAdd;
            _moneySystem.AddMoney(moneyToAdd);
            if (Team != null)
                Team.AddScore(moneyToAdd);
        }

        public void BuyUgrade(IUpgrade itemToUpdate)
        {
            BigNumber updateCost = itemToUpdate.Price;

            if (CanPay(updateCost) == false)
                throw new InvalidExpressionException("Player profile dont't have enouth money to pay! Can't make transaction.");

            _moneySystem.SubstructMoney(updateCost);
            itemToUpdate.LvlUp();
        }
        public void ChangeTeam(ITeam newTeam)
        {
            Team = newTeam;
        }

        public bool CanPay(BigNumber fullCost)
        {
            return _moneySystem.Money > fullCost;
        }
    }
}
