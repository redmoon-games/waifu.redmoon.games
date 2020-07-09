using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.AnaliticsSystem
{
    public interface IScore
    {
        BigNumber Score { get; }
        void AddScore(BigNumber score);
    }
}
