using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary.Models
{
    public abstract class Team : ITeam
    {
        private string _name;

        protected Team(string name)
        {
            _name = name;
            Score = 0;
        }

        public string Name { get { return _name; } }
        public int Score { get; private set; }


        public void AddScore(int score)
        {
            if (score < 0)
                throw new ArgumentOutOfRangeException("Score should be grater than 0!");

            // Добавить проверку на переполнение.
            Score += score;
        }
    }
}
