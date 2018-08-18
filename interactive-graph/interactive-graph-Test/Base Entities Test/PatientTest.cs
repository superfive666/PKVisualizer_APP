using System.IO;
using Xunit;
using interactivegraph.Base_Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace interactive_graph_Test.Base_Entities_Test
{
    public partial class PatientTest
    {
        Patient _patient;

        private void InitPatient ()
        {
            using (var fs = File.Open(TestConstants.PatientData, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    _patient = JsonConvert.DeserializeObject<Patient>(sr.ReadToEnd());
                }
            }
        }

        [Fact]
        public void Patient_Clone_Test()
        {
            InitPatient();
            var newPatient = new Patient();
            newPatient.Clone(_patient);
            Assert.True(newPatient.Equals(_patient));
        }

        [Fact]
        public void Patient_Serialization_Test()
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
        public void Patient_StaticCounter_Test()
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
        public void Patient_NotEqual_Test()
        {
            InitPatient();
            var newPatient = new Patient();
            newPatient.Clone(_patient);
            newPatient.Name = "New Name";
            Assert.False(newPatient.Equals(_patient));
        }

        [Fact]
        public void Patient_Attribute_Test ()
        {
            _patient = new Patient();
            _patient.Bioavailability = 0.1;
            _patient.Ka = 0.1;
            _patient.Ke = 0.1;
            _patient.Clearance = 0.1;
            _patient.ExtractionRate = 0.1;
            _patient.VolumeDistribution = 0.1;

            Assert.Equal(0.1, _patient.Bioavailability);
            Assert.Equal(0.1, _patient.Ka);
            Assert.Equal(0.1, _patient.Ke);
            Assert.Equal(0.1, _patient.Clearance);
            Assert.Equal(0.1, _patient.ExtractionRate);
            Assert.Equal(0.1, _patient.VolumeDistribution);
        }
    }
}
