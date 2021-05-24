using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WPFUIItems;

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

        public IUIItem GetElementByText()
        {
            //.AndControlType(ControlType.Group)
            //IUIItem[] items = Window.GetMultiple(SearchCriteria.ByText("Select"));
            //var group = Window.Get(SearchCriteria.ByControlType(ControlType.SplitButton));
            //var i = group.Items[0]; = 
            IUIItem item = Window.Get(SearchCriteria.ByText(this.criteria));
            return item;
        }

        public void Click()
        {
            logger.Info($"Was clicked {this.name}");
            GetElementByText().Click();
        }

        public static UIItem[] GetElementByTextGroup()
        {
            UIItem[] dd = (UIItem[])Window.GetMultiple(SearchCriteria.ByText("Select"));
            return dd;
        }

        public void MoveOn()
        {
            double bottom = GetElementByText().Bounds.Bottom;
            double left = GetElementByText().Bounds.Left-5;
            var point = new Point(100, 100);
            TestStack.White.InputDevices.Mouse.Instance.Location = new Point(left, bottom);
            Mouse.Instance.Click();
            Button Rotate = new Button("Select all", "AddButton");

            Rotate.ClickR();
            Mouse.Instance.Click();
        }

        public void ClickR()
        {
            logger.Info($"Was clicked {this.name}");
            Menu a = Window.Get<Menu>(SearchCriteria.ByText(this.criteria));
            Mouse.Instance.Location = a.Location;
            Mouse.Instance.Click();
        }
    }
}
