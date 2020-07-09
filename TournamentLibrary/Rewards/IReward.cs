using System.Numerics;
using TournamentLibrary.Models;

namespace TournamentLibrary.Rewards
{
    public interface IMoneyReward
    {
        BigNumber MoneyToAdd { get; }
    }
}