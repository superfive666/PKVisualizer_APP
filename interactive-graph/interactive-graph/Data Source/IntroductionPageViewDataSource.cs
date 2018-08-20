using System.Collections.Generic;
using UIKit;

namespace interactivegraph.DataSource
{
    public class IntroductionPageViewDataSource : UIPageViewControllerDataSource
    {
        List<UIViewController> pageList;   
        public IntroductionPageViewDataSource(List<UIViewController> pages)
        {
            pageList = pages;
        }

        public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            var cur = pageList.IndexOf(referenceViewController);
            if (cur < pageList.Count - 1)
            {
                return pageList[++cur];
            }
            else
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
            }
            else
            {
                return null;
            }
        }
    }
}
