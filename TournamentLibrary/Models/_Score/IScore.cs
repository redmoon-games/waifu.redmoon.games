namespace TournamentLibrary.Models
{
    public interface IScore
    {
        float Amount { get; }
        int Discharge { get; }


        Score Zero();
        string ToString();
    }
}