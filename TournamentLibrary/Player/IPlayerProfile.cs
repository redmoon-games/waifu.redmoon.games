using System;

namespace TournamentLibrary.Player
{
    public interface IPlayerProfile
    {
        string Login { get; }
        DateTime DateOfCreation { get; }
    }
}