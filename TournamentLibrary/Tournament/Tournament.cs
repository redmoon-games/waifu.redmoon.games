using System;
using System.Collections.Generic;
using System.Linq;
using TournamentLibrary.Player;
using TournamentLibrary.Team;

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

        public void AddTeam(ITeam newTeam)
        {
            List<ITeam> newTeamList = Teams.ToList();
            newTeamList.Add(newTeam);
            Teams = newTeamList.ToArray();
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
    }
}
