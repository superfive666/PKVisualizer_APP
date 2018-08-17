using System.IO;
using Xunit;
using interactivegraph.Entities;
using interactivegraph.Base_Entities;
using interactivegraph.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace interactive_graph_Test.Entities_Test
{
    public class PopulationTest
    {
        Population _population;

        [Fact]
        public void PopulationAttributes_Test ()
        {
            
            _population = new Population(GraphType.Continuous_Intravenous_Analgesic);
            Assert.NotNull(_population.Patients);
        }
    }
}
