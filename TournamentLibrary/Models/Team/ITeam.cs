namespace TournamentLibrary.Models
{
    public interface ITeam
    {
        string Name { get; }
        int Score { get; }
        
        void AddScore(int score);
    }
}
