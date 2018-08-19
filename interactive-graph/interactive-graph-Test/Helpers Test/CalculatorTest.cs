using System;
using Xunit;
using interactivegraph.Helpers;
using interactivegraph.Base_Entities;
using interactivegraph.Entities;

namespace interactive_graph_Test.Helpers_Test
{
    public partial class CalculatorTest
    {
        [Fact]
        public void AdjustedMean_Test()
        {
            var m = 2 * 2.0;
            var s = 2 / 10.0;
            var a1 = m * m;
            var a2 = Math.Sqrt(a1 + s * s);
            Assert.Equal(Math.Log(a1 / a2), Calculator.AdjustedMean(m, s));
            Assert.False(Calculator.AdjustedMean(m, s) == 0);
        }

        [Fact]
        public void AdjustedStd_Test()
        {
            var m = 2 * 2.0;
            var s = 2 / 10.0;
            var a1 = m * m;
            var a2 = a1 + s * s;
            Assert.Equal(Math.Sqrt(Math.Log(a2 / a1)), Calculator.AdjustedStandardDev(m, s));
            Assert.False(Calculator.AdjustedMean(m, s) == 0);
        }

        [Fact]
        public void Graph_1_Concentration_Test()
        {
            var population = new Population(GraphType.Continuous_Intravenous_Analgesic);
            var patient = population.Patients[0];
            var t = 100.25;
            var a1 = patient.Dose * patient.InfusionRate;
            var a2 = patient.Ke * patient.VolumeDistribution;
            var a3 = 1 - Math.Exp(-patient.Ke * t);
            var result = a1 * a3 / a2;
            Assert.Equal(result, Calculator.ConcentrationAtTime(t, patient, 
                                 GraphType.Continuous_Intravenous_Analgesic));
        }

        [Fact]
        public void Graph_2_Concentration_Test()
        {
            var population = new Population(GraphType.Multiple_Dose_IV_Infusion);
            var patient = population.Patients[0];

            double calc(double t)
            {
                var a1 = patient.Dose;
                var a2 = patient.Ke * patient.VolumeDistribution;
                var a3 = 1 - Math.Exp(-patient.Ke * patient.InfusionRate);
                var a4 = t > patient.InfusionRate ?
                         Math.Exp(-patient.Ke * (t - patient.InfusionRate)) :
                         1.0;

                return t < patient.Tau ?
                       a1 * a3 * a4 / a2 :
                       a1 * a3 * a4 / a2 + calc(t - patient.Tau);
            }

            var t1 = 7.5;
            var t2 = 25.5;
            Assert.Equal(calc(t1), Calculator.ConcentrationAtTime(t1, patient, GraphType.Multiple_Dose_IV_Infusion));
            Assert.Equal(calc(t2), Calculator.ConcentrationAtTime(t2, patient, GraphType.Multiple_Dose_IV_Infusion));
        }

        [Fact]
        public void Graph_3_Concentration_Test()
        {
            var population = new Population(GraphType.Multiple_Oral_Dose_NSAID);
            var patient = population.Patients[0];

            double calc(double t)
            {
                var a1 = (1 - patient.ExtractionRate) * patient.Dose * patient.Ka;
                var a2 = patient.VolumeDistribution * (patient.Ka - patient.Ke);
                var a3 = Math.Exp(-patient.Ke * t) - Math.Exp(-patient.Ka * t);
                return t < patient.Tau ?
                       a1 * a3 / a2 :
                       a1 * a3 / a2 + calc(t - patient.Tau);
            }

            var t1 = 7.5;
            var t2 = 25.5;
            Assert.Equal(calc(t1), Calculator.ConcentrationAtTime(t1, patient, GraphType.Multiple_Oral_Dose_NSAID));
            Assert.Equal(calc(t2), Calculator.ConcentrationAtTime(t2, patient, GraphType.Multiple_Oral_Dose_NSAID));
        }

        [Fact]
        public void Graph_4_Concentration_Test()
        {
            var population = new Population(GraphType.Multiple_Oral_Dose_Antithrombotic);
            var patient = population.Patients[0];

            double calc(double t)
            {
                var a1 = (1 - patient.ExtractionRate) * patient.Dose * patient.Ka;
                var a2 = patient.VolumeDistribution * (patient.Ka - patient.Ke);
                var a3 = Math.Exp(-patient.Ke * t) - Math.Exp(-patient.Ka * t);
                return t < patient.Tau ?
                       a1 * a3 / a2 :
                       a1 * a3 / a2 + calc(t - patient.Tau);
            }

            var t1 = 7.5;
            var t2 = 25.5;
            Assert.Equal(calc(t1), Calculator.ConcentrationAtTime(t1, patient, GraphType.Multiple_Oral_Dose_Antithrombotic));
            Assert.Equal(calc(t2), Calculator.ConcentrationAtTime(t2, patient, GraphType.Multiple_Oral_Dose_Antithrombotic));
        }

        [Fact]
        public void Graph_5_Concentration_Test()
        {
            var population = new Population(GraphType.Multiple_Oral_Dose_Anticoagulant);
            var patient = population.Patients[0];

            double calc(double t)
            {
                var a1 = (1 - patient.ExtractionRate) * patient.Dose * patient.Ka;
                var a2 = patient.VolumeDistribution * (patient.Ka - patient.Ke);
                var a3 = Math.Exp(-patient.Ke * t) - Math.Exp(-patient.Ka * t);
                return t < patient.Tau ?
                       a1 * a3 / a2 :
                       a1 * a3 / a2 + calc(t - patient.Tau);
            }

            var t1 = 7.5;
            var t2 = 25.5;
            Assert.Equal(calc(t1), Calculator.ConcentrationAtTime(t1, patient, GraphType.Multiple_Oral_Dose_Anticoagulant));
            Assert.Equal(calc(t2), Calculator.ConcentrationAtTime(t2, patient, GraphType.Multiple_Oral_Dose_Anticoagulant));
        }

        [Fact]
        public void Graph_6_Concentration_Test()
        {
            var population = new Population(GraphType.Multiple_Oral_dose_Antibiotics);
            var patient = population.Patients[0];

            double calc(double t)
            {
                var a1 = (1 - patient.ExtractionRate) * patient.Dose * patient.Ka;
                var a2 = patient.VolumeDistribution * (patient.Ka - patient.Ke);
                var a3 = Math.Exp(-patient.Ke * t) - Math.Exp(-patient.Ka * t);
                return t < patient.Tau ?
                       a1 * a3 / a2 :
                       a1 * a3 / a2 + calc(t - patient.Tau);
            }

            var t1 = 7.5;
            var t2 = 25.5;
            Assert.Equal(calc(t1), Calculator.ConcentrationAtTime(t1, patient, GraphType.Multiple_Oral_dose_Antibiotics));
            Assert.Equal(calc(t2), Calculator.ConcentrationAtTime(t2, patient, GraphType.Multiple_Oral_dose_Antibiotics));
        }

        [Fact]
        public void Graph_8_Concentration_Test()
        {
            var population = new Population(GraphType.Multiple_Oral_dose_Antibiotics);
            var patient = population.Patients[0];
            var T = 0.0;
            double CalculateABS(double ti)
            {
                var a1 = patient.Bioavailability * patient.Dose;
                var a2 = 1 - Math.Exp(-patient.Ka * ti);
                var a3 = a1 * a2 / patient.VolumeDistribution;
                return ti < patient.Tau ?
                       a3 : a3 + CalculateABS(ti - patient.Tau);
            }

            double CalculateELI(double p)
            {
                var a1 = patient.VMAX * p * 1000;
                var a2 = (patient.KM + p) * patient.VolumeDistribution;
                return Patient.TimeInterval * a1 / a2;
            }

            double calc(double t)
            {
                var abs = CalculateABS(t);
                T += t % patient.Tau == 0 ?
                             CalculateELI(abs) :
                             CalculateELI(Patient.PrevValue);
                return abs - T;
            }

            double time = 0;
            Patient.T = 0;
            Patient.PrevValue = 0;

            while (time < 24)
            {
                var cur = calc(time);
                Assert.Equal(cur, Calculator.ConcentrationAtTime(time, patient, GraphType.Phenytoin_Formulation));
                time += Patient.TimeInterval;
                Patient.PrevValue = cur;
            }

        }
    }
}
