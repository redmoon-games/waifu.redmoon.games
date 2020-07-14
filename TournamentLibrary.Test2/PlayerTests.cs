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
    public class PlayerTests
    {
        [Fact]
        public void Tournament_ShouldBeAbleToBuyUpgrade()
        {
            IPlayer player = new RemPlayer("New One");
            player.AddReward(new InstantMoneyReward(new BigNumber(1, 2)));
            for (int i = 0; i < 3; i++)
            {
                player.BuyUgrade(player.Upgrades.Bundle[0]);
            }

            bool expected = true;

            bool actual = player.Upgrades.Bundle[0].Lvl == 3;

            Assert.Equal(expected, actual);
        }
    }
}
