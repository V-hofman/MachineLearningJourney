using MachineLearning.Regression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningTests.Regression
{
    public class LinearRegressionTests
    {

        [Fact]
        [Trait("Regression", "Linear")]
        public void Add5Rows_CalculateMeans()
        {
            var data = new DataModel(new HashSet<string>() { "x", "y" }, new HashSet<Tuple<decimal, decimal>>()
            {
                new Tuple<decimal, decimal>(1, 30),
                new Tuple<decimal, decimal>(2, 25),
                new Tuple<decimal, decimal>(3, 38),
                new Tuple<decimal, decimal>(4, 52),
                new Tuple<decimal, decimal>(5, 67)
            });
            var sut = new LinearRegression(data);

            var expected = new Tuple<decimal, decimal>(3, 42.4m);
            Assert.Equal(expected, sut.means);
        }

        [Fact]
        [Trait("Regression", "Linear")]
        public void Add5Rows_CalculateLine()
        {
            var data = new DataModel(new HashSet<string>() { "x", "y" }, new HashSet<Tuple<decimal, decimal>>()
            {
                new Tuple<decimal, decimal>(1, 30),
                new Tuple<decimal, decimal>(2, 25),
                new Tuple<decimal, decimal>(3, 38),
                new Tuple<decimal, decimal>(4, 52),
                new Tuple<decimal, decimal>(5, 67)
            });
            var sut = new LinearRegression(data);

            var expected = new Tuple<decimal, decimal>(12.1m, 10.1m);
            Assert.Equal(expected, sut.line);
        }

        [Fact]
        [Trait("Regression", "Linear")]
        public void Add5Rows_CalculateR2()
        {
            var data = new DataModel(new HashSet<string>() { "x", "y" }, new HashSet<Tuple<decimal, decimal>>()
            {
                new Tuple<decimal, decimal>(1, 30),
                new Tuple<decimal, decimal>(2, 25),
                new Tuple<decimal, decimal>(3, 38),
                new Tuple<decimal, decimal>(4, 52),
                new Tuple<decimal, decimal>(5, 67)
            });
            var sut = new LinearRegression(data);

            var expected = 0.86950m;
            Assert.Equal(expected, Decimal.Round(sut.R2, 5));
        }

        [Fact]
        [Trait("Regression", "Linear")]
        public void Add5Rows_CalculateStandardError()
        {
            var data = new DataModel(new HashSet<string>() { "x", "y" }, new HashSet<Tuple<decimal, decimal>>()
            {
                new Tuple<decimal, decimal>(1, 30),
                new Tuple<decimal, decimal>(2, 25),
                new Tuple<decimal, decimal>(3, 38),
                new Tuple<decimal, decimal>(4, 52),
                new Tuple<decimal, decimal>(5, 67)
            });
            var sut = new LinearRegression(data);

            var expected = 7.14376m;
            Assert.Equal(expected, Decimal.Round(sut.StandardError, 5));
        }
    }
}
