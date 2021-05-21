using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPaint.Domain.Windows
{
    public class PaintWindow
    {
        private Button AddButton => new Button("File tab", "AddButton");
        private Button OpenButton => new Button("Open", "AddButton");

        internal void ClickFile()
        {
            AddButton.Click();
        }

        internal void ClickOpen()
        {
            OpenButton.Click();
        }
    }
}
