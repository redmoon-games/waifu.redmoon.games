namespace TournamentLibrary.Models
{
    public interface ITeam
    {
        string Name { get; }
        IScore TotalScore { get; }

        void AddScore(Score score);
    }
}