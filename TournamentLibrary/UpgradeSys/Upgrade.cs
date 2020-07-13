using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.UpgradeSys
{
    public class Upgrade : IUpgrade
    {
        public BigNumber Income => _scheme.IncomePerLvl * Lvl;
        public IncomeType IncomeType { get; }
        public int Lvl { get; private set; }
        public BigNumber Price { get; private set; }
        public string Name => _scheme.Name;

        private IScheme _scheme;

        public Upgrade(IScheme scheme, IncomeType type)
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
