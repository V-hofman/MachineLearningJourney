using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning.Regression
{
    public class DataModel
    {
        public HashSet<string> FeatureNames;
        public HashSet<Tuple<decimal, decimal>> FeatureData;

        public DataModel(HashSet<string> featureNames, HashSet<Tuple<decimal, decimal>> featureData)
        {
            this.FeatureNames = featureNames;
            this.FeatureData = featureData;
        }
    }
}
