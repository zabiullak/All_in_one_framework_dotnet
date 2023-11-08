using Application.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BDD_with_Specflow.Utils;
using BoDi;
using Framework;
using Framework.Selenium;
using Framework.Utils;
using OpenQA.Selenium;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace BDD_with_Specflow.Hooks
{
    [Binding]
    public class Hook : ExtentReport
    {
        private readonly IObjectContainer _container;

        public Hook(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            FW.CreateTestResultDirectory();
            FW.SetLogger();
            Log.Information("Running before test run...");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Log.Information("Running after test run...");
            ExtentReportTearDown();
        }

        [BeforeFeature(Order =0)]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Log.Information($"Running before feature...{featureContext.FeatureInfo.Title}");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Log.Information("Running after feature...");
        }

        [BeforeScenario(Order = 0)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            Log.Information($"Running before scenario...{scenarioContext.ScenarioInfo.Title}");
            Driver.Init();
            Application.Pages.EbayPages.Pages.Init();
            Application.Pages.NaukriPages.Pages.Init();
            Application.Pages.ParaBank.Pages.Init();
            Application.Pages.BookStorePages.Pages.Init();

            _container.RegisterInstanceAs<IWebDriver>(Driver.Current);

            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Log.Information("Running after scenario...");
            var driver = _container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
            }

            // Finally, once just before the application exits...
            Log.CloseAndFlush();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Log.Information("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
                        
            var driver = _container.Resolve<IWebDriver>();

            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {
                Log.Error("Test Step Failed | " + scenarioContext.TestError.Message);
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
            }
        }
    }
}
