using Framework.Logging;
using Framework.Utils;
using NUnit.Framework;
using NUnit.Framework.Internal;
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
        public static Logger Log => _logger ?? throw new NullReferenceException("_logger is null. SetLogger() first.");

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

        public static void SetLogger()
        {
            lock (_setLoggerLock)
            {
                var testResultDir = FolderUtils.WORKSPACE_DIRECTORY + "TestResults";
                var testName = TestContext.CurrentContext.Test.Name.Split('(')[0];
                var fullPath = $"{testResultDir}/{testName}";

                if (Directory.Exists(fullPath))
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullPath + TestContext.CurrentContext.Test.ID);
                }
                else
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullPath);
                }

                _logger = new Logger(testName, CurrentTestDirectory.FullName + "/log.txt");
            }
        }
    }
}
