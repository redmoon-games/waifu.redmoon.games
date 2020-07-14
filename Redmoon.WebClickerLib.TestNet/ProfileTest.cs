using Xunit;
using Redmoon.WebClickerLib.Models;

namespace Redmoon.WebClickerLib.TestCore
{
    public class ProfileTest
    {

        [Fact]
        public void Player_ShouldBeAbleToClone()
        {
            string commonName = "SS1";
            IProfile player1 = new Profile(commonName);
            IProfile player2 = player1.Clone() as Profile;

            var expected = commonName;

            var actual = player2.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Player_ShouldBeDifferentIfItsNotAClone()
        {
            IProfile player1 = new Profile("P0!");
            IProfile player2 = new Profile("P0!");

            var expected = true;

            var actual = player1 != player2;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Player_ShouldBeSameIfSameToken()
        {
            IProfile player1 = new Profile("apple", "token1");
            IProfile player2 = new Profile("orange", "token1");

            var expected = true;

            var actual = player1.Token == player2.Token;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Player_TokenShouldCopyToClone()
        {
            IProfile player1 = new Profile("P0!");
            IProfile player2 = player1.Clone() as Profile;

            var expected = player1.Token;

            var actual = player2.Token;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Player_ShouldBeSameIfItsAClone()
        {
            IProfile player1 = new Profile("P0!");
            IProfile player2 = player1.Clone() as Profile;

            var expected = true;

            var actual = player1.Equals(player2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Player_ShouldBeSameIfItsAClone2()
        {
            IProfile player1 = new Profile("P0!");
            IProfile player2 = player1.Clone() as Profile;

            var expected = true;

            var actual = (Profile)player1 == (Profile)player2;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Player_ShouldChangeName()
        {
            string newName = "A7%";
            IProfile player1 = new Profile("P0!");
            player1.ChangeName(newName);

            var expected = newName;

            var actual = player1.Name;

            Assert.Equal(expected, actual);
        }
    }
}
