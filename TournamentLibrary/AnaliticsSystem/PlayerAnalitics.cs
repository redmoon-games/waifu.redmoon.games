using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.AnaliticsSystem
{
    public class PlayerAnalitics : Analitics, IScore, IPlayerAnalitics
    {
        public BigNumber Score { get; private set; }
        public ITeam Team { get; }

        public void AddScore(BigNumber score)
        {
            Score += score;
            Team.Analitics.AddScore(Score);
            PassDataToDB();
        }
    }
}
