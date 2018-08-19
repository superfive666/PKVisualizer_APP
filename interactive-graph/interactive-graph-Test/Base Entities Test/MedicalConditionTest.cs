using interactivegraph.Base_Entities;
using Xunit;

namespace interactive_graph_Test.Base_Entities_Test
{
    public partial class MedicalConditionTest
    {
        MedicalCondition _condition = new MedicalCondition();

        private void SetMedicalCondition(double m, double s)
        {
            var type = _condition.GetType();
            var properties = type.GetProperties();
            foreach(var prop in properties)
            {
                _condition.GetType().GetProperty(prop.Name)
                          .SetValue(_condition, new DistributionVariable(m, s));
            }
        }


        [Fact]
        public void MedicalCondition_Attribute_Test ()
        {
            var compare = new DistributionVariable(10, 1);
            SetMedicalCondition(10, 1);

            foreach(var prop in _condition.GetType().GetProperties())
            {
                var obj = _condition.GetType().GetProperty(prop.Name)
                                    .GetValue(_condition);
                Assert.True(obj.Equals(compare));
            }
        }
    }
}
