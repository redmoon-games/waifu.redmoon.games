namespace TournamentLibrary.Models
{
    public interface IPlayerInfo
    {
        string UserName { get; }
        string CurrentRank { get; }
        BigNumber Money { get; }
        ITeam CurrentTeam { get; }
    }
}