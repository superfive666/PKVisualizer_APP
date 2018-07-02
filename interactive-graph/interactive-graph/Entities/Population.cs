using interactivegraph.Base_Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace interactivegraph.Entities
{
    public class Population
    {
        #region Public constructor
        public Population(GraphType type)
        {
            SetupPopulation(type);
        }
        #endregion
        
        public List<Patient> Patients { get; private set; }
        
        public List<List<double>> SinglePatientGraph { get; set; }

        public List<List<double>> PopulationGraph { get; set; }

        public GraphSettings Setting { get; set; }

        public int ActivePatient { get;set; }

        #region Initialization methods for population
        public static Random rand = new Random();

        private string Mapper(GraphType type)
        {
            switch (type)
            {
                case GraphType.Continuous_Intravenous_Analgesic: return PopulationProfile.Graph1;
                case GraphType.Multiple_Dose_IV_Infusion: return PopulationProfile.Graph2;
                case GraphType.Multiple_Oral_Dose_NSAID: return PopulationProfile.Graph3;
                case GraphType.Multiple_Oral_Dose_Antithrombotic: return PopulationProfile.Graph4;
                case GraphType.Multiple_Oral_Dose_Anticoagulant: return PopulationProfile.Graph5;
                case GraphType.Multiple_Oral_dose_Antibiotics: return PopulationProfile.Graph6;
                case GraphType.Phenytoin_Formulation: return PopulationProfile.Graph8;
            }
            return string.Empty;
        }

        private void SetupPopulation(GraphType type)
        {

            //To-do: change the backend architecture
            try
            {
                ActivePatient = rand.Next(20);
                using (FileStream fs = File.Open(Mapper(type), FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string readResult = sr.ReadToEnd();
                        JObject profile = JObject.Parse(readResult);
                        for (var i = 0; i < 20; i++)
                        {
                            var patient = new Patient();
                            patient.Type = type;
                            foreach (var prop in patient.GetType().GetProperties())
                            {
                                var path = (string) Type.GetType("JsonPath")
                                                        .GetProperty(prop.Name)
                                                        .GetValue(null);
                                if (prop.GetType() == typeof(int))
                                {
                                    patient.GetType()
                                           .GetProperty(prop.Name)
                                           .SetValue(patient, (int?)profile.SelectToken(path) ?? 0);
                                }
                                else if (prop.GetType() == typeof(double))
                                {
                                    patient.GetType()
                                           .GetProperty(prop.Name)
                                           .SetValue(patient, (double?)profile.SelectToken(path) ?? 0);
                                }
                                else if (prop.GetType() == typeof(string))
                                {
                                    var value = profile.SelectToken(path);
                                    if (value != null)
                                    {
                                        patient.GetType()
                                               .GetProperty(prop.Name)
                                               .SetValue(patient, value.ToString());
                                    }
                                }
                            }

                            //Medical Condition
                            var condition = new MedicalCondition();
                            foreach (var prop in condition.GetType().GetProperties())
                            {
                                var root = (string)Type.GetType("JsonPath").GetProperty(prop.Name).GetValue(null);
                                if (prop.GetType() == typeof(DistributionVariable))
                                {
                                    var mean = (double) profile.SelectToken(string.Format("{0}.{1}", root, JsonPath.Mean));
                                    var std = (double) profile.SelectToken(string.Format("{0}.{1}", root, JsonPath.StandardDeviation));
                                    prop.SetValue(condition, new DistributionVariable(mean, std));
                                }
                                else
                                {

                                }
                            }
                        }

                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void GenerateGraphData()
        {
            //To-do: generate one population data


            //To-do: generate single patient data (might be redundant)


            throw new NotImplementedException();
        }
        #endregion

        #region Public methods
        public void SwitchPatient()
        {
            throw new NotImplementedException();
        }

        public void ChangePopulation()
        {
            throw new NotImplementedException();
        }

        public void OptimizeCondition(MedicalCondition condition)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}