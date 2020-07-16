using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary.Models;
using TournamentLibrary.UpgradeSys;
using Xunit;

namespace TournamentLibrary.Test
{
    public class ItemModelTest
    {
        [Fact]
        public void ShouldBeAbleToSaveName()
        {
            string name = "Уборка особняка";
            IScheme item = new Scheme(name, new BigNumber(25, 0), new BigNumber(2, 0), 1.25f);
            var expected = name;

            var actual = item.Name;

            Assert.Equal(expected, actual);
        }
    }
}
