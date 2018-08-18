namespace interactivegraph.Base_Entities
{
    public static class PopulationProfile
    {
        public const string Graph1 = "../APP_Data/1_Continuous_Intravenous_Analgesic.json";
        public const string Graph2 = "../APP_Data/2_Multiple_Dose_IV_Infusion.json";
        public const string Graph3 = "../APP_Data/3_Multiple_Oral_Dose_NSAID.json";
        public const string Graph4 = "../APP_Data/4_Multiple_Oral_Dose_Antithrombotic.json";
        public const string Graph5 = "../APP_Data/5_Multiple_Oral_Dose_Anticoagulant.json";
        public const string Graph6 = "../APP_Data/6_Multiple_Oral_Dose_Antibiotics.json";
        public const string Graph8 = "../APP_Data/8_Phenytoin_Formulation.json";
    }

    public static class FileFormat
    {
        public const string JSON = ".json";
        public const string CSHARP = ".cs";
        public const string IMAGE = ".jpg";
        public const string ICON = ".png";
    }

    public static class JsonPath
    {
        public const string Mean = "Mean";
        public const string StandardDeviation = "StandardDeviation";

        public const string Patient = "Patient";
        public const string MedicalCondition = "MedicalCondition";
        public const string Graph = "Graph";
    }

    public static class ContentTypes
    {
        public const string Json = "applicataion/json";
    }
}