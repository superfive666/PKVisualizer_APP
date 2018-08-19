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

        public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            var cur = pageList.IndexOf(referenceViewController);
            if (cur < pageList.Count -1 )
            {
                return pageList[++cur];
            } else 
            {
                return null;
            }
        }

        public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            var cur = pageList.IndexOf(referenceViewController);
            if (cur > 0)
            {
                return pageList[--cur];
            } else 
            {
                return null;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }
    }
}

