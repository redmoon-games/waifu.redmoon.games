using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary.Models
{
    public abstract class Team : ITeam
    {
        private Score _score;

        protected Team(string name)
        {
            Name = name;
            _score = TotalScore.Zero();
            Players = new List<IPlayer>();
        }

        public string Name { get; }
        public List<IPlayer> Players { get; }
        public IScore TotalScore => _score;


        public void AddScore(Score score)
        {
            _score += score;
        }

        public void AddPlayer(IPlayer newPlayer)
        {
            Players.Add(newPlayer);
        }
    }
}
