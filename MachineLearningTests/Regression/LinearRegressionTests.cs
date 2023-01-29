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
            var sut = new LinearRegression(RegressionTypes.LinearRegression, data);

            var expected = new Tuple<decimal, decimal>(3, (decimal)42.4);
            Assert.Equal(expected, sut.means);
        }

        [Fact]
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
            var sut = new LinearRegression(RegressionTypes.LinearRegression, data);

            var expected = new Tuple<decimal, decimal>(12.1m, 10.1m);
            Assert.Equal(expected, sut.line);
        }
    }
}
