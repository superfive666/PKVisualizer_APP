using interactivegraph.Helpers;

namespace interactivegraph.Base_Entities
{
    public class MedicalCondition
    {
        #region Public constructor
        /// <summary>
        /// Public constructor takes in no parameters.
        /// Initialization of object during creation of the instance.
        /// </summary>
        public MedicalCondition() { }
        #endregion

        public double Dose { get; set; }
        public int Tau { get; set; }
        public int InfusionRate { get; set; }
        public int Washout { get; set; }
        public int MIC { get; set; }
        public double VMAX { get; set; }
        public double KM { get; set; }
        public DistributionVariable VolumeDistribution { get; set; }
        public DistributionVariable ExtractionRate { get; set; }
        public DistributionVariable Ka { get; set; }
        public DistributionVariable Clearance { get; set; }
        public DistributionVariable Bioavailability { get; set; }
    }
}