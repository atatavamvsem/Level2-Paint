using SpecFlowPaint.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.WindowItems;

namespace SpecFlowPaint
{
    public class PaintWindow
    {
        private Button AddButton => new Button("File tab", "AddButton");
        private Button Rotate => new Button("Resize", "AddButton");
        //private Button[] Select => BaseElement.GetElementByTextGroup();

        private static readonly ResourceManager ConfData = Resources.ConfData.ResourceManager;
        private static Window Window ;

        internal void ClickFile()
        {
            AddButton.Click();
        }

        internal void ClickOpen()
        {
            Window = AppManager.GetWindow(ConfData.GetString("WindowName"));
            Keyboard.Instance.HoldKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter("O");
            Keyboard.Instance.LeaveKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL);
            Window = AppManager.GetWindow("Open");
            Window.Enter(@"C:\a.jpg");
            Keyboard.Instance.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.RETURN);
            Window = AppManager.GetWindow(ConfData.GetString("WindowName"));
            //BaseElement.GetElementByTextGroup();
            //AddButton.Click();
        }

        internal void findRotate()
        {
            Rotate.GetElementByText();
            Rotate.MoveOn();
        }
    }
}
