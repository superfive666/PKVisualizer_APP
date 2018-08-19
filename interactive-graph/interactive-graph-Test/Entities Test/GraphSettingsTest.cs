using Xunit;
using interactivegraph.Entities;
using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace interactive_graph_Test.Entities_Test
{
    public partial class GraphSettingsTest
    {
        GraphSettings _graphSettings;

        private void DeserializeGraphSetting()
        {
            try
            {
                using (var fs = File.Open(TestConstants.GraphSetting, FileMode.Open))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        _graphSettings = JsonConvert.DeserializeObject<GraphSettings>(sr.ReadToEnd());
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        [Fact]
        public void GraphSetting_Serialization_Test ()
        {
            DeserializeGraphSetting();
            Assert.Equal(1000, _graphSettings.HorizontalMax);
            Assert.Equal(2000, _graphSettings.VerticalMax);
        }

        [Fact]
        public void GraphSetting_Attributes_Test ()
        {
            _graphSettings = new GraphSettings();
            _graphSettings.HorizontalTicks = new double[] { 0, 0.1, 0.2, 0.3, 0.4, 0.5 };
            _graphSettings.VerticalTicks = new double[] { 0, 0.1, 0.2, 0.3, 0.4, 0.5 };

            Assert.Equal(6, _graphSettings.HorizontalTicks.Length);
            Assert.Equal(6, _graphSettings.VerticalTicks.Length);

            Assert.Equal(0.5, _graphSettings.HorizontalTicks[5]);
            Assert.Equal(0.5, _graphSettings.VerticalTicks[5]);
        }

    }
}
