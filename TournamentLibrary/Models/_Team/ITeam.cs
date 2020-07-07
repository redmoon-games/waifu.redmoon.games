using System.Collections.Generic;

namespace TournamentLibrary.Models
{
    public interface ITeam
    {
        string Name { get; }
        BigNumber TotalScore { get; }


        void AddScore(BigNumber score);
    }
}