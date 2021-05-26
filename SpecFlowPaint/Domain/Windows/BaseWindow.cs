using log4net;
using SpecFlowPaint.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace SpecFlowPaint
{
    internal abstract class BaseWindow
    {
        private readonly ILog logger = Log4Net.GetInstance();
        public void OpenPicture(Window Window)
        {
            Window.Keyboard.HoldKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL);
            Window.Keyboard.Enter("O");
            Window.Keyboard.LeaveKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL);
            logger.Info("Was opened dialog");
        }

        public void ClickEnter(Window Window)
        {
            Window.Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.RETURN);
        }

        public void MoveMouse(double left, double right, Window Window)
        {
            Window.Mouse.Location = new Point(left, right);
            logger.Info("Mouse was moved");
        }

        public void ClickMouse(Window Window)
        {
            Window.Mouse.Click();
            logger.Info("Mouse was clicked");
        }
    }
}
