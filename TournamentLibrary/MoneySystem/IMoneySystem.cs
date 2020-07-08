using TournamentLibrary.Models;

namespace TournamentLibrary.MoneySystem
{
    internal interface IMoneySystem
    {
        BigNumber Money { get; }

        void AddMoney(BigNumber money);
        void SubstructMoney(BigNumber money);
    }
}