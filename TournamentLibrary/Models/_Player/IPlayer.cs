using System.Collections.Generic;

namespace TournamentLibrary.Models
{
    public interface IPlayer
    {
        List<string> Achievements { get; }
        string CurrentRank { get; set; }
        ITeam CurrentTeam { get; }
        BigNumber Money { get; }
        int TotalCkicks { get; }
        string UserName { get; }

        void AddMoney(BigNumber money);
        void ClickEarn(BigNumber moneyPerClick);
        void SecondsEarn(BigNumber moneyPerSec);
        void SetTeam(ITeam team);
        void SubstructMoney(BigNumber money);
    }
}