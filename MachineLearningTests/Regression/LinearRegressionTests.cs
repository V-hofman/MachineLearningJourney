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

        [Fact]
        [Trait("Regression", "Linear")]
        public void Add5Rows_CalculateEmpiricials()
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

            var expected99 = new Tuple<decimal, decimal>(20.96871m, 63.83129m);
            var expected95 = new Tuple<decimal, decimal>(28.11248m, 56.68752m);
            var expected68 = new Tuple<decimal, decimal>(35.25624m, 49.54376m);

            Assert.Equal(expected99.Item1, Decimal.Round(sut.Empiricial99.Item1, 5));
            Assert.Equal(expected95.Item1, Decimal.Round(sut.Empiricial95.Item1, 5));
            Assert.Equal(expected68.Item1, Decimal.Round(sut.Empiricial68.Item1, 5));
            Assert.Equal(expected99.Item2, Decimal.Round(sut.Empiricial99.Item2, 5));
            Assert.Equal(expected95.Item2, Decimal.Round(sut.Empiricial95.Item2, 5));
            Assert.Equal(expected68.Item2, Decimal.Round(sut.Empiricial68.Item2, 5));
        }

        [Fact]
        [Trait("Regression", "Linear")]
        public void Add5Rows_PredictValues()
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

            var expected = new Tuple<decimal, decimal>(12m, 133.3m);
            var actual = sut.Predict(12m).First();

            Assert.Equal(expected, actual);
        }

    }
}
