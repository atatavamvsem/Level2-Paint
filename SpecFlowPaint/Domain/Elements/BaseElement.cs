using log4net;
using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace SpecFlowPaint
{
    internal abstract class BaseElement
    {
        private readonly ILog logger = Log4Net.GetInstance();

        private readonly string criteria;
        private readonly string name;

        public BaseElement(string criteria, String name)
        {
            this.criteria = criteria;
            this.name = name;
        }

        public IUIItem GetElementByText(Window window)
        {
            IUIItem item = window.Get(SearchCriteria.ByText(this.criteria));
            return item;
        }

        public void Click(Window window)
        {
            logger.Info($"Was clicked {this.name}");
            GetElementByText(window).Click();
        }

        public double GetLeftBounds(Window window)
        {
            return GetElementByText(window).Bounds.Left;
        }

        public double GetBottomBounds(Window window)
        {
            return GetElementByText(window).Bounds.Bottom;
        }
    }
}
