using System;

namespace TournamentLibrary.Models
{
    public interface IPlayerProfile
    {
        string Name { get; }
        string Token { get; }
        DateTime DateOfCreation { get; }

        void ChangeName(string newName);
    }
}