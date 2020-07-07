using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary.Models
{
    public abstract class Team : ITeam
    {
        private BigNumber _score;

        public string[] Rangs;
        public List<UpgradeModel> Upgrades;

        protected Team()
        {
            Name = "No name team";
            List<UpgradeModel> Upgrades = new List<UpgradeModel>();
        }

        public string Name { get; }
        public BigNumber TotalScore => _score;


        public void AddScore(BigNumber score)
        {
            _score += score;
        }
    }
}
