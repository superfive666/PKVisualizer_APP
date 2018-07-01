using System;
using interactivegraph.Base_Entities;

namespace interactivegraph.Helpers
{
    public static class Calculator
    {
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

        public static double ConcentrationAtTime(double t, Patient patient)
        {
            switch(patient.Type)
            {
                case GraphType.Continuous_Intravenous_Analgesic: return Graph1(t, patient);
                case GraphType.Multiple_Dose_IV_Infusion: return Graph2(t, patient);
                case GraphType.Multiple_Oral_Dose_NSAID: 
                case GraphType.Multiple_Oral_Dose_Antithrombotic: 
                case GraphType.Multiple_Oral_Dose_Anticoagulant: 
                case GraphType.Multiple_Oral_dose_Antibiotics: return Graph3(t, patient);
                case GraphType.Phenytoin_Formulation: return Graph8(t, patient);
            }

            throw new NotImplementedException();
        }

        private static double Graph1(double t, Patient patient)
        {

            return 0;
        }

        private static double Graph2(double t, Patient patient)
        {

            return 0;
        }

        private static double Graph3(double t, Patient patient)
        {

            return 0;
        }

        private static double Graph8(double t, Patient patient)
        {

            return 0;
        }

    }
}