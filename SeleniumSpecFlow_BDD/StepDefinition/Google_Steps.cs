using Application.Pages;
using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecFlow_BDD.StepDefinition
{
    [Binding]
    public sealed class Google_Steps
    {
        readonly IWebDriver driver;
        public Google_Steps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Navigate to Url '([^']*)'")]
        public void GivenNavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        [Then(@"Validate the Home screen page")]
        public void ThenValidateTheHomeScreenPage()
        {
            Assert.That(driver.Title, Is.EqualTo("Google"), "User not landed on google home page"); 
        }


    }
}
