using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary.Models;
using Xunit;

namespace TournamentLibrary.Test
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
            var expected = new BigNumber(4, 2);

            var actual = new BigNumber(2, 1) * new BigNumber(2, 1); // 2 000 * 2 000 = 4 000 000

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAbleToMultyply2()
        {
            var expected = new BigNumber(1, 3);

            var actual = new BigNumber(1, 2) * new BigNumber(1, 1); // 1 000 000 * 1 000

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAbleToMultyply3()
        {
            var expected = new BigNumber(500, 1);

            var actual = new BigNumber(100, 1) * new BigNumber(0.005f, 1); // 100 000 * 5

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAbleToMultyply4()
        {
            var expected = new BigNumber(50, 3);

            var actual = new BigNumber(100, 2) * new BigNumber(0.5f, 1); // 100 000 000 * 500 = 50 000 000 000

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAbleToDevide()
        {
            var expected = new BigNumber(1, 0);

            var actual = new BigNumber(2, 1) / new BigNumber(2, 1); // 2 000 / 2 000

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAbleToDevide2()
        {
            var expected = new BigNumber(1, 1);

            var actual = new BigNumber(1, 2) / new BigNumber(1, 1); // 1 000 000 / 1 000

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAbleToDevide3()
        {
            var expected = new BigNumber(1, 2);

            var actual = new BigNumber(1000, 1) / new BigNumber(0.001f, 1); // 1 000 000 / 1

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAbleToDevide4()
        {
            var expected = new BigNumber(100, 1);

            var actual = new BigNumber(500, 2) / new BigNumber(5, 1); // 500 000 000 / 5 000

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAutoMinify()
        {
            var expected = new BigNumber(1, 2);

            var actual = new BigNumber(1000, 1);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAutoMinify2()
        {
            var expected = new BigNumber(1, 2);

            var actual = new BigNumber(500, 1) + new BigNumber(500, 1);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAutoMinify3()
        {
            var expected = new BigNumber(1, 2);

            var actual = new BigNumber(100, 1) * 10;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAutoMinify4()
        {
            var expected = new BigNumber(1, 2);

            var actual = new BigNumber(1000, 1);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAutoMinify5()
        {
            var expected = new BigNumber(100, 1);

            var actual = new BigNumber(0.1f, 2);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeAutoMinify6()
        {
            var expected = new BigNumber(1, 2); 

            var actual = new BigNumber(1, 1) * new BigNumber(1, 1); 

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeMinify()
        {
            var expected = new BigNumber(1, 1); 

            var actual = BigNumber.MinifyDischarge(new BigNumber(1000, 0));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeMinify2()
        {
            var expected = new BigNumber(1, 2); 

            var actual = BigNumber.MinifyDischarge(new BigNumber(1000, 1));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeMinify3()
        {
            var expected = new BigNumber(1, 1);

            var actual = BigNumber.MinifyDischarge(new BigNumber(0.001f, 2));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShoulBeNegative()
        {
            var expected = new BigNumber(-100, 0); 

            var actual = new BigNumber(200, 0) - new BigNumber(300, 0); 

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShoulBeNegative2()
        {
            var expected = new BigNumber(500, 1);

            var actual = new BigNumber(1, 2) - new BigNumber(500, 1);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShoulBeNegative3()
        {
            var expected = new BigNumber(500, 0);

            var actual = new BigNumber(1, 2) - new BigNumber(999, 1) - new BigNumber(500, 0);
            
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShoulBeCastable()
        {
            var expected = new BigNumber(500, 0);
            int i = 500;
            var actual = (BigNumber)i;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShoulBeCastable2()
        {
            var expected = new BigNumber(500, 0);

            float f = 500f;
            var actual = (BigNumber)f;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShoulBeCastable3()
        {
            var expected = new BigNumber(1, 2);
            int i = 1_000_000;
            var actual = (BigNumber)i;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShoulBeCastable4()
        {
            var expected = new BigNumber(1, 2);

            float f = 1_000_000f;
            var actual = (BigNumber)f;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeOkWihthInt()
        {
            var expected = new BigNumber(500, 2);

            var actual = new BigNumber(500, 1) * 1000;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeOkWihthInt2()
        {
            var expected = new BigNumber(100, 1);

            var actual = new BigNumber(500, 2) / 5000;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeOkWihthInt3()
        {
            var expected = new BigNumber(500, 1);

            var actual = new BigNumber(250, 1) + 250_000;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeOkWihthInt4()
        {
            var expected = new BigNumber(250, 1);

            var actual = new BigNumber(500, 1) - 250_000;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeOkWihthFloat()
        {
            var expected = new BigNumber(500, 2);

            var actual = new BigNumber(500, 1) * 1000f;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeOkWihthFloat2()
        {
            var expected = new BigNumber(100, 1);

            var actual = new BigNumber(500, 2) / 5000f;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeOkWihthFloat3()
        {
            var expected = new BigNumber(500, 1);

            var actual = new BigNumber(250, 1) + 250_000f;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldBeOkWihthFloat4()
        {
            var expected = new BigNumber(250, 1);

            var actual = new BigNumber(500, 1) - 250_000f;

            Assert.Equal(expected, actual);
        }
    }
}
