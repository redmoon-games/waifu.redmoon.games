using System.Collections.Generic;
using TournamentLibrary.UpgradeSys;

namespace TournamentLibrary.Models
{
    public interface ITeam
    {
        string Name { get; }
        List<IPlayer> Players { get; }
        BigNumber TotalScore { get; }
        IUpgradeSystem UpgradesBundle { get; }

        void AddPlayer(IPlayer player);
        void AddScore(BigNumber score);
    }
}