using System;
using System.Collections.Generic;

using UIKit;

namespace interactivegraph.ViewControllers
{
    public partial class IntroductionPageController : UIPageViewController
    {
        List<UIViewController> pageList;
        public IntroductionPageController(List<UIViewController> pages)
        {
            pageList = pages;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }
    }
}

