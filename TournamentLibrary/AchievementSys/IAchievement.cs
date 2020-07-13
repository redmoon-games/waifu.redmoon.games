namespace TournamentLibrary.AchievementSys
{
    public interface IAchievement
    {
        string Name { get; }
        string Description { get; }
        bool IsUnlocked { get; }

        void Unlock();
    }
}