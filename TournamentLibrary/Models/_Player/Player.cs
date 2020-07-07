using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using TournamentLibrary.UpdateSystem;

namespace TournamentLibrary.Models
{
    public class Player : IPlayer
    {
        public IPlayerInfo ProfileInfo { get; }

        private IMoneySystem moneySystem;
        private IPlayerStatistic statistic;
        private IUpgradesBundle updates;

        public Player(string name, ITeam team)
        {
            ProfileInfo = new WebPlayerInfo(name);

            if (team.Name == "Rem")
                updates = UpdateSystemFactory.Create(UpgradeSystemType.Rem);
            else
                updates = UpdateSystemFactory.Create(UpgradeSystemType.Zui);
        }

        public void GetClickReward()
        {
            moneySystem.AddMoney(updates.MoneyPerClick, RewardType.Click);
            statistic.PlayerGetClickReward();
        }

        public void GetSecondReward()
        {
            moneySystem.AddMoney(updates.MoneyPerSec, RewardType.Second);
            statistic.PlayerGetSecReward();
        }

        public void BuyUpdate(int UpgradeID, BigNumber updateCost, int numberOfUpdates = 1)
        {
            BigNumber fullCost;
            if (numberOfUpdates < 1)
                throw new ArgumentOutOfRangeException($"numberOfUpdates: {numberOfUpdates}\nShould be greather than 0!");

            if (updates.IdIsExist(UpgradeID) == false)
                throw new ArgumentOutOfRangeException($"There is no upgrade with ID: {UpgradeID}\n");

            if (numberOfUpdates > 1)
                fullCost = BigNumber.ConverToMaxDischarge(numberOfUpdates) * updateCost;
            else
                fullCost = updateCost;

            if (PlayerCanPay(fullCost) == false)
                throw new InvalidExpressionException("Player profile dont't have enouth money to pay! Can't make transaction.");

            moneySystem.SubstructMoney(updateCost);
            updates.AddLvlToUpgrade(UpgradeID, numberOfUpdates);
        }

        private bool PlayerCanPay(BigNumber fullCost)
        {
            return moneySystem.Money < fullCost;
        }
    }
}
