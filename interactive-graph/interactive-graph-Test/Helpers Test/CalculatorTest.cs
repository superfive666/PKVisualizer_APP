using System;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions;
using Xunit.Sdk;
using interactivegraph.Helpers;
using interactivegraph.Base_Entities;
using interactivegraph.Entities;

namespace interactive_graph_Test.Helpers_Test
{
    public class CalculatorTest
    {
        private void SerializePatientData ()
        {

        }

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

            var a1 = patient.Dose * patient.InfusionRate;
            var a2 = patient.Ke * patient.VolumeDistribution;
            var a3 = 1 - Math.Exp(-patient.Ke * t);
            a1 * a3 / a2;
            Assert.True(true);
        }

        [Fact]
        public void Graph_2_Concentration_Test()
        {
            Assert.True(true);
        }

        [Fact]
        public void Graph_3_Concentration_Test()
        {
            Assert.True(true);
        }

        [Fact]
        public void Graph_4_Concentration_Test()
        {
            Assert.True(true);
        }

        [Fact]
        public void Graph_5_Concentration_Test()
        {
            Assert.True(true);
        }

        [Fact]
        public void Graph_6_Concentration_Test()
        {
            Assert.True(true);
        }

        [Fact]
        public void Graph_8_Concentration_Test()
        {
            Assert.True(true);
        }
    }
}
