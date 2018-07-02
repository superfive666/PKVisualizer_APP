namespace interactivegraph.Base_Entities
{
    public static class PopulationProfile
    {
        public const string Graph1 = "1_Continuous_Intravenous_Analgesic.json";
        public const string Graph2 = "2_Multiple_Dose_IV_Infusion.json";
        public const string Graph3 = "3_Multiple_Oral_Dose_NSAID.json";
        public const string Graph4 = "4_Multiple_Oral_Dose_Antithrombotic.json";
        public const string Graph5 = "5_Multiple Oral_Dose_Anticoagulant.json";
        public const string Graph6 = "6_Multiple_Oral_Dose_Antibiotics.json";
        public const string Graph8 = "8_Phenytoin_Formulation.json";
    }

    public static class JsonPath
    {
        public const string Name = "GraphParameters.Name";
        public const string BodyWeight = "GraphParameters.BodyWeight";
        public const string Gender = "GraphParameters.Gender";
        public const string Race = "GraphParameters.Race";
        public const string Age = "GraphParameters.Age";
        public const string Height = "GraphParameters.Height";
        public const string Dose = "GraphParameters.Dose";
        public const string Tau = "GraphParameters.Tau";
        public const string VolumeDistribution = "GraphParameters.VolumeDistribution";
        public const string ExtractionRate = "GraphParameters.ExtractionRate";
        public const string Ka = "GraphParameters.Ka";
        public const string Clearance = "GraphParameters.Clearance";
        public const string VMAX = "GraphParameters.VMAX";
        public const string KM = "GraphParameters.KM";
        public const string TimeInterval = "GraphParameters.TimeInterval";
        public const string Bioavailability = "GraphParameters.Bioavailability";

        public const string Mean = "Mean";
        public const string StandardDeviation = "StandardDeviation";

        public const string HorizontalMax = "GraphParameters.HorizontalMax";
        public const string VerticalMax = "GraphParameters.VerticalMax";
    }
}