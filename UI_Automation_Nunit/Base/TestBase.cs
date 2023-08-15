using Application.Pages;
using Framework;
using Framework.Selenium;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Automation_Nunit.Base
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
                FW.Log.Info("Outcome: Passed");
            }
            else if (outcome == TestStatus.Failed)
            {
                Driver.TakeScreenShot("test_Failed");
                FW.Log.Info("Outcome: Failed");
            }
            else
            {
                FW.Log.Warning("Outcome: " + outcome);
            }
            Driver.Quit();
        }
    }
}
