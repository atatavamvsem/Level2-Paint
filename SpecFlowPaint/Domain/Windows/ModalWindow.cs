using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.WindowItems;

namespace SpecFlowPaint
{
    internal class ModalWindow : BaseWindow
    {
        private static readonly ResourceManager TestData = Resources.TestData.ResourceManager;
        private static readonly Window Window = AppManager.GetModalWindow(TestData.GetString("WindowName"), TestData.GetString("OpenDialogName"));

        private TextBox TextBox => new TextBox("File name:", "File name TextBox");

        public void EnterText(string text)
        {
            TextBox.Enter(Window, text);
        }

        public void ClickEnter()
        {
            ClickEnter(Window);
        }
    }
}
