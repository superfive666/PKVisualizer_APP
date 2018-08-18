using interactivegraph.Helpers;

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
        }
        #endregion

        public double Mean { get; private set; }
        public double StandardDeviation { get; private set; }

        public double AdjustedMean { get; private set; }
        public double AdjustedStdDev { get; private set; }

        public override bool Equals(object obj)
        {
            var _variable = obj as DistributionVariable;
            var type = _variable.GetType();
            var properties = type.GetProperties();
            foreach(var prop in properties)
            {
                var value = type.GetProperty(prop.Name)
                                .GetValue(_variable);
                if (type.GetProperty(prop.Name)
                        .GetValue(this).ToString() != value.ToString())
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 13;

            hash = (hash * 7) + Mean.GetHashCode();
            hash = (hash * 7) + StandardDeviation.GetHashCode();
            hash = (hash * 7) + AdjustedMean.GetHashCode();
            hash = (hash * 7) + AdjustedStdDev.GetHashCode();

            return hash;
        }
    }
}