using TournamentLibrary.Models;

namespace TournamentLibrary.MoneySys
{
    public interface IMoneySystem
    {
        BigNumber Money { get; }

        void AddMoney(BigNumber money);
        void SubstructMoney(BigNumber money);
    }
}