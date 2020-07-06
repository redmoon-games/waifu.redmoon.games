using System;
using System.Collections.Generic;

namespace TournamentLibrary.Models
{
    public interface ITournament
    {
        List<IPlayer> Players { get; }
        DateTime StartTime { get; }
        ITeam[] Teams { get; }

        void AddPlayer(IPlayer player, ITeam toTeam);
        ITeam GetTopTeam();
    }
}