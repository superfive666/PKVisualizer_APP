using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using interactivegraph.Entities;
using interactivegraph.Base_Entities;
using SciChart.iOS.Charting;

namespace interactivegraph.View_Controllers.Base_Controller
{
    public partial class GraphBaseController : UIViewController
    {
        #region View controller attributes here
        protected Population GraphPopulation { get; set; }

        protected GraphForm Graph_Form { get; set; }

        protected SCIChartSurface _surface;
        #endregion

        #region Public construction here
        public GraphBaseController(IntPtr handle) : base(handle) { }
        #endregion

        #region Common graphical behaviours
        protected void SwitchUpPatient()
        {
            GraphPopulation.SwitchPatient(1);
            RefreshGraph();
        }

        protected void ChangePopulation()
        {
            GraphPopulation.ChangePopulation();
            RefreshGraph();
        }

        protected void OptimizeCondition()
        {
            var _patient = GetOptimizedPatient();
            GraphPopulation.OptimizeCondition(_patient);
            RefreshGraph();
        }

        protected void BackToDefault()
        {
            GraphPopulation.BackToDefault();
            RefreshGraph();
        }

        protected void ToggleGraphForm()
        {
            Graph_Form = Graph_Form == GraphForm.AllPopulationView ?
                         GraphForm.SinglePatientView :
                         GraphForm.AllPopulationView;

            RefreshGraph();
        }

        protected void RefreshGraph()
        {
            _surface.RenderableSeries.Clear();
            RenderData();
        }

        #region Virtual methods
        protected virtual void ShowPatientData() { }
        protected virtual void ShowPopulationData() { }
        protected virtual void RenderData()
        {
            void PopulateData(int i, bool ave)
            {
                var name = ave ? "Average" : "Patient - " + (i + 1).ToString();
                var _data = new XyDataSeries<Double, Double>() { SeriesName = name };
                foreach (var data in GraphPopulation.PopulationGraph)
                {
                    _data.Append(data[0], data[ave ? 21 : i]);
                }
                var _line = new SCIFastLineRenderableSeries();
                _line.DataSeries = _data;
                _line.XAxisId = "Time";
                _line.YAxisId = "Concentration";
                _surface.RenderableSeries.Add(_line);
            }

            GraphPopulation = new Population(GraphType.Continuous_Intravenous_Analgesic);
            if (Graph_Form == GraphForm.SinglePatientView)
            {
                PopulateData(GraphPopulation.ActivePatient, false);
            }
            else
            {
                for (int i = 0; i < GraphPopulation.Patients.Count; i++)
                {
                    PopulateData(i, false);
                }
                PopulateData(21, true);
            }
        }
        protected virtual void PrepareSetting() { }
        protected virtual Patient GetOptimizedPatient() { return new Patient(); }
        #endregion

        #endregion
    }
}