using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions;
using Xunit.Sdk;
using interactivegraph.Base_Entities;
using interactive_graph_Test;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace interactive_graph_Test.Base_Entities_Test
{
    public class PatientTest
    {
        Patient _patient;

        private void InitPatient ()
        {
            using (var fs = File.Open(TestConstants.PatientData, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    var data = JObject.Parse(sr.ReadToEnd());
                    _patient = JsonConvert.DeserializeObject<Patient>(JsonConvert.SerializeObject(data));
                }
            }
        }

        [Fact]
        public void ClonePatient_Test()
        {
            InitPatient();
            var newPatient = new Patient();
            newPatient.Clone(_patient);
            Assert.True(newPatient.Equals(_patient));
        }

        [Fact]
        public void PatientSerialization_Test()
        {
            InitPatient();
            JObject data;
            using (var fs = File.Open(TestConstants.PatientData, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    data = JObject.Parse(sr.ReadToEnd());
                }
            }
            Assert.NotNull(_patient);
            Assert.Equal(data.SelectToken("Name").ToString(), _patient.Name);
            Assert.Equal(data.SelectToken("Gender").ToString(), _patient.Gender);
            Assert.Equal(data.SelectToken("Race").ToString(), _patient.Race);
            Assert.Equal((int)data.SelectToken("Age"), _patient.Age);
            Assert.Equal((int)data.SelectToken("BodyWeight"), _patient.BodyWeight);
            Assert.Equal((double)data.SelectToken("Height"), _patient.Height);
            Assert.Equal((double)data.SelectToken("VMAX"), _patient.VMAX);
            Assert.Equal((double)data.SelectToken("KM"), _patient.KM);
            Assert.Equal((double)data.SelectToken("InfusionRate"), _patient.InfusionRate);
            Assert.Equal((int)data.SelectToken("Washout"), _patient.Washout);
            Assert.Equal((int)data.SelectToken("MIC"), _patient.MIC);
            Assert.Equal((double)data.SelectToken("Dose"), _patient.Dose);
            Assert.Equal((int)data.SelectToken("Tau"), _patient.Tau);
        }

        [Fact]
        public void PatientStaticCounter_Test()
        {
            var testValue = 1.5;
            Patient.PrevValue = testValue;
            Assert.Equal(testValue, Patient.PrevValue);
            Patient.T = testValue;
            Assert.Equal(testValue, Patient.T);
            Assert.Equal(0.1, Patient.TimeInterval);
            Assert.False(0.2 == Patient.TimeInterval);
        }

        [Fact]
        public void PatientNotEqual_Test()
        {
            InitPatient();
            var newPatient = new Patient();
            newPatient.Clone(_patient);
            newPatient.Name = "New Name";
            Assert.False(newPatient.Equals(_patient));
        }
    }
}
