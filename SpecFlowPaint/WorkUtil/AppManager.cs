using log4net;
using System;
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

        public static Window GetWindowByClassName(string windowName)
        {
            return GetWindow(SearchCriteria.ByClassName(windowName));
        }

        internal static bool ModalWindowIsPresent(string mainWindowName, string dialogWindowName)
        {
            Window mainWindow = GetWindowByClassName(mainWindowName);
            List<Window> app = mainWindow.ModalWindows();
            foreach (Window win in app)
            {
                if (win.Title.Equals(dialogWindowName)) return true;
            }
            return false;
        }

        public static Window GetWindow(SearchCriteria sc)
        {
            return application.GetWindow(sc, InitializeOption.NoCache);
        }

        public static Window GetWindow(string sc)
        {
            return application.GetWindow(sc, InitializeOption.NoCache);
        }

        public static string GetAppName()
        {
            return application.Name;
        }

        public static Window GetModalWindow(string mainWindowName,string windowName)
        {
            return GetWindowByClassName(mainWindowName).ModalWindow(windowName);
        }

        public static void Close()
        {
            try
            {
                application.Kill();
                logger.Info("Paint is closed");
            }
            catch
            {
                logger.Error("Paint hasn't closed");
            }
        }

        public static string GetWindowName(string windowName)
        {
            return GetWindow(windowName).ToString();
        }
    }
}