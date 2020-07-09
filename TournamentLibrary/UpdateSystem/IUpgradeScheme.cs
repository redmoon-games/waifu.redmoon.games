using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public interface IUpgradeScheme
    {
        float GrowthRate { get; }
        BigNumber IncomePerLvl { get; }
        string Name { get; }
        BigNumber StartPrice { get; }
        IncomeType Type { get; }
    }
}