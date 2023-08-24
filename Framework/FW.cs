using Framework.Logging;
using Framework.Utils;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Serilog.Core;
using Serilog.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger = Framework.Logging.Logger;

namespace Framework
{
    public class FW
    {
        //public static Logger Log => _logger ?? throw new NullReferenceException("_logger is null. SetLogger() first.");

        [ThreadStatic] public static DirectoryInfo? CurrentTestDirectory;
        [ThreadStatic] public static Logger? _logger;

        public static DirectoryInfo CreateTestResultDirectory()
        {
            var testDirectory = FolderUtils.WORKSPACE_DIRECTORY + "TestResults";
            if (Directory.Exists(testDirectory))
            {
                Directory.Delete(testDirectory, recursive: true);
            }
            return Directory.CreateDirectory(testDirectory);
        }

        private static object _setLoggerLock = new object();

        //public static void SetLogger()
        //{
        //    lock (_setLoggerLock)
        //    {
        //        var testResultDir = FolderUtils.WORKSPACE_DIRECTORY + "TestResults";
        //        var testName = TestContext.CurrentContext.Test.Name.Split('(')[0];
        //        var fullPath = $"{testResultDir}/{testName}";

        //        if (Directory.Exists(fullPath))
        //        {
        //            CurrentTestDirectory = Directory.CreateDirectory(fullPath + TestContext.CurrentContext.Test.ID);
        //        }
        //        else
        //        {
        //            CurrentTestDirectory = Directory.CreateDirectory(fullPath);
        //        }

        //        _logger = new Logger(testName, CurrentTestDirectory.FullName + "/log.txt");
        //    }
        //}

        public static void SetLogger()
        {
            lock (_setLoggerLock)
            {
                //LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(LogEventLevel.Debug);
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.File(FolderUtils.GetTestResultFolder() + $"{Helper.GetDateValue(0).ToString("d_MM_yyyy")}/log.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day).CreateLogger();
            }
        }
    }
}
