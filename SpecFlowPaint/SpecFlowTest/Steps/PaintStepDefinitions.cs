using NUnit.Framework;
using System;
using System.Drawing;
using System.IO;
using System.Resources;
using TechTalk.SpecFlow;

namespace SpecFlowPaint.Steps
{
    [Binding]
    public sealed class PaintStepDefinitions
    {
        private static readonly ResourceManager ConfData = Resources.ConfData.ResourceManager;
        private static readonly ResourceManager TestData = Resources.TestData.ResourceManager;
        private static readonly PaintWindow window = new PaintWindow();
        private static ModalWindow modalWindow;
        private readonly byte[] FileBefore = File.ReadAllBytes(TestData.GetString("PathToFile"));

        [Given(@"The Paint is opened")]
        public void GivenThePaintIsOpened()
        {
            Assert.AreEqual(ConfData.GetString("ProcessName"), AppManager.GetAppName(), "It's not the paint");
        }

        [When(@"I click Select All")]
        public void WhenIClickSelectAll()
        {
            window.ClickSelectAll();
        }

        [When(@"I open a picture")]
        public void WhenIOpenPicture()
        {
            window.OpenDialog();
            modalWindow = new ModalWindow();
            modalWindow.EnterText(TestData.GetString("PathToFile"));
            modalWindow.ClickEnter();
        }

        [When(@"I click Cut")]
        public void WhenIClickCut()
        {
            window.ClickCut();
        }

        [When(@"I close The Paint")]
        public void WhenICloseThePaint()
        {
            window.ClickClose();
        }

        [Then(@"Save dialog appears")]
        public void ThenSaveDialogAppears()
        {
            Assert.IsTrue(AppManager.ModalWindowIsPresent(ConfData.GetString("WindowName"), ConfData.GetString("SaveDialogName")), "Dialog didn't appear");
        }

        [When(@"I click Don't Save")]
        public void WhenIClickDonTSave()
        {
            window.ClickDontSave();
        }

        [Then(@"Picture hasn't changed")]
        public void ThenPictureHasnTChanged()
        {
            byte[] FileAfter = File.ReadAllBytes(TestData.GetString("PathToFile"));
            Assert.IsTrue(FileUtil.FileEquals(FileBefore, FileAfter));
        }
    }
}
