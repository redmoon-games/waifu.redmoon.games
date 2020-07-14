namespace Redmoon.WebClickerLib.Models
{
    public interface IProfile
    {
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