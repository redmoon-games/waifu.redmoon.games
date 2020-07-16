using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary.Models
{
    public class Profile : ICloneable, IEquatable<IProfile>, IProfile
    {
        public string Name { get; private set; }
        public string Token { get; }
        public DateTime CreationDate { get; }


        public Profile(string name)
            : this(name, GenerateRandomToken())
        {
        }

        public Profile(string name, string token)
        {
            Name = name;
            Token = token;
            CreationDate = DateTime.UtcNow;
        }
        public void ChangeName(string newName)
        {
            Name = newName;
        }

        public object Clone()
        {
            return new Profile(Name, Token);
        }
        public bool Equals(IProfile other)
        {
            return this.Token == other.Token;
        }
        public override bool Equals(object obj)
        {
            if (obj is IProfile player)
            {
                return player.Token == this.Token;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Token.GetHashCode();
        }
        public override string ToString()
        {
            return $"Name: {Name}";
        }
        public static bool operator ==(Profile player1, IProfile player2)
        {
            return player1.Equals(player2);
        }
        public static bool operator !=(Profile player1, IProfile player2)
        {
            return !player1.Equals(player2);
        }
        private static string GenerateRandomToken()
        {
            string token = new Random().Next().ToString();
            return token;
        }
    }
}
