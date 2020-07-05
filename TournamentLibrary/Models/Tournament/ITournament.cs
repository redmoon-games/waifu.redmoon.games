using System;
using System.Collections.Generic;

namespace TournamentLibrary.Models
{
    public interface ITournament
    {
        string Name { get; }
        DateTime StartTime { get; }
        List<ITeam> TournamentMembers { get; }

        void AddMember(ITeam member);
        void AddPointsToMember(ITeam member, int points);
        List<ITeam> GetTopMembersList(int listSizeLimit = 25);
        ITeam GetWinner();
    }
}