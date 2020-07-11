﻿using System;
using TournamentLibrary.Team;

namespace TournamentLibrary.Models
{
    public interface ITournament
    {
        DateTime StartTime { get; }
        ITeam[] Teams { get; }

        void AddTeam(ITeam newTeam);
        ITeam GetTopTeam();
    }
}