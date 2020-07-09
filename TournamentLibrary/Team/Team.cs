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
        protected Team(string name, IUpgradesBundle upgradesBundle)
        {
            Name = name;
            this._upgradesBundle = upgradesBundle;
            TotalScore = BigNumber.Zero;
            Players = new List<IPlayer>();
        }
        public BigNumber TotalScore { get; private set; }
        public List<IPlayer> Players { get; private set; }
        public string Name { get; }

        private IUpgradesBundle _upgradesBundle;


        public void AddPlayer(IPlayer player)
        {
            Players.Add(player);
            player.Team = this;
            player.Upgrades = _upgradesBundle;

            // TO DO:
            //Player.SetRangsScheme(_rangsScheme);
        }

        public void AddScore(BigNumber score)
        {
            TotalScore += score;
        }
    }
}
