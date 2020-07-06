using System.Collections.Generic;

namespace TournamentLibrary.Models
{
    public interface IPlayer
    {
        List<string> Achievements { get; }
        string CurrentRank { get; set; }
        ITeam CurrentTeam { get; }
        Score Money { get; }
        int TotalCkicks { get; }
        string UserName { get; }

        void AddMoney(Score money);
        void ClickEarn(Score moneyPerClick);
        void SecondsEarn(Score moneyPerSec);
        void SetTeam(ITeam team);
        void SubstructMoney(Score money);
    }
}