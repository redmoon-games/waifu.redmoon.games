using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using TournamentLibrary.MoneySystem;
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

            UpgradeSystemType playerUpgradeSystem = ChooseUpgradeSystem(team);
            updates = UpdateSystemFactory.Create(playerUpgradeSystem);
        }

        private static UpgradeSystemType ChooseUpgradeSystem(ITeam team)
        {
            UpgradeSystemType playerUpgradeSystem;
            if (team.Name == "Rem")
                playerUpgradeSystem = UpgradeSystemType.Rem;
            else
                playerUpgradeSystem = UpgradeSystemType.Rem;
            return playerUpgradeSystem;
        }

        public void AddClickReward()
        {
            BigNumber moneyToAdd = updates.MoneyPerClick;
            moneySystem.AddMoney(moneyToAdd);
            statistic.PlayerGetClickReward();
        }

        public void AddSecondReward()
        {
            BigNumber moneyToAdd = updates.MoneyPerSec;
            moneySystem.AddMoney(moneyToAdd);
            statistic.PlayerGetSecReward();
        }

        public void BuyUpdate(int UpgradeID, BigNumber updateCost, int numberOfUpdates = 1)
        {
            BigNumber fullCost;
            if (numberOfUpdates < 1)
                throw new ArgumentOutOfRangeException($"numberOfUpdates: {numberOfUpdates}\nShould be greather than 0!");
            else if (numberOfUpdates > 1)
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
