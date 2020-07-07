using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public class UpgradeModel
    {
        public string Name { get; }
        public BigNumber UpgradePrice { get; private set; }
        public BigNumber Income { get; private set; }
        public BigNumber IncomePerLvl { get; private set; }
        public float GrowthRate { get; private set; }


        public UpgradeModel(string name, BigNumber price, BigNumber income, float growthRate)
        {
            Name = name;
            UpgradePrice = price;
            Income = income;
            GrowthRate = growthRate;
        }
    }
}
