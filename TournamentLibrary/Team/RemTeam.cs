using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;
using TournamentLibrary.UpdateSystem;

namespace TournamentLibrary.Team
{
    public class RemTeam : Team
    {
        public static UpgradesBundle CustomUpgradesBundle {
            get
            {
                UpgradeScheme scheme1 = new UpgradeScheme("Уборка особняка", new BigNumber(0, 0), new BigNumber(0, 0), 1f);
                UpgradeScheme scheme2 = new UpgradeScheme("Удар моргенштерном", new BigNumber(0, 0), new BigNumber(0, 0), 1f);
                UpgradeScheme scheme3 = new UpgradeScheme("Водная магия", new BigNumber(0, 0), new BigNumber(0, 0), 1f);
                UpgradeScheme scheme4 = new UpgradeScheme("Демоническая форма", new BigNumber(0, 0), new BigNumber(0, 0), 1f);
                UpgradeItem item1 = new UpgradeItem(scheme1, IncomeType.PerClick);
                UpgradeItem item2 = new UpgradeItem(scheme2, IncomeType.PerSec);
                UpgradeItem item3 = new UpgradeItem(scheme3, IncomeType.PerSec);
                UpgradeItem item4 = new UpgradeItem(scheme4, IncomeType.PerSec);
                UpgradeItem[] upgradesPreset = new UpgradeItem[] { item1,  item2, item3, item4, };
                UpgradesBundle upgradesBundle = new UpgradesBundle(upgradesPreset);
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
