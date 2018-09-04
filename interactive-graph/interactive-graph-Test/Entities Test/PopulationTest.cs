using Xunit;
using interactivegraph.Entities;
using interactivegraph.Base_Entities;

namespace interactive_graph_Test.Entities_Test
{
    public partial class PopulationTest
    {
        Population _population;

        [Fact]
        public void Population_Attributes_Test ()
        {
            _population = new Population(GraphType.Continuous_Intravenous_Analgesic);
            Assert.NotNull(_population.Patients);
            Assert.NotNull(_population.DefaultPopulation);
            Assert.NotNull(_population.Condition);
            Assert.NotNull(_population.Setting);

            Assert.Equal(20, _population.Patients.Count);
            Assert.Equal(20, _population.DefaultPopulation.Count);
            Assert.True(_population.ActivePatient < 20);
            Assert.True(_population.ActivePatient >= 0);
            Assert.Equal(_population.Patients, _population.DefaultPopulation);
            Assert.Equal(_population.ActivePatient, _population.DefaultPatient);

            foreach(var patient in _population.Patients)
            {
                Assert.Equal("String", patient.Name);
                Assert.Equal("Male", patient.Gender);
                Assert.Equal("Chinese", patient.Race);
                Assert.Equal(27, patient.Age);
                Assert.Equal(47, patient.BodyWeight);
                Assert.Equal(1.80, patient.Height);
                Assert.Equal(0, patient.VMAX);
                Assert.Equal(0, patient.KM);
                Assert.Equal(1.0, patient.InfusionRate);
                Assert.Equal(0, patient.Washout);
                Assert.Equal(0, patient.MIC);
                Assert.Equal(1.5, patient.Dose);
                Assert.Equal(12, patient.Tau);
            }

            Assert.Equal(4, _population.Condition.VolumeDistribution.Mean);
            Assert.Equal(1, _population.Condition.VolumeDistribution.StandardDeviation);
            Assert.Equal(0, _population.Condition.ExtractionRate.Mean);
            Assert.Equal(0, _population.Condition.ExtractionRate.StandardDeviation);
            Assert.Equal(0, _population.Condition.Ka.Mean);
            Assert.Equal(0, _population.Condition.Ka.StandardDeviation);
            Assert.Equal(40, _population.Condition.Clearance.Mean);
            Assert.Equal(6, _population.Condition.Clearance.StandardDeviation);
            Assert.Equal(0, _population.Condition.Bioavailability.Mean);
            Assert.Equal(0, _population.Condition.Bioavailability.StandardDeviation);

            Assert.Equal(0, _population.Setting.HorizontalMax);
            Assert.Equal(0, _population.Setting.VerticalMax);
        }

        [Fact]
        public void Poulation_Graph2Init_Test ()
        {
            _population = new Population(GraphType.Multiple_Dose_IV_Infusion);

            foreach (var patient in _population.Patients)
            {
                Assert.Equal("String", patient.Name);
                Assert.Equal("Male", patient.Gender);
                Assert.Equal("Chinese", patient.Race);
                Assert.Equal(27, patient.Age);
                Assert.Equal(65, patient.BodyWeight);
                Assert.Equal(1.7, patient.Height);
                Assert.Equal(0, patient.VMAX);
                Assert.Equal(0, patient.KM);
                Assert.Equal(2, patient.InfusionRate);
                Assert.Equal(6, patient.Washout);
                Assert.Equal(1, patient.MIC);
                Assert.Equal(500, patient.Dose);
                Assert.Equal(8, patient.Tau);
            }

            Assert.Equal(1.1, _population.Condition.VolumeDistribution.Mean);
            Assert.Equal(0.4, _population.Condition.VolumeDistribution.StandardDeviation);
            Assert.Equal(0, _population.Condition.ExtractionRate.Mean);
            Assert.Equal(0, _population.Condition.ExtractionRate.StandardDeviation);
            Assert.Equal(0, _population.Condition.Ka.Mean);
            Assert.Equal(0, _population.Condition.Ka.StandardDeviation);
            Assert.Equal(100, _population.Condition.Clearance.Mean);
            Assert.Equal(16, _population.Condition.Clearance.StandardDeviation);
            Assert.Equal(0, _population.Condition.Bioavailability.Mean);
            Assert.Equal(0, _population.Condition.Bioavailability.StandardDeviation);

            Assert.Equal(0, _population.Setting.HorizontalMax);
            Assert.Equal(0, _population.Setting.VerticalMax);
        }

        [Fact]
        public void Population_Graph3Init_Test ()
        {
            _population = new Population(GraphType.Multiple_Oral_Dose_NSAID);

            foreach (var patient in _population.Patients)
            {
                Assert.Equal("String", patient.Name);
                Assert.Equal("Male", patient.Gender);
                Assert.Equal("Chinese", patient.Race);
                Assert.Equal(30, patient.Age);
                Assert.Equal(65, patient.BodyWeight);
                Assert.Equal(1.80, patient.Height);
                Assert.Equal(0, patient.VMAX);
                Assert.Equal(0, patient.KM);
                Assert.Equal(0, patient.InfusionRate);
                Assert.Equal(0, patient.Washout);
                Assert.Equal(0, patient.MIC);
                Assert.Equal(75, patient.Dose);
                Assert.Equal(12, patient.Tau);
            }

            Assert.Equal(8, _population.Condition.VolumeDistribution.Mean);
            Assert.Equal(1.6, _population.Condition.VolumeDistribution.StandardDeviation);
            Assert.Equal(0.1, _population.Condition.ExtractionRate.Mean);
            Assert.Equal(0.02, _population.Condition.ExtractionRate.StandardDeviation);
            Assert.Equal(2, _population.Condition.Ka.Mean);
            Assert.Equal(0.4, _population.Condition.Ka.StandardDeviation);
            Assert.Equal(15, _population.Condition.Clearance.Mean);
            Assert.Equal(3, _population.Condition.Clearance.StandardDeviation);
            Assert.Equal(0, _population.Condition.Bioavailability.Mean);
            Assert.Equal(0, _population.Condition.Bioavailability.StandardDeviation);

            Assert.Equal(0, _population.Setting.HorizontalMax);
            Assert.Equal(0, _population.Setting.VerticalMax);
        }

        [Fact]
        public void Population_Graph4Init_Test ()
        {
            _population = new Population(GraphType.Multiple_Oral_Dose_Antithrombotic);

            foreach (var patient in _population.Patients)
            {
                Assert.Equal("String", patient.Name);
                Assert.Equal("Male", patient.Gender);
                Assert.Equal("Chinese", patient.Race);
                Assert.Equal(30, patient.Age);
                Assert.Equal(65, patient.BodyWeight);
                Assert.Equal(1.8, patient.Height);
                Assert.Equal(0, patient.VMAX);
                Assert.Equal(0, patient.KM);
                Assert.Equal(0, patient.InfusionRate);
                Assert.Equal(0, patient.Washout);
                Assert.Equal(0, patient.MIC);
                Assert.Equal(75, patient.Dose);
                Assert.Equal(24, patient.Tau);
            }

            Assert.Equal(12.6, _population.Condition.VolumeDistribution.Mean);
            Assert.Equal(2.52, _population.Condition.VolumeDistribution.StandardDeviation);
            Assert.Equal(0.3, _population.Condition.ExtractionRate.Mean);
            Assert.Equal(0.06, _population.Condition.ExtractionRate.StandardDeviation);
            Assert.Equal(1.38, _population.Condition.Ka.Mean);
            Assert.Equal(0.276, _population.Condition.Ka.StandardDeviation);
            Assert.Equal(130, _population.Condition.Clearance.Mean);
            Assert.Equal(26, _population.Condition.Clearance.StandardDeviation);
            Assert.Equal(0, _population.Condition.Bioavailability.Mean);
            Assert.Equal(0, _population.Condition.Bioavailability.StandardDeviation);

            Assert.Equal(0, _population.Setting.HorizontalMax);
            Assert.Equal(0, _population.Setting.VerticalMax);
        }

        [Fact]
        public void Population_Graph5Init_Test ()
        {
            _population = new Population(GraphType.Multiple_Oral_Dose_Anticoagulant);

            foreach (var patient in _population.Patients)
            {
                Assert.Equal("String", patient.Name);
                Assert.Equal("Male", patient.Gender);
                Assert.Equal("Chinese", patient.Race);
                Assert.Equal(30, patient.Age);
                Assert.Equal(65, patient.BodyWeight);
                Assert.Equal(1.8, patient.Height);
                Assert.Equal(0, patient.VMAX);
                Assert.Equal(0, patient.KM);
                Assert.Equal(0, patient.InfusionRate);
                Assert.Equal(0, patient.Washout);
                Assert.Equal(0, patient.MIC);
                Assert.Equal(400, patient.Dose);
                Assert.Equal(12, patient.Tau);
            }

            Assert.Equal(3120, _population.Condition.VolumeDistribution.Mean);
            Assert.Equal(624, _population.Condition.VolumeDistribution.StandardDeviation);
            Assert.Equal(0.9, _population.Condition.ExtractionRate.Mean);
            Assert.Equal(0.18, _population.Condition.ExtractionRate.StandardDeviation);
            Assert.Equal(0.8, _population.Condition.Ka.Mean);
            Assert.Equal(0.16, _population.Condition.Ka.StandardDeviation);
            Assert.Equal(2740, _population.Condition.Clearance.Mean);
            Assert.Equal(548, _population.Condition.Clearance.StandardDeviation);
            Assert.Equal(0, _population.Condition.Bioavailability.Mean);
            Assert.Equal(0, _population.Condition.Bioavailability.StandardDeviation);

            Assert.Equal(0, _population.Setting.HorizontalMax);
            Assert.Equal(0, _population.Setting.VerticalMax);
        }

        [Fact]
        public void Population_Graph6Init_Test ()
        {
            _population = new Population(GraphType.Multiple_Oral_dose_Antibiotics);

            foreach (var patient in _population.Patients)
            {
                Assert.Equal("String", patient.Name);
                Assert.Equal("Male", patient.Gender);
                Assert.Equal("Chinese", patient.Race);
                Assert.Equal(30, patient.Age);
                Assert.Equal(65, patient.BodyWeight);
                Assert.Equal(1.8, patient.Height);
                Assert.Equal(0, patient.VMAX);
                Assert.Equal(0, patient.KM);
                Assert.Equal(0, patient.InfusionRate);
                Assert.Equal(0, patient.Washout);
                Assert.Equal(0, patient.MIC);
                Assert.Equal(250, patient.Dose);
                Assert.Equal(12, patient.Tau);
            }

            Assert.Equal(250, _population.Condition.VolumeDistribution.Mean);
            Assert.Equal(50, _population.Condition.VolumeDistribution.StandardDeviation);
            Assert.Equal(0.3, _population.Condition.ExtractionRate.Mean);
            Assert.Equal(0.06, _population.Condition.ExtractionRate.StandardDeviation);
            Assert.Equal(0.8, _population.Condition.Ka.Mean);
            Assert.Equal(0.16, _population.Condition.Ka.StandardDeviation);
            Assert.Equal(550, _population.Condition.Clearance.Mean);
            Assert.Equal(110, _population.Condition.Clearance.StandardDeviation);
            Assert.Equal(0, _population.Condition.Bioavailability.Mean);
            Assert.Equal(0, _population.Condition.Bioavailability.StandardDeviation);

            Assert.Equal(0, _population.Setting.HorizontalMax);
            Assert.Equal(0, _population.Setting.VerticalMax);
        }

        [Fact]
        public void Population_Graph8Init_Test ()
        {
            _population = new Population(GraphType.Phenytoin_Formulation);

            foreach (var patient in _population.Patients)
            {
                Assert.Equal("String", patient.Name);
                Assert.Equal("Male", patient.Gender);
                Assert.Equal("Chinese", patient.Race);
                Assert.Equal(26, patient.Age);
                Assert.Equal(65, patient.BodyWeight);
                Assert.Equal(1.80, patient.Height);
                Assert.Equal(0.03, patient.VMAX);
                Assert.Equal(0.009, patient.KM);
                Assert.Equal(0, patient.InfusionRate);
                Assert.Equal(0, patient.Washout);
                Assert.Equal(0, patient.MIC);
                Assert.Equal(250, patient.Dose);
                Assert.Equal(12, patient.Tau);
            }

            Assert.Equal(50000, _population.Condition.VolumeDistribution.Mean);
            Assert.Equal(8333.333333, _population.Condition.VolumeDistribution.StandardDeviation);
            Assert.Equal(0, _population.Condition.ExtractionRate.Mean);
            Assert.Equal(0, _population.Condition.ExtractionRate.StandardDeviation);
            Assert.Equal(1, _population.Condition.Ka.Mean);
            Assert.Equal(0.16666667, _population.Condition.Ka.StandardDeviation);
            Assert.Equal(0, _population.Condition.Clearance.Mean);
            Assert.Equal(0, _population.Condition.Clearance.StandardDeviation);
            Assert.Equal(0.9, _population.Condition.Bioavailability.Mean);
            Assert.Equal(0.15, _population.Condition.Bioavailability.StandardDeviation);

            Assert.Equal(300, _population.Setting.HorizontalMax);
            Assert.Equal(0, _population.Setting.VerticalMax);
        }

        [Fact]
        public void Population_RetrieveDefault_Test ()
        {
            _population = new Population(GraphType.Continuous_Intravenous_Analgesic);
            _population.SwitchPatient(8);
            _population.ChangePopulation();

            Assert.NotEqual(_population.ActivePatient, _population.DefaultPatient);
            Assert.NotEqual(_population.Patients, _population.DefaultPopulation);

            _population.BackToDefault();

            Assert.Equal(_population.ActivePatient, _population.DefaultPatient);
            Assert.Equal(_population.Patients, _population.DefaultPopulation);
        }

        [Fact]
        public void Population_ChangePopulation_Test ()
        {
            _population = new Population(GraphType.Continuous_Intravenous_Analgesic);
            _population.ChangePopulation();
            Assert.NotEqual(_population.Patients, _population.DefaultPopulation);
        }

        [Fact]
        public void Population_SwitchPatient_Test ()
        {
            _population = new Population(GraphType.Continuous_Intravenous_Analgesic);
            var change = 18;
            var expected = (_population.ActivePatient + change) % 20;
            _population.SwitchPatient(change);

            Assert.Equal(expected, _population.ActivePatient);
        }

        [Fact]
        public void Population_OptimizingCondition_Test ()
        {
            _population = new Population(GraphType.Continuous_Intravenous_Analgesic);
            var newCondition = new Patient()
            {
                Tau = 0,
                InfusionRate = 0,
                Dose = 0
            };

            _population.OptimizeCondition(newCondition);

            foreach(var patient in _population.Patients)
            {
                Assert.Equal(0, patient.Tau);
                Assert.Equal(0, patient.InfusionRate);
                Assert.Equal(0, patient.Dose);
            }
        }

        [Fact]
        public void Population_TrueFalse_Test()
        {
            _population = new Population(GraphType.Continuous_Intravenous_Analgesic);
            _population.ChangePopulation();
            _population.BackToDefault();
            _population.BackToDefault();

            Assert.True(true);
        }

        [Fact]
        public void Population_GenerateGraphData_Test ()
        {
            _population = new Population(GraphType.Continuous_Intravenous_Analgesic);
            Assert.NotEmpty(_population.PopulationGraph);
            foreach(var data in _population.PopulationGraph)
            {
                Assert.NotEmpty(data);
                var average = 0.0;
                for (int i = 1; i < 21; i++) average += data[i];
                Assert.Equal(average / 20.0, data[21]);
            }
        }
    }
}
