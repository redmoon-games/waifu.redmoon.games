using System;

namespace TournamentLibrary.Models
{
    public interface ITournament
    {
        DateTime StartTime { get; }
        ITeam[] Teams { get; }

        ITeam GetTopTeam();
        ITeam GetWinner();
    }
}