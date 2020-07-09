using TournamentLibrary.Models;

namespace TournamentLibrary.AnaliticsSystem
{
    public interface ITeamAnalitics
    {
        BigNumber Score { get; }
        ITournament Tournament { get; }

        void AddScore(BigNumber score);
    }
}