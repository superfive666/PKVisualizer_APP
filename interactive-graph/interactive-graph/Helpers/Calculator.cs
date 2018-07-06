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
            double CalculateABS(double ti)
            {
                var a1 = patient.Bioavailability * patient.Dose;
                var a2 = 1 - Math.Exp(-patient.Ka * ti);
                var a3 = a1 * a2 / patient.VolumeDistribution;
                return ti < patient.Tau? 
                       a3 : a3 + CalculateABS(ti - patient.Tau);
            }

            Func<double, double> CalculateELI = (p) =>
            {
                var a1 = patient.VMAX * p * 1000;
                var a2 = (patient.KM + p) * patient.VolumeDistribution;
                return Patient.TimeInterval * a1 / a2;
            };

            var abs = CalculateABS(t);
            Patient.T += t % patient.Tau == 0 ?
                         CalculateELI.Invoke(abs) :
                         CalculateELI.Invoke(Patient.PrevValue);

            return abs - Patient.T;
        }
        #endregion
    }
}