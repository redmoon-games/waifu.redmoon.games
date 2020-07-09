using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    internal interface IUpgradeItem
    {
        BigNumber Income { get; }
        IncomeType IncomeType { get; }
        int Lvl { get; }
        BigNumber Price { get; }

        void LvlUp();
    }
}