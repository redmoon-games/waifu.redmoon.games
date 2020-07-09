using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public class UpgradeScheme : IUpgradeScheme
    {
        public string Name { get; }
        public IncomeType Type { get; }
        public BigNumber IncomePerLvl { get; }
        public BigNumber StartPrice { get; }
        public float GrowthRate { get; }

        public UpgradeScheme(
            string name,
            BigNumber startPrice,
            BigNumber incomePerLvl,
            float growthRate)
        {
            Name = name;
            StartPrice = startPrice;
            IncomePerLvl = incomePerLvl;
            GrowthRate = growthRate;
        }
    }
}
