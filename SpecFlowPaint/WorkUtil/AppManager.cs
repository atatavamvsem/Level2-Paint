using log4net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace SpecFlowPaint
{
    public static class AppManager
    {
        private static readonly ResourceManager ConfData = Resources.ConfData.ResourceManager;
        private static Application application;
        private static readonly ILog logger = Log4Net.GetInstance();

        public static void GetApplication()
        {
            try
            {
                application = Application.Launch(ConfData.GetString("AppName"));
                logger.Info("Calculator is running");
            }
            catch
            {
                logger.Error("Calculator hasn't run");
            }
        }

        public static void CloseAllInstants()
        {
            try
            {
                IEnumerable<Process> calculatorProcesses = Process.GetProcesses().
                Where(pr => pr.ProcessName == ConfData.GetString("ProcessName"));

                foreach (var process in calculatorProcesses)
                {
                    process.Kill();
                }
                logger.Info("All instances have closed");
            }
            catch
            {
                logger.Error("Instances haven't closed");
            }
        }

        public static Window GetWindow(string windowName)
        {
            SearchCriteria sc = SearchCriteria.ByClassName("MSPaintApp");
            Window app = application.GetWindow(sc, InitializeOption.NoCache);
            return app;
        }

        public static void Close()
        {
            try
            {
                application.Kill();
                logger.Info("Calculator is closed");
            }
            catch
            {
                logger.Error("Calculator hasn't closed");
            }
        }

        public static string GetWindowName(string windowName)
        {
            Window b = GetWindow(windowName);
            return b.ToString();
        }
    }
}