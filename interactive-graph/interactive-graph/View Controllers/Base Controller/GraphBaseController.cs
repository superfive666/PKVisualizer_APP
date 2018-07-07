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
        public Population GraphPopulation { get; set; }

        public GraphForm Graph_Form { get; set; }

        private SCIChartSurface _surface;
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

        protected void OptimizeCondition(Patient _patient)
        {
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
            void ConstructSinglePatientView(int i)
            {

                throw new NotImplementedException();
            }

            void ConstructAllPopulationView()
            {

                throw new NotImplementedException();
            }

            switch(Graph_Form)
            {
                case GraphForm.SinglePatientView:
                               ConstructSinglePatientView(GraphPopulation.ActivePatient);
                               break;
                case GraphForm.AllPopulationView:
                               ConstructAllPopulationView();
                               break;
                default: throw new InvalidOperationException("Invalid type of graph.");
            }

            throw new NotImplementedException();
        }

        protected virtual void ShowPatientData() { }
        protected virtual void ShowPopulationData() { }
        #endregion
    }
}