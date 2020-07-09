using System;
using TournamentLibrary.Models;

namespace TournamentLibrary.AnaliticsSystem
{
    public class TeamAnalitics : Analitics, IScore, ITeamAnalitics
    {
        public BigNumber Score { get; private set; }
        public ITournament Tournament { get; }

        public void AddScore(BigNumber score)
        {
            Score += score;
            Tournament.Analitics.AddScore(score);
            PassDataToDB();
        }
    }
}
