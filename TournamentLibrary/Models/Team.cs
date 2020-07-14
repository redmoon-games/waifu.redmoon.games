using System.Collections.Generic;
using TournamentLibrary.UpgradeSys;

namespace TournamentLibrary.Models
{
    public class Team : ITeam
    {
        public Team(string name, IUpgradeSystem upgradesBundle)
        {
            Name = name;
            UpgradesBundle = upgradesBundle;
            TotalScore = BigNumber.Zero;
            Players = new List<IPlayer>();
        }
        public BigNumber TotalScore { get; private set; }
        public List<IPlayer> Players { get; private set; }
        public string Name { get; }

        public IUpgradeSystem UpgradesBundle { get; }


        public void AddPlayer(IPlayer player)
        {
            Players.Add(player);
            player.ChangeTeam(this);
        }

        public void AddScore(BigNumber score)
        {
            TotalScore += score;
        }
    }
}
