using TournamentLibrary.Models;

namespace TournamentLibrary.UpgradeSys
{
    public interface IUpgrade
    {
        string Name { get; }
        BigNumber Income { get; }
        IncomeType IncomeType { get; }
        int Lvl { get; }
        BigNumber Price { get; }

        void LvlUp();
    }
}