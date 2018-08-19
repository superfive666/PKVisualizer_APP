using Newtonsoft.Json;
using System.Reflection;

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
        public double InfusionRate { get; set; }

        [JsonProperty("Washout")]
        public int Washout { get; set; }

        [JsonProperty("MIC")]
        public int MIC { get; set; }

        [JsonProperty("Dose")]
        public double Dose { get; set; }

        [JsonProperty("Tau")]
        public double Tau { get; set; }

        [JsonProperty("BioAvailability")]
        public double Bioavailability { get; set; }

        [JsonProperty("Clearance")]
        public double Clearance { get; set; }

        [JsonProperty("Ka")]
        public double Ka { get; set; }

        [JsonProperty("Ke")]
        public double Ke { get; set; }

        [JsonProperty("VolumeDistribution")]
        public double VolumeDistribution { get; set; }

        [JsonProperty("ExtractionRate")]
        public double ExtractionRate { get; set; }
        #endregion

        #region Static counters
        public static double T = 0;

        public static double PrevValue = 0;

        public static readonly double TimeInterval = 0.1;
        #endregion

        public void Clone(Patient patient)
        {
            var type = patient.GetType();
            var properties = type.GetProperties();
            foreach (var prop in properties)
            {
                type.GetProperty(prop.Name)
                    .SetValue(this, type.GetProperty(prop.Name)
                    .GetValue(patient));
            }
        }

        #region Override object equal method
        public override bool Equals(object obj)
        {
            var _patient = obj as Patient;
            var type = _patient.GetType();
            var properties = type.GetProperties();
            foreach (var prop in properties)
            {
                var value = type.GetProperty(prop.Name)
                                .GetValue(_patient);
                if (type.GetProperty(prop.Name).GetValue(this).ToString() != value.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 13;

            hash = (hash * 7) + Dose.GetHashCode();
            hash = (hash * 7) + Tau.GetHashCode();
            hash = (hash * 7) + Bioavailability.GetHashCode();
            hash = (hash * 7) + Ka.GetHashCode();
            hash = (hash * 7) + Clearance.GetHashCode();
            hash = (hash * 7) + ExtractionRate.GetHashCode();
            hash = (hash * 7) + VolumeDistribution.GetHashCode();

            return base.GetHashCode();
        }
        #endregion
    }
}