using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary.CustomTeam;
using TournamentLibrary.Models;
using Xunit;

namespace TournamentLibrary.Test
{
    public class TournamentTests
    {
        [Fact]
        public void Tournament_ShouldBeAbleToFindWinner()
        {
            ITeam teamA = new RemTeam("First team");
            teamA.AddScore(BigNumber.One);
            ITeam teamB = new RemTeam("Second team");
            var tournament = new Tournament(new ITeam[] { teamA, teamB });

            ITeam expected = teamA;

            ITeam actual = tournament.GetTopTeam();

            Assert.Equal(expected, actual);
        }
    }
}
