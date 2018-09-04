using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using interactivegraph.View_Controllers.Base_Controller;
using interactivegraph.Base_Entities;
using interactivegraph.Entities;
using SciChart.iOS.Charting;

namespace interactivegraph.View_Controllers.Graph_Controller
{
    public partial class CIAnalgesicController : GraphBaseController
    {
        public CIAnalgesicController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            RefreshGraph();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.


        }

        #region Private helper classes

        #endregion

        #region Override virtual methods
        protected override void RenderData()
        {
            base.RenderData();
        }

        protected override void PrepareSetting()
        {
            throw new NotImplementedException();
            //base.PrepareSetting();
        }

        protected override void ShowPatientData()
        {
            throw new NotImplementedException();
            //base.ShowPatientData();
        }

        protected override void ShowPopulationData()
        {
            throw new NotImplementedException();
            //base.ShowPopulationData();
        }

        protected override Patient GetOptimizedPatient()
        {
            throw new NotImplementedException();
            //return base.GetOptimizedPatient();
        }
        #endregion
    }
}