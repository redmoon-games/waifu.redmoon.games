using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public class UpgradeModel
    {
        public int Id { get; }
        public string Name { get; }
        public BigNumber UpgradePrice { get; private set; }
        public BigNumber Income { get; private set; }
        public BigNumber IncomePerLvl { get; private set; }
        public float GrowthRate { get; private set; }


        public UpgradeModel(int id, string name, BigNumber price, BigNumber income, float growthRate)
        {
            Id = id;
            Name = name;
            UpgradePrice = price;
            Income = income;
            GrowthRate = growthRate;
        }

        public UpgradeModel(string name, BigNumber price, BigNumber income, float growthRate)
            : this(0, name, price, income, growthRate)
        {
        }
    }
}
