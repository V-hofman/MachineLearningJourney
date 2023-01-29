namespace MachineLearning.Regression
{
    public class LinearRegression
    {
        public DataModel data { get; private set; }
        public Tuple<decimal, decimal> means { get; private set; }
        public Tuple<decimal, decimal> line { get; private set; }

        public decimal R2 { get; private set; }
        public decimal StandardError { get; private set; }
        public Tuple<decimal, decimal> Empiricial99 { get; private set; }
        public Tuple<decimal, decimal> Empiricial95 { get; private set; }
        public Tuple<decimal, decimal> Empiricial68 { get; private set; }

        public LinearRegression(DataModel data)
        {
            this.data = data;
            CalculateMeans();
            this.line = CalculateLine();
            this.R2 = CalculateR2();
            this.StandardError = CalculateStandardError();
            CalculateEmpiricals();
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
            }
            else
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

        private decimal CalculateR2()
        {
            decimal numerator = 0;
            decimal denominator = 0;
            foreach (var row in this.data.FeatureData)
            {
                numerator += (row.Item2 - this.line.Item1 - this.line.Item2 * row.Item1) * (row.Item2 - this.line.Item1 - this.line.Item2 * row.Item1);
                denominator += (row.Item2 - this.means.Item2) * (row.Item2 - this.means.Item2);
            }
            return 1 - numerator / denominator;
        }

        private decimal CalculateStandardError()
        {
            decimal sum = 0;
            foreach (var row in this.data.FeatureData)
            {
                sum += (row.Item2 - this.line.Item1 - this.line.Item2 * row.Item1) * (row.Item2 - this.line.Item1 - this.line.Item2 * row.Item1);
            }
            return (decimal)Math.Sqrt((double)(sum / (this.data.FeatureData.Count - 2)));
        }
        
        private void CalculateEmpiricals()
        {
            this.Empiricial99 = new Tuple<decimal, decimal>(this.means.Item2 - 3 * this.StandardError, this.means.Item2 + 3 * this.StandardError);
            this.Empiricial95 = new Tuple<decimal, decimal>(this.means.Item2 - 2 * this.StandardError, this.means.Item2 + 2 * this.StandardError);
            this.Empiricial68 = new Tuple<decimal, decimal>(this.means.Item2 - this.StandardError, this.means.Item2 + this.StandardError);
        }
        
        public List<Tuple<decimal,decimal>> Predict(params decimal[] x)
        {
            var result = new List<Tuple<decimal, decimal>>();
            foreach (var item in x)
            {
                result.Add(new Tuple<decimal, decimal>(item, this.line.Item1 + this.line.Item2 * item));
            }
            return result;
        }
    }
}
