using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace SpecFlowPaint
{
    internal abstract class BaseElement
    {
        private static readonly ResourceManager ConfData = Resources.ConfData.ResourceManager;
        private readonly ILog logger = Log4Net.GetInstance();
        private static Window Window => AppManager.GetWindow(ConfData.GetString("WindowName"));

        private readonly string criteria;
        private readonly string name;

        public BaseElement(string criteria, String name)
        {
            this.criteria = criteria;
            this.name = name;
        }

        public UIItem GetElementByText()
        {
            return (UIItem)Window.Get(SearchCriteria.ByText(this.criteria));
        }

        public void Click()
        {
            logger.Info($"Was clicked {this.name}");
            GetElementByText().Click();
        }
    }
}
