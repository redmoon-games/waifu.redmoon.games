using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public class UpgradeItem : IUpgradeItem
    {
        public BigNumber Income => _scheme.IncomePerLvl * Lvl;
        public IncomeType IncomeType { get; }
        public int Lvl { get; private set; }
        public BigNumber Price { get; private set; }

        private IUpgradeScheme _scheme;

        public UpgradeItem(IUpgradeScheme scheme, IncomeType type)
        {
            if (scheme == null)
                Console.WriteLine("WTF??");
            _scheme = scheme;
            IncomeType = type;
            Price = _scheme.StartPrice;
        }

        public void LvlUp()
        {
            Price *= _scheme.GrowthRate;
            Lvl++;
        }
    }
}
