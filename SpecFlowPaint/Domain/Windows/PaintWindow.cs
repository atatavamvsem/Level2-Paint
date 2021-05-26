using System;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace SpecFlowPaint
{
    internal class PaintWindow : BaseWindow
    {
        private static readonly ResourceManager TestData = Resources.TestData.ResourceManager;
        private static readonly Window Window = AppManager.GetWindowByClassName(TestData.GetString("WindowName"));
        private Button ResizeButton => new Button("Resize", "Resize Button");
        private Button SelectAllButton => new Button("Select all", "Select All Button");
        private Button CutButton => new Button("Cut", "Cut Button");
        private Button СloseButton => new Button("Close", "Сlose Button");
        private Button DontSaveButton => new Button("Don't Save", "Dont Save Button");

        internal void ClickCut()
        {
            CutButton.Click(Window);
        }

        internal void ClickClose()
        {
            СloseButton.Click(Window);
        }

        internal void ClickDontSave()
        {
            DontSaveButton.Click(Window);
        }

        internal void OpenDialog()
        {
            OpenPicture(Window);
        }

        internal void ClickSelectAll()
        {
            ClickSelectExtended();
            SelectAllButton.Click(Window);
            SelectAllButton.Click(Window);
        }

        internal void ClickSelectExtended()
        {
            ResizeButton.GetElementByText(Window);
            MoveMouse(ResizeButton.GetLeftBounds(Window) - Convert.ToDouble(TestData.GetString("DeltaMove")), ResizeButton.GetBottomBounds(Window), Window);
            ClickMouse(Window);
        }
    }
}
