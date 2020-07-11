using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public interface IUpgradeItem
    {
        string Name { get; }
        BigNumber Income { get; }
        IncomeType IncomeType { get; }
        int Lvl { get; }
        BigNumber Price { get; }

        void LvlUp();
    }
}