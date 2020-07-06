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
        void ClickEarn();
        void SecondsEarn();
        void SubstructMoney(Score money);
    }
}