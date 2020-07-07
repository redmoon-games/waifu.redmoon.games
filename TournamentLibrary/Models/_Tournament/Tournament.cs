using System;
using System.Collections.Generic;
using System.Linq;

namespace TournamentLibrary.Models
{
    public abstract class Tournament : ITournament
    {
        public ITeam[] Teams { get; private set; }
        public DateTime StartTime { get; }
        public List<IPlayer> Players { get; }

        public Tournament(ITeam[] teams)
        {
            StartTime = DateTime.Now;
            Teams = teams;
            Players = new List<IPlayer>();
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

        public void AddPlayer(IPlayer player, ITeam toTeam)
        {
            player.SetTeam(toTeam);
            Players.Add(player);
        }
    }
}
