using System;

namespace TournamentLibrary.Models
{
    public interface IProfile
    {
        DateTime CreationDate { get; }
        string Name { get; }
        string Token { get; }

        void ChangeName(string newName);
        object Clone();
        bool Equals(IProfile other);
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}