using Application.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BDD_with_Specflow.StepDefinition
{
    [Binding]
    public sealed class Naukri_Steps
    {
        private readonly IWebDriver driver;
        public Naukri_Steps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Login to Naukri profile with valid creds")]
        public void GivenLoginToNaukriProfileWithValidCreds()
        {
            //driver.Navigate().GoToUrl(TestContext.Parameters["url"]);
            //FW.Log.Info($"Landed on Url -> {TestContext.Parameters["url"]}");

            Pages.NavigateToNaukri().LoginWithValidCreds();

        }

        [Then(@"Navigate to Profile session")]
        public void ThenNavigateToProfileSession()
        {
            Pages.HomePage.ClickOnViewProfile();
        }

        [Then(@"Upload the Resume file '(.*)'")]
        public void ThenUploadTheResume(string fileName)
        {
            Pages.ProfilePage.UploadNewFileAs(fileName);
        }

        [Then(@"Validate the uploaded resume file name")]
        public void ThenValidateTheUploadedResumeFileName()
        {
            string fileName = Pages.ProfilePage.GetTheUploadedFileName();
            Assert.That(fileName, Is.EqualTo("MohamadZabiulla_SDET_CSharp.pdf"), "File was not updated successfully");
        }

        [Then(@"Validate Title of the Page")]
        public void ThenValidateTitleOfThePage()
        {
            string title = Pages.LoginPage.GetTheTitleOfThePage();

            Assert.That(title, Is.EqualTo("Home | Mynaukri"), "User not landed on Home Page");
        }
    }
}
