using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;
using TournamentLibrary.Player;
using TournamentLibrary.UpdateSystem;

namespace TournamentLibrary.Team
{
    public abstract class Team : ITeam
    {
        public BigNumber TotalScore { get; private set; }
        public List<IPlayer> Players { get; private set; }

        private string[] _rangsScheme;
        private IUpgradesScheme _upgradesScheme;

        protected Team()
        {
            Name = "No name team";
            List<UpgradeModel> Upgrades = new List<UpgradeModel>();
        }

        public string Name { get; }

        public void AddPlayer(IPlayer player)
        {
            Players.Add(player);
            Player.SetUpgradesScheme(_upgradesScheme);
            Player.SetRangsScheme(_rangsScheme);
        }

        public void AddScore(BigNumber score)
        {
            TotalScore += score;
        }
    }
}
