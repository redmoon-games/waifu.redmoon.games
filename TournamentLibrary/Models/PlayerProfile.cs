using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.Models
{
    internal class PlayerProfile : IPlayerProfile
    {
        public string Name { get; private set; }
        public DateTime DateOfCreation { get; }
        public string Token { get; }

        public PlayerProfile(string name)
        {
            Name = name;
            DateOfCreation = DateTime.Now;
            Token = new Random().Next().ToString();
        }
        public void ChangeName(string newName)
        {
            Name = newName;
        }
    }
}
