using Newtonsoft.Json;

namespace interactivegraph.Base_Entities
{
    public class Patient
    {
        #region Public constructor
        /// <summary>
        /// Public constructor takes in no parameters.
        /// Initialization of object during creation of the instance.
        /// </summary>
        public Patient() { }
        #endregion

        #region Json properties
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("Race")]
        public string Race { get; set; }

        [JsonProperty("Age")]
        public int Age { get; set; }

        [JsonProperty("BodyWeight")]
        public double BodyWeight { get; set; }

        [JsonProperty("Height")]
        public double Height { get; set; }

        [JsonProperty("VMAX")]
        public double VMAX { get; set; }

        [JsonProperty("KM")]
        public double KM { get; set; }

        [JsonProperty("InfusionRate")]
        public int InfusionRate { get; set; }

        [JsonProperty("Washout")]
        public int Washout { get; set; }

        [JsonProperty("MIC")]
        public int MIC { get; set; }
        #endregion

        #region Non-Json properties
        [JsonIgnore]
        public double Bioavailability { get; set; }

        [JsonIgnore]
        public double Clearance { get; set; }

        [JsonIgnore]
        public double Ka { get; set; }

        [JsonIgnore]
        public double Ke { get; set; }

        [JsonIgnore]
        public double Dose { get; set; }

        [JsonIgnore]
        public double Tau { get; set; }

        [JsonIgnore]
        public double VolumeDistribution { get; set; }

        [JsonIgnore]
        public double ExtractionRate { get; set; }
        #endregion
    }
}