using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.AnaliticsSystem
{
    public class TournamentAnalitics : Analitics, IScore
    {
        public BigNumber Score { get; private set; }

        public void AddScore(BigNumber score)
        {
            Score += score;
            PassDataToDB();
        }
    }
}
