using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using TournamentLibrary.AnaliticsSystem;
using TournamentLibrary.Models;
using TournamentLibrary.MoneySystem;
using TournamentLibrary.Rewards;
using TournamentLibrary.Team;
using TournamentLibrary.UpdateSystem;

namespace TournamentLibrary.Player
{
    public abstract class Player : IPlayer
    {
        public IPlayerProfile ProfileInfo { get; set; }
        public BigNumber CurrentBalance { get { return _moneySystem.Money; } }
        public IUpgradesBundle Upgrades { get; set; }
        public ITeam Team { 
            get { return _team; } 
            set {
                _team = value;
                Upgrades = _team.UpgradesBundle;
            } }

        private ITeam _team;
        private IMoneySystem _moneySystem;

        public Player(
            IPlayerProfile playeProfile,
            IUpgradesBundle playerUpgradesBundle,
            IMoneySystem playerMoneySystem)
        {
            ProfileInfo = playeProfile;
            Upgrades = playerUpgradesBundle;
            _moneySystem = playerMoneySystem;
        }

        public void AddReward(IMoneyReward reward)
        {
            var moneyToAdd = reward.MoneyToAdd;
            _moneySystem.AddMoney(moneyToAdd);
            if (Team != null)
                Team.AddScore(moneyToAdd);
        }

        public void BuyUgrade(UpgradeItem itemToUpdate)
        {
            BigNumber updateCost = itemToUpdate.Price;

            if (CanPay(updateCost) == false)
                throw new InvalidExpressionException("Player profile dont't have enouth money to pay! Can't make transaction.");

            _moneySystem.SubstructMoney(updateCost);
            itemToUpdate.LvlUp();
        }

        public bool CanPay(BigNumber fullCost)
        {
            return _moneySystem.Money < fullCost;
        }
    }
}
