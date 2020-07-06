using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary.Models
{
    public abstract class Team : ITeam
    {
        private string _name;
        private Score _score;

        protected Team(string name)
        {
            _name = name;
            _score = Score.Zero();
        }

        public string Name { get { return _name; } }
        public IScore Score { get { return _score; } }


        public void AddScore(Score score)
        {
            _score += score;
        }

        public void AddMember(IPlayer newPlayer)
        {

        }
    }
}
