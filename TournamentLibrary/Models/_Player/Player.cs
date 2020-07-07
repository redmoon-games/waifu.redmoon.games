using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TournamentLibrary.UpdateSystem;

namespace TournamentLibrary.Models
{
    public class Player : IPlayer
    {
        public IPlayerInfo ProfileInfo { get; }
        public IPlayerStatistic Statistic { get; }
        public IUpgradesBundle CurrentUpdates { get; }


        public Player(string name, ITeam team)
        {
            UserName = name;
            Money = BigNumber.Zero();

            if (team.Name == "Rem")
                CurrentUpdates = UpdateSystemFactory.Create(UpgradeSystemType.Rem);
            else
                CurrentUpdates = UpdateSystemFactory.Create(UpgradeSystemType.Zui);
        }

        public void AddMoney(BigNumber money)
        {
            CurrentTeam.AddScore(money);
            Money += money;
        }

        public void SubstructMoney(BigNumber money) => Money -= money;

        public void SetTeam(ITeam team)
        {
            CurrentTeam = team;
        }

        public void ClickEarn(BigNumber moneyPerClick)
        {
            if (TotalCkicks > 1_000_000_000)
                return;
            AddMoney(moneyPerClick);
            TotalCkicks++;
        }

        public void SecondsEarn(BigNumber moneyPerSec)
        {
            AddMoney(moneyPerSec);
        }
    }
}
