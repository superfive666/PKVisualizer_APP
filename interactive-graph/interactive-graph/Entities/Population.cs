﻿using interactivegraph.Base_Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using MathNet.Numerics.Distributions;

namespace interactivegraph.Entities
{
    public class Population
    {
        #region Public constructor
        public Population(GraphType type)
        {
            Graph_Type = type;
            Patients = new List<Patient>();
            DefaultPopulation = new List<Patient>(20);
            SetupPopulation(type);
            SaveDefault();
        }
        #endregion
        
        public List<Patient> Patients { get; private set; }

        public List<Patient> DefaultPopulation { get; set; }

        public MedicalCondition Condition { get; private set; }
        
        public List<List<double>> SinglePatientGraph { get; set; }

        public List<List<double>> PopulationGraph { get; set; }

        public GraphSettings Setting { get; set; }

        public GraphType Graph_Type { get; private set; }

        public int ActivePatient { get; set; }

        public int DefaultPatient { get; set; }

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
            try
            {
                ActivePatient = rand.Next(20);
                using (FileStream fs = File.Open(Mapper(type), FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string readResult = sr.ReadToEnd();
                        JObject profile = JObject.Parse(readResult);

                        Condition = new MedicalCondition();
                        foreach (var prop in Condition.GetType().GetProperties())
                        {
                            var conditionProfile = profile.SelectToken(JsonPath.MedicalCondition);
                            var item = conditionProfile.SelectToken(prop.Name);
                            var variable = new DistributionVariable((double?)item.SelectToken(JsonPath.Mean) ?? 0,
                                                                    (double?)item.SelectToken(JsonPath.StandardDeviation) ?? 0);
                            Condition.GetType().GetProperty(prop.Name).SetValue(Condition, variable);
                        }

                        for (var i = 0; i < 20; i++)
                        {
                            var patientProfile = JsonConvert.SerializeObject(profile.SelectToken(JsonPath.Patient));
                            var patient = JsonConvert.DeserializeObject<Patient>(patientProfile);
                            Patients.Add(patient);
                        }
                        GeneratePatients();

                        var graphProfile = JsonConvert.SerializeObject(profile.SelectToken(JsonPath.Graph));
                        Setting = JsonConvert.DeserializeObject<GraphSettings>(graphProfile);
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void GeneratePatients()
        {
            foreach(var patient in Patients)
            {
                patient.Bioavailability = LogNormal.InvCDF(Condition.Bioavailability.AdjustedMean,
                                                                       Condition.Bioavailability.AdjustedStdDev,
                                                                       rand.NextDouble());
                patient.ExtractionRate = LogNormal.InvCDF(Condition.Clearance.AdjustedMean,
                                                          Condition.Clearance.AdjustedStdDev,
                                                          rand.NextDouble());
                patient.Ka = LogNormal.InvCDF(Condition.Ka.AdjustedMean,
                                              Condition.Ka.AdjustedStdDev,
                                              rand.NextDouble());
                patient.VolumeDistribution = LogNormal.InvCDF(Condition.VolumeDistribution.AdjustedMean,
                                                              Condition.VolumeDistribution.AdjustedStdDev,
                                                              rand.NextDouble());
                patient.Clearance = LogNormal.InvCDF(Condition.Clearance.AdjustedMean,
                                                     Condition.Clearance.AdjustedStdDev,
                                                     rand.NextDouble());
                var actualKe = Math.Min(0.9999,
                               patient.Clearance * 60 / patient.VolumeDistribution / 1000);
                actualKe = Graph_Type == GraphType.Continuous_Intravenous_Analgesic ?
                           actualKe * patient.BodyWeight : actualKe;
                patient.Ke = Math.Log(1) - Math.Log(1 - actualKe);
            }
        }

        private void GenerateGraphData()
        {
            Patient.T = 0; Patient.PrevValue = 0;

            //To-do: generate one population data
            //To-do: update prev value every time generate the patient.


            throw new NotImplementedException();
        }

        private void SaveDefault()
        {
            DefaultPatient = ActivePatient;
            foreach(var patient in Patients)
            {
                var newPatient = new Patient();
                newPatient.Clone(patient);
                DefaultPopulation.Add(newPatient);
            }
        }

        private void RetrieveDefault()
        {
            ActivePatient = DefaultPatient;
            for (var i = 0; i < 20; i++)
            {
                Patients[i].Clone(DefaultPopulation[i]);
            }
        }
        #endregion

        #region Public methods
        public void SwitchPatient(int i)
        {
            ActivePatient = (ActivePatient + 20 + i) % 20;
        }

        public void ChangePopulation()
        {
            GeneratePatients();
        }

        public void OptimizeCondition(Patient p)
        {
            foreach(var patient in Patients)
            {
                patient.Dose = p.Dose;
                patient.Tau = p.Tau;
                patient.InfusionRate = p.InfusionRate;
            }
        }

        public void BackToDefault()
        {
            RetrieveDefault();
        }
        #endregion

    }
}