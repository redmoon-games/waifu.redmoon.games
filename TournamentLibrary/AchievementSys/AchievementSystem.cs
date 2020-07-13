using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary.AchievementSys
{
    public class AchievementSystem : IAchievementSystem
    {
        public IAchievement[] Achievements { get; private set; }
        public IAchievement[] LockedAchievements { get { return GetLocked(); } }
        public IAchievement[] UplockedAchievements { get { return GetUnlocked(); } }

        public AchievementSystem(IAchievement[] achievements)
        {
            Achievements = achievements;
        }
        public void UnlockAchievement(int id)
        {
            Achievements[id].Unlock();
        }

        private IAchievement[] GetUnlocked()
        {
            List<IAchievement> unlockedAchievements = new List<IAchievement>();
            foreach (var achievemnt in Achievements)
            {
                if (achievemnt.IsUnlocked)
                    unlockedAchievements.Add(achievemnt);
            }
            return unlockedAchievements.ToArray();
        }

        private IAchievement[] GetLocked()
        {
            List<IAchievement> lockedAchievements = new List<IAchievement>();
            foreach (var achievemnt in Achievements)
            {
                if (achievemnt.IsUnlocked == false)
                    lockedAchievements.Add(achievemnt);
            }
            return lockedAchievements.ToArray();
        }
    }
}
