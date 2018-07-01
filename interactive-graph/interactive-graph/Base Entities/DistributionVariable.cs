using interactivegraph.Helpers;
using interactivegraph.Entities;
using MathNet.Numerics.Distributions;

namespace interactivegraph.Base_Entities
{
    public class DistributionVariable
    {
        #region Public constructor
        /// <summary>
        /// public constructor for instantiating the mean and standard deviation of the variable.
        /// Instantiate the adjusted mean and standard deviation during object instantiation.
        /// </summary>
        /// <param name="mean"></param>
        /// <param name="std"></param>
        public DistributionVariable(double mean, double  std)
        {
            Mean = mean;
            StandardDeviation = std;
            AdjustedMean = Calculator.AdjustedMean(mean, std);
            AdjustedStdDev = Calculator.AdjustedStandardDev(mean, std);

            FinalValue = LogNormal.InvCDF(AdjustedMean, AdjustedStdDev, Population.rand.NextDouble());
        }
        #endregion

        public double Mean { get; private set; }
        public double StandardDeviation { get; private set; }

        public double AdjustedMean { get; private set; }
        public double AdjustedStdDev { get; private set; }

        public double FinalValue { get; private set; }
    }
}