using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Redmoon.WebClickerLib.TestNet
{
    public class BigNumberTest
    {
        [Fact]
        public void ShouldBeAbleToEqual()
        {
            var expected = true;

            var actual = new BigNumber(1, 1).Equals(new BigNumber(1, 1));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAbleToCompare2()
        {
            Assert.True(new BigNumber(2, 2) > new BigNumber(1, 1));
            Assert.True(new BigNumber(2, 1) > new BigNumber(1, 1));
            Assert.True(new BigNumber(1, 2) > new BigNumber(100, 1));
        }
        [Fact]
        public void ShouldBeAbleToCompare3()
        {
            Assert.True(new BigNumber(1, 1) < new BigNumber(2, 2));
            Assert.True(new BigNumber(1, 1) < new BigNumber(2, 1));
            Assert.True(new BigNumber(100, 1) < new BigNumber(1, 2));
        }
        [Fact]
        public void ShouldBeAbleToCompare4()
        {
            Assert.True(new BigNumber(1, 1) == new BigNumber(1, 1));
            Assert.True(new BigNumber(1, 2) != new BigNumber(2, 1));
        }
        [Fact]
        public void ShouldBeAbleToCompare5()
        {
            Assert.True(new BigNumber(1, 1) >= new BigNumber(1, 1));
            Assert.True(new BigNumber(1, 1) <= new BigNumber(1, 1));
            Assert.True(new BigNumber(2, 1) >= new BigNumber(1, 1));
            Assert.True(new BigNumber(1, 1) <= new BigNumber(1, 2));
        }
        [Fact]
        public void ShouldBeAbleToAdd()
        {
            var expected = new BigNumber(2, 1);

            var actual = new BigNumber(1, 1) + new BigNumber(1, 1);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAbleToSubstruct()
        {
            var expected = new BigNumber(1, 1);

            var actual = new BigNumber(2, 1) - new BigNumber(1, 1);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAbleToMultyply()
        {
            var expected = new BigNumber(4, 1);

            var actual = new BigNumber(2, 1) * new BigNumber(2, 1);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAbleToDEvide()
        {
            var expected = new BigNumber(1, 1);

            var actual = new BigNumber(2, 1) / new BigNumber(2, 1);

            Assert.Equal(expected, actual);
        }
    }
}
