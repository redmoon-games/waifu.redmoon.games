using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary.CustomPlayer;
using TournamentLibrary.CustomTeam;
using TournamentLibrary.Models;
using TournamentLibrary.Rewards;
using Xunit;

namespace TournamentLibrary.Test
{
    public class TeamTests
    {
        [Fact]
        public void Team_ShouldBeCompable()
        {
            ITeam teamA = new RemTeam("First team");
            teamA.AddScore(BigNumber.One);
            ITeam teamB = new RemTeam("Second team");

            bool expected = true;

            bool actual = teamA.TotalScore > teamB.TotalScore ;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tournament_shouldAddPlayers()
        {
            ITeam teamA = new RemTeam("First team");
            for (int i = 0; i < 10; i++)
            {
                var newPlayer = new RemPlayer($"player {i}");
                newPlayer.AddReward(new InstantMoneyReward(BigNumber.One));
                teamA.AddPlayer(newPlayer);
            }

            bool expected = true;

            bool actual = teamA.TotalScore == new BigNumber(10, 0);

            Assert.Equal(expected, actual);
        }
    }
}
