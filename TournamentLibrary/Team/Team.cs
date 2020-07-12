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
            UpgradesBundle = upgradesBundle;
            TotalScore = BigNumber.Zero;
            Players = new List<IPlayer>();
        }
        public BigNumber TotalScore { get; private set; }
        public List<IPlayer> Players { get; private set; }
        public string Name { get; }

        public IUpgradesBundle UpgradesBundle { get; }


        public void AddPlayer(IPlayer player)
        {
            Players.Add(player);
            player.Team = this;

            // TO DO:
            //Player.SetRangsScheme(_rangsScheme);
        }

        public void AddScore(BigNumber score)
        {
            TotalScore += score;
        }
    }
}
