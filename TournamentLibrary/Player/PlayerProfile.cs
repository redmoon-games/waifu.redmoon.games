using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.Player
{
    internal abstract class PlayerProfile : IPlayerProfile
    {
        public string Login { get; private set; }
        public DateTime DateOfCreation { get; }

        public PlayerProfile(string name)
        {
            Login = name;
            DateOfCreation = DateTime.Now;
        }
    }
}
