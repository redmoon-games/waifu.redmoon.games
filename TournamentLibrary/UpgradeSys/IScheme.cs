using TournamentLibrary.Models;

namespace TournamentLibrary.UpgradeSys
{
    public interface IScheme
    {
        float GrowthRate { get; }
        BigNumber IncomePerLvl { get; }
        string Name { get; }
        BigNumber StartPrice { get; }
        IncomeType Type { get; }
    }
}