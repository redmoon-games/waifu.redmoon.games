using TournamentLibrary.Models;

namespace TournamentLibrary.MoneySystem
{
    public interface IMoneySystem
    {
        BigNumber Money { get; }

        void AddMoney(BigNumber money);
        void SubstructMoney(BigNumber money);
    }
}