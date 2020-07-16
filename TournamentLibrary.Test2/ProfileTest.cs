using TournamentLibrary.Models;
using Xunit;

namespace TournamentLibrary.Test
{
    public class ProfileTest
    {

        [Fact]
        public void Player_ShouldBeAbleToClone()
        {
            string commonName = "SS1";
            IProfile profile1 = new Profile(commonName);
            IProfile profile2 = profile1.Clone() as Profile;

            var expected = commonName;

            var actual = profile2.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Player_ShouldBeDifferentIfItsNotAClone()
        {
            IProfile profile1 = new Profile("P0!");
            IProfile profile2 = new Profile("P0!");

            var expected = true;

            var actual = profile1 != profile2;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Player_ShouldBeSameIfSameToken()
        {
            IProfile profile1 = new Profile("apple", "token1");
            IProfile profile2 = new Profile("orange", "token1");

            var expected = true;

            var actual = profile1.Token == profile2.Token;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Player_TokenShouldCopyToClone()
        {
            IProfile profile1 = new Profile("P0!");
            IProfile profile2 = profile1.Clone() as Profile;

            var expected = profile1.Token;

            var actual = profile2.Token;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Player_ShouldBeSameIfItsAClone()
        {
            IProfile profile1 = new Profile("P0!");
            IProfile profile2 = profile1.Clone() as Profile;

            var expected = true;

            var actual = profile1.Equals(profile2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Player_ShouldBeSameIfItsAClone2()
        {
            IProfile profile1 = new Profile("P0!");
            IProfile profile2 = profile1.Clone() as Profile;

            var expected = true;

            var actual = (Profile)profile1 == (Profile)profile2;

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
