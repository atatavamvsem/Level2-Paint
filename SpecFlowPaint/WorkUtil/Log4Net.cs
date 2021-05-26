using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace SpecFlowPaint
{
    public class Log4Net
    {
        private static ILog instance;

        public static ILog GetInstance()
        {
            if (instance == null)
            {
                instance = GetLogger();
            }
            return instance;
        }
        public static ILog GetLogger()
        {
            var patterLayout = new PatternLayout
            {
                ConversionPattern = "%date{dd-MMM-yyyy-HH:mm:ss} [%class] - %message%newline"
            };
            patterLayout.ActivateOptions();

            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = patterLayout,
                Threshold = Level.Error
            };

            var fileAppender = new FileAppender()
            {
                Name = "FileAppender",
                Layout = patterLayout,
                Threshold = Level.All,
                AppendToFile = true,
                File = "FileLogger.log"
            };

            fileAppender.ActivateOptions();
            consoleAppender.ActivateOptions();
            BasicConfigurator.Configure(consoleAppender, fileAppender);

            ILog Logger = LogManager.GetLogger(typeof(Log4Net));
            return Logger;
        }
    }
}
