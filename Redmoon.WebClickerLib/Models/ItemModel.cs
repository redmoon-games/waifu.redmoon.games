using System;
using System.Collections.Generic;
using System.Text;

namespace Redmoon.WebClickerLib.Models
{
    public class ItemModel
    {
        public string Name { get; set; }
        public IncomeType Type { get; }
        public BigNumber IncomePerLvl { get; }
        public BigNumber StartPrice { get; }
        public float GrowthRate { get; }

        public Scheme(
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
