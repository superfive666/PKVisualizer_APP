using Newtonsoft.Json;

namespace interactivegraph.Entities
{
    public class GraphSettings
    {
        #region Public constructor
        /// <summary>
        /// Publically instantiate the horizonal max and vertical max
        /// </summary>
        public GraphSettings() { }
        #endregion

        [JsonProperty("HorizontalMax")]
        public double HorizontalMax { get; set; }

        [JsonProperty("VerticalMax")]
        public double VerticalMax { get; set; }

        public double[] HorizontalTicks { get; set; }
        public double[] VerticalTicks { get; set; }
    }
}