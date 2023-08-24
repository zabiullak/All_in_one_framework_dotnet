using Application.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_with_Specflow.StepDefinition
{
    [Binding]
    public sealed class ParaBank_Steps
    {
        readonly IWebDriver driver;

        public ParaBank_Steps(IWebDriver driver)
        {
            this.driver = driver;
        }
        [When(@"Enter User Name as '([^']*)'")]
        public void WhenEnterUserNameAs(string UN)
        {
            Pages.IndexPage.EnterUserName(UN);
        }

        [When(@"Enter Password as '([^']*)'")]
        public void WhenEnterPasswordAs(string Pwd)
        {
            Pages.IndexPage.EnterUserPassword(Pwd);
        }

        [Then(@"Click on Login")]
        public void ThenClickOnLogin()
        {
            Pages.IndexPage.ClickOnLogin();
        }

        [Then(@"Validate that User succussfully landed to home screen")]
        public void ThenValidateThatUserSuccussfullyLandedToHomeScreen()
        {
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Accounts Overview"), "User not logged in successfully");
        }

    }
}
