using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary.AchievementSys
{
    public class Achievement : IAchievement
    {
        public string Name { get; }
        public string Description { get; }
        public bool IsUnlocked { get; private set; }

        public Achievement(string name, string description)
        {
            Name = name;
            Description = description;
            IsUnlocked = false;
        }

        public void Unlock()
        {
            IsUnlocked = true;
        }
    }
}
