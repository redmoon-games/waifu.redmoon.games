namespace TournamentLibrary.AchievementSys
{
    public interface IAchievementSystem
    {
        IAchievement[] Achievements { get; }

        IAchievement[] UplockedAchievements { get; }
        IAchievement[] LockedAchievements { get; }

        void UnlockAchievement(int id);
    }
}