using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.WindowItems;

namespace SpecFlowPaint
{
    internal class TextBox : BaseElement
    {
        public TextBox(string criteria, string name) : base(criteria, name)
        {
        }

        internal void Enter(Window Window, string text)
        {
            GetElementByText(Window).Enter(text);
        }
    }
}
