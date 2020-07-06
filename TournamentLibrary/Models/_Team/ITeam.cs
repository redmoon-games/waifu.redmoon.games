namespace TournamentLibrary.Models
{
    public interface ITeam
    {
        string Name { get; }
        IScore Score { get; }

        void AddScore(Score score);
    }
}