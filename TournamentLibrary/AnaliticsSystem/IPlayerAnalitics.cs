using TournamentLibrary.Models;

namespace TournamentLibrary.AnaliticsSystem
{
    public interface IPlayerAnalitics
    {
        BigNumber Score { get; }
        ITeam Team { get; }

        void AddScore(BigNumber score);
    }
}