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
        }

        public string Name { get; }
        public IScore TotalScore => _score;


        public void AddScore(Score score)
        {
            _score += score;
        }
    }
}
