using Redmoon.WebClickerLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Redmoon.WebClickerLib.TestNet
{
    public class ItemModelTest
    {
        [Fact]
        public void ShouldBeAbleToSaveName()
        {
            string name = "Уборка особняка";
            ItemModel item = new ItemModel(name, new BigNumber(25, 0), new BigNumber(2, 0), 1.25f);
            var expected = name;

            var actual = item.Name;

            Assert.Equal(expected, actual);
        }
    }
}
