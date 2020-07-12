using System.Collections.Generic;
using TournamentLibrary.Models;
using TournamentLibrary.Player;
using TournamentLibrary.UpdateSystem;

namespace TournamentLibrary.Team
{
    public interface ITeam
    {
        string Name { get; }
        List<IPlayer> Players { get; }
        BigNumber TotalScore { get; }
        IUpgradesBundle UpgradesBundle { get; }

        void AddPlayer(IPlayer player);
        void AddScore(BigNumber score);
    }
}