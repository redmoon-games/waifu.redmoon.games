using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;
using TournamentLibrary.UpgradeSys;

namespace TournamentLibrary.CustomTeam
{
    public class RemTeam : Team
    {
        public static UpgradeSystem CustomUpgradesBundle {
            get
            {
                Scheme scheme1 = new Scheme("Уборка особняка", new BigNumber(25, 0), new BigNumber(2, 0), 1.25f);
                Scheme scheme2 = new Scheme("Удар моргенштерном", new BigNumber(1, 1), new BigNumber(10, 0), 1.35f);
                Scheme scheme3 = new Scheme("Водная магия", new BigNumber(1, 2), new BigNumber(125, 1), 1.45f);
                Scheme scheme4 = new Scheme("Демоническая форма", new BigNumber(1, 3), new BigNumber(142, 2), 1.65f);
                Upgrade item1 = new Upgrade(scheme1, IncomeType.PerClick);
                Upgrade item2 = new Upgrade(scheme2, IncomeType.PerSec);
                Upgrade item3 = new Upgrade(scheme3, IncomeType.PerSec);
                Upgrade item4 = new Upgrade(scheme4, IncomeType.PerSec);
                Upgrade[] upgradesPreset = new Upgrade[] { item1,  item2, item3, item4, };
                UpgradeSystem upgradesBundle = new UpgradeSystem(upgradesPreset);
                return upgradesBundle;
            } }

        public RemTeam(string name) : base(name, CustomUpgradesBundle)
        {

        }

        private static string[] _rangs = new string[]
        {
            "Бесславный ",
            "Новичок",
            "Пляжный задира",
            "Икона стиля",
            "Королева Пляжа",
        };
        
    }
}
