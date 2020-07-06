using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TournamentLibrary.Models
{
    class Player
    {
        public string UserName { get; private set; }
        public string CurrentRank { get; set; }
        public Score Money { get; private set; }
        public int TotalCkicks { get; private set; }
        public List<string> Achievements { get; private set; }
        public ITeam CurrentTeam { get; private set; }

        public Player(string name, ITeam team)
        {
            UserName = name;
            CurrentTeam = team;
            Money = Score.Zero();
            TotalCkicks = 0;
            Achievements = new List<string>();
        }

        public void AddMoney(Score money) => Money += money;
        public void SubstructMoney(Score money) => Money -= money;

        public void ClickEarn()
        {
            if (TotalCkicks > 1_000_000_000)
                return;
            Money += new Score(1, 0);
            TotalCkicks++;
        }

        public void SecondsEarn()
        {
            Money += new Score(1, 0);
        }
    }
}
