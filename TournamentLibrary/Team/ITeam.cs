using System.Collections.Generic;
using TournamentLibrary.Models;
using TournamentLibrary.Player;

namespace TournamentLibrary.Team
{
    public interface ITeam
    {
        string Name { get; }
        List<IPlayer> Players { get; }
        BigNumber TotalScore { get; }

        void AddPlayer(IPlayer player);
        void AddScore(BigNumber score);
    }
}