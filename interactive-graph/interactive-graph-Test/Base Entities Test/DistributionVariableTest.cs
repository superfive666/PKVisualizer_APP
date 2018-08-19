using Xunit;
using interactivegraph.Base_Entities;
using interactivegraph.Helpers;

namespace interactive_graph_Test.Base_Entities_Test
{
    public partial class DistributionVariableTest
    {
        DistributionVariable _variable;

        [Fact]
        public void DistributionVariable_Attribute_Test ()
        {
            var expectedMean = 10;
            var expectedStd = 2;
            var adjustedMean = Calculator.AdjustedMean(expectedMean, expectedStd);
            var adjustedStd = Calculator.AdjustedStandardDev(expectedMean, expectedStd);

            _variable = new DistributionVariable(expectedMean, expectedStd);

            Assert.Equal(expectedMean, _variable.Mean);
            Assert.Equal(expectedStd, _variable.StandardDeviation);
            Assert.Equal(adjustedMean, _variable.AdjustedMean);
            Assert.Equal(adjustedStd, _variable.AdjustedStdDev);
        }

        [Fact]
        public void DistributionVariable_Equal_Test ()
        {
            _variable = new DistributionVariable(10, 1);
            var equalVariable = new DistributionVariable(10, 1);
            var differentVariable = new DistributionVariable(100, 10);
            Assert.True(_variable.Equals(equalVariable));
            Assert.False(_variable.Equals(differentVariable));
        }
    }
}
