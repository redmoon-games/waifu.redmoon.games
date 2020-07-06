using System;
using System.Collections.Generic;
using System.Linq;

namespace TournamentLibrary.Models
{
    public abstract class Tournament : ITournament
    {
        public ITeam[] Teams { get; private set; }
        public DateTime StartTime { get; }

        public Tournament(ITeam[] teams)
        {
            StartTime = DateTime.Now;
            Teams = teams;
        }

        public virtual ITeam GetTopTeam()
        {
            ITeam topTeam = Teams[0];
            for (int i = 0; i < Teams.Length; i++)
            {
                if (Teams[i].TotalScore > topTeam.TotalScore)
                    topTeam = Teams[i];
            }
            return topTeam;
        }

        public ITeam GetWinner()
        {
            ITeam winner = GetTopMembersList(1).Take(1) as ITeam;
            return winner;
        }
    }
}
