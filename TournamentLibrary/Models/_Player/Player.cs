using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TournamentLibrary.Models
{
    public class Player : IPlayer
    {
        public string UserName { get; private set; }
        public string CurrentRank { get; set; }
        public Score Money { get; private set; }
        public int TotalCkicks { get; private set; }
        public List<string> Achievements { get; private set; }
        public ITeam CurrentTeam { get; private set; }

        public Player(string name)
        {
            UserName = name;
            Money = Score.Zero();
            TotalCkicks = 0;
            Achievements = new List<string>();
        }

        public void AddMoney(Score money)
        {
            CurrentTeam.AddScore(money);
            Money += money;
        }

        public void SubstructMoney(Score money) => Money -= money;

        public void SetTeam(ITeam team)
        {
            CurrentTeam = team;
        }

        public void ClickEarn(Score moneyPerClick)
        {
            if (TotalCkicks > 1_000_000_000)
                return;
            AddMoney(moneyPerClick);
            TotalCkicks++;
        }

        public void SecondsEarn(Score moneyPerSec)
        {
            AddMoney(moneyPerSec);
        }
    }
}
