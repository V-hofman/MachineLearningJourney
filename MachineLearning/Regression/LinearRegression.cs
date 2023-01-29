namespace MachineLearning.Regression
{
    public class LinearRegression
    {
        public RegressionTypes type;
        public DataModel data;
        public Tuple<decimal, decimal> means;
        public Tuple<decimal, decimal> line;

        public LinearRegression(RegressionTypes regressionType, DataModel data)
        {
            this.type = regressionType;
            this.data = data;
            CalculateMeans();
            this.line = CalculateLine();
        }

        private void CalculateMeans()
        {
            decimal sum1 = 0;
            decimal sum2 = 0;
            foreach (var row in this.data.FeatureData)
            {
                sum1 += row.Item1;
                sum2 += row.Item2;
            }
            sum1 /= data.FeatureData.Count;
            sum2 /= data.FeatureData.Count;
            this.means = new Tuple<decimal, decimal>(sum1, sum2);
            if (!CorrectMeanCheck(this.means, this.data))
            {
                throw new Exception("Means are not correct");
            }else
            {
                CalculateB0();
            }
        }

        private bool CorrectMeanCheck(Tuple<decimal, decimal> means, DataModel data)
        {
            decimal sum1 = 0;
            decimal sum2 = 0;
            foreach (var row in data.FeatureData)
            {
                sum1 += row.Item1 - means.Item1;
                sum2 += row.Item2 - means.Item2;
            }
            return sum1 == 0 && sum2 == 0;
        }

        private Tuple<decimal, decimal> CalculateLine()
        {
            return new Tuple<decimal, decimal>(CalculateB0(), CalculateB1());
        }
        

        private decimal CalculateB1()
        {
            decimal numerator = 0;
            decimal denominator = 0;
            foreach (var row in this.data.FeatureData)
            {
                numerator += (row.Item1 - this.means.Item1) * (row.Item2 - this.means.Item2);
                denominator += (row.Item1 - this.means.Item1) * (row.Item1 - this.means.Item1);
            }
            return numerator / denominator;
        }

        private decimal CalculateB0()
        {
            return this.means.Item2 - CalculateB1() * this.means.Item1;
        }
    }
}