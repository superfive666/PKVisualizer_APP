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

        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Gender")]
        public string Gender { get; set; }
        [JsonProperty("Race")]
        public string Race { get; set; }
        [JsonProperty("Age")]
        public int Age { get; set; }
        public double BodyWeight { get; set; }
        public double Height { get; set; }
        public MedicalCondition Condition { get; set; }
        public GraphType Type { get; set; }
    }
}