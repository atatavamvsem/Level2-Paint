using TechTalk.SpecFlow;

namespace SpecFlowPaint.Hooks
{
    [Binding]
    public sealed class BeforeAfterScenario
    {
        [BeforeScenario]
        public static void BeforeScenario()
        {
            AppManager.CloseAllInstants();
            AppManager.GetApplication();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            //AppManager.Close();
        }
    }
}
