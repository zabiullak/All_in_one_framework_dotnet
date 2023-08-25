using Application.Pages;
using Framework;
using Framework.Selenium;
using NUnit.Framework.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Automation_Selenium.Base
{
    public abstract class TestBase
    {
        [OneTimeSetUp] 
        public void BeforeAll() 
        {
            FW.CreateTestResultDirectory();
        }

        [SetUp]
        public void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Pages.Init();
        }

        [TearDown]
        public void AfterEach()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;

            if (outcome == TestStatus.Passed)
            {
                Log.Information("Outcome: Passed");
            }
            else if (outcome == TestStatus.Failed)
            {
                string fileLocation = Driver.TakeScreenShot("test_Failed");
                TestContext.AddTestAttachment(Path.GetFullPath(fileLocation), "ScreenShot");
                Log.Information("Outcome: Failed");
            }
            else
            {
                Log.Warning("Outcome: " + outcome);
            }
            Driver.Quit();

            // Finally, once just before the application exits...
            Log.CloseAndFlush();
        }
    }
}
