using System;
using interactivegraph.Base_Entities;

namespace interactivegraph.Helpers
{
    public static class Calculator
    {
        #region Public calculator functions
        public static double AdjustedMean(double m, double s)
        {
            var a1 = m * m;
            var a2 = Math.Sqrt(a1 + s * s);
            return Math.Log(a1 / a2);
        }

        public static double AdjustedStandardDev(double m, double s)
        {
            var a1 = m * m;
            var a2 = a1 + s * s;
            return Math.Sqrt(Math.Log(a2 / a1));
        }

        public static double ConcentrationAtTime(double t, Patient patient, GraphType type)
        {
            switch(type)
            {
                case GraphType.Continuous_Intravenous_Analgesic: return Graph1(t, patient);
                case GraphType.Multiple_Dose_IV_Infusion:
                    return t < patient.Tau? 
                           Graph2(t, patient) : 
                           Graph2(t, patient) + ConcentrationAtTime(t - patient.Tau, patient, type);
                case GraphType.Multiple_Oral_Dose_NSAID: 
                case GraphType.Multiple_Oral_Dose_Antithrombotic: 
                case GraphType.Multiple_Oral_Dose_Anticoagulant: 
                case GraphType.Multiple_Oral_dose_Antibiotics:
                    return t < patient.Tau? 
                           Graph3(t, patient) : 
                           Graph3(t, patient) + ConcentrationAtTime(t - patient.Tau, patient, type);
                case GraphType.Phenytoin_Formulation: return Graph8(t, patient);
            }

            throw new NotImplementedException();
        }
        #endregion

        #region Private calculation functions
        private static double Graph1(double t, Patient patient)
        {
            var a1 = patient.Dose * patient.InfusionRate;
            var a2 = patient.Ke * patient.VolumeDistribution;
            var a3 = 1 - Math.Exp(-patient.Ke * t);
            return a1 * a3 / a2;
        }

        private static double Graph2(double t, Patient patient)
        {
            var a1 = patient.Dose;
            var a2 = patient.Ke * patient.VolumeDistribution;
            var a3 = 1 - Math.Exp(-patient.Ke * patient.InfusionRate);
            var a4 = t > patient.InfusionRate ?
                     Math.Exp(-patient.Ke * (t - patient.InfusionRate)) :
                     1.0;

            return a1 * a3 * a4 / a2;
        }

        private static double Graph3(double t, Patient patient)
        {
            var a1 = (1 - patient.ExtractionRate) * patient.Dose * patient.Ka;
            var a2 = patient.VolumeDistribution * (patient.Ka - patient.Ke);
            var a3 = Math.Exp(-patient.Ke * t) - Math.Exp(-patient.Ka * t);
            return a1 * a3 / a2;
        }

        private static double Graph8(double t, Patient patient)
        {
            Func<double> CalculateABS = () =>
            {


                return 1.0;
            };

            Func<double> CalculateELI = () =>
            {

                return 1.0;
            };

            var abs = CalculateABS.Invoke();

            return 0;
        }
        #endregion
    }
}