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
        public UpgradeType Type { get; }
        public int Lvl { get; private set; }
        public BigNumber UpgradePrice { get; private set; }
        public BigNumber Income { get { return _incomePerLvl * Lvl; } }

        private BigNumber _incomePerLvl;
        private float _growthRate;

        public UpgradeModel(int id, string name, BigNumber price, BigNumber incomePerLvl, float growthRate, UpgradeType type)
        {
            Id = id;
            Name = name;
            UpgradePrice = price;
            _incomePerLvl = incomePerLvl;
            _growthRate = growthRate;
            Type = type;
        }

        public void UpgradeLvl()
        {
            UpgradePrice *= _growthRate;
            Lvl++;
        }
    }
}
