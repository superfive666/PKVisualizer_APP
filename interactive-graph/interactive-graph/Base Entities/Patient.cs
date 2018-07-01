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

        public string Name { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public double BodyWeight { get; set; }
        public double Height { get; set; }
        public MedicalCondition Condition { get; set; }
        public GraphType Type { get; set; }
    }
}