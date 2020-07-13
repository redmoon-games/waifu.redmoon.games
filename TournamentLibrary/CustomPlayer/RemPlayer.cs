using TournamentLibrary.AchievementSys;
using TournamentLibrary.Models;
using TournamentLibrary.MoneySys;
using TournamentLibrary.UpgradeSys;

namespace TournamentLibrary.CustomPlayer
{
    public class RemPlayer : Player
    {
        private static Scheme scheme1 = new Scheme("Уборка особняка", new BigNumber(25, 0), new BigNumber(2, 0), 1.25f);
        private static Scheme scheme2 = new Scheme("Удар моргенштерном", new BigNumber(1, 1), new BigNumber(10, 0), 1.35f);
        private static Scheme scheme3 = new Scheme("Водная магия", new BigNumber(1, 2), new BigNumber(125, 1), 1.45f);
        private static Scheme scheme4 = new Scheme("Демоническая форма", new BigNumber(1, 3), new BigNumber(142, 2), 1.65f);
        private static Upgrade[] upgradesPreset = new Upgrade[] 
        {
            new Upgrade(scheme1, IncomeType.PerClick),
            new Upgrade(scheme2, IncomeType.PerSec),
            new Upgrade(scheme3, IncomeType.PerSec),
            new Upgrade(scheme4, IncomeType.PerSec),
        };
        private static Achievement[] achievements = new Achievement[] 
        {
            new Achievement("NewOne", "Description"),
            new Achievement("TrukKun", "Description"),
            new Achievement("IsekaiHere", "Description"),
            new Achievement("SummerParty", "Description"),
            new Achievement("RomanticDinner", "Description"),
            new Achievement("FanService", "Description"),
            new Achievement("OniiChan", "Description"),
            new Achievement("OnePunch", "Description"),
            new Achievement("WifuPower", "Description"),
            new Achievement("SWaifu", "Description"),
            new Achievement("PowerfullWaifu", "Description"),
            new Achievement("AntaBaka", "Description"),
        };



        public RemPlayer(string login) : base(new PlayerProfile(login),
                                              new UpgradeSystem(upgradesPreset),
                                              new PlayerMoney(),
                                              new AchievementSystem(achievements))
        {
        }
    }
}
