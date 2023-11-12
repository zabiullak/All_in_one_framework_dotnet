using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Framework.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumSpecflowPOM_BDD.Utils
{
    public abstract class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        //public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(FolderUtils.GetTestResultFolder()+ $"{Helper.GetDateValue(0).ToString("d_MM_yyyy")}/");
            htmlReporter.Config.ReportName = "Automation UI testing Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", TestContext.Parameters["Application"]);
            _extentReports.AddSystemInfo("Browser", TestContext.Parameters["browser"]);
            _extentReports.AddSystemInfo("OS", TestContext.Parameters["OS"]);
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        public string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(FolderUtils.GetTestResultFolder() + Helper.GetDateValue(0).ToString("d_MM_yyyy"), scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Png);
            return screenshotLocation;
        }
    }
}
