using Application.Pages.BookStorePages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_with_Specflow.StepDefinition
{
    [Binding]
    public class BookStore_Steps
    {
        readonly IWebDriver driver;
        public BookStore_Steps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [When(@"User navigate on '([^']*)' page")]
        public void WhenUserNavigateOnPage(string tabName)
        {
            Pages.HomePage.ClickOnTab(tabName);
        }

    }
}
