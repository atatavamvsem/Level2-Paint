using NUnit.Framework;
using System.Resources;
using TechTalk.SpecFlow;

namespace SpecFlowPaint.Steps
{
    [Binding]
    public sealed class PaintStepDefinitions
    {
        private static readonly ResourceManager ConfData = Resources.ConfData.ResourceManager;
        private static readonly PaintWindow window = new PaintWindow();

        [Given(@"The paint is opened")]
        public void GivenThePaintIsOpened()
        {
           // Assert.AreEqual(ConfData.GetString("WindowName"), AppManager.GetWindowName(ConfData.GetString("WindowName")), "It's not calculator");
        }

        [When(@"I click View")]
        public void WhenIClickView()
        {
            //window.ClickFile();
            window.ClickOpen();
        }

        [When(@"I click Select")]
        public void WhenIClickSelect()
        {
            window.findRotate();
        }


    }
}
