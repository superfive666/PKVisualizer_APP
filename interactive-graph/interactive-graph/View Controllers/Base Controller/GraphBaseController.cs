using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using interactivegraph.Entities;
using interactivegraph.Base_Entities;

namespace interactivegraph.View_Controllers.Base_Controller
{
    public partial class GraphBaseController : UIViewController
    {
        #region View controller attributes here
        public Population GraphPopulation { get; set; }

        public GraphForm Graph_Form { get; set; }
        #endregion

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.


        }

        #region Common graphical behaviours
        protected void SwitchUpPatient()
        {
            GraphPopulation.SwitchPatient(1);
            //To-do: refresh graph
        }

        protected void ChangePopulation()
        {
            GraphPopulation.ChangePopulation();
            //To-do: refresh graph
        }

        protected void OptimizeCondition(Patient _patient)
        {
            GraphPopulation.OptimizeCondition(_patient);
            //To-do: refresh graph
        }

        protected void BackToDefault()
        {
            GraphPopulation.BackToDefault();
            //To-do: refresh graph
        }

        protected virtual void ShowPatientData() { }
        protected virtual void ShowPopulationData() { }
        #endregion
    }
}