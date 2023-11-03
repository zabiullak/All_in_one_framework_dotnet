using Application.Pages.EbayPages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_with_Specflow.StepDefinition
{
    [Binding]
    public sealed class EbayProductAccess_Steps
    {
        readonly IWebDriver driver;
        public EbayProductAccess_Steps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Open the Ebay site")]
        public void GivenOpenTheEbaySite()
        {
            Pages.NavigateToEbaySite();
        }

        [When(@"User navigate to Shop by category > Electronics > '([^']*)'")]
        public void WhenUserNavigateToShopByCategoryElectronics(string link)
        {
            Pages.HomePage.ClickOnBtn("Shop by category").ClickOnLink(link);
        }

        [When(@"click on '([^']*)' link")]
        public void WhenClickOnLink(string link)
        {
            Pages.HomePage.ClickOnLink(link);
        }

        [When(@"click on '([^']*)' btn")]
        public void WhenClickOnBtn(string p0)
        {
            Pages.HomePage.ClickOnAllFilter();
        }

        [When(@"Add filter on '([^']*)' -> select '([^']*)' option")]
        public void WhenAddFilterOn_SelectOption(string tabName, string checkBoxName)
        {
            Pages.FilterPage.GotToTab(tabName).SelectCheckBox(checkBoxName);
        }

        [When(@"Add filter on '([^']*)' -> select range '([^']*)' to '([^']*)' dollars")]
        public void WhenAddFilterOn_SelectRangeToDollars(string price, string p1, string p2)
        {
            Pages.FilterPage.GotToTab("Price").EnterPriceRange("200", "500");
        }

        [When(@"User click on Apply btn")]
        public void WhenUserClickOnApplyBtn()
        {
            Pages.FilterPage.ClickOnApplyFilter();
        }

        [Then(@"Validate all the filter tags are applied successfully")]
        public void ThenValidateAllTheFilterTagsAreAppliedSuccessfully()
        {
            bool IsDisplayed = Pages.HomePage.VerifyFilterIsCreatedWith("3 filters applied");

            if (IsDisplayed)
            {
                Pages.HomePage.ClickOnAppliedFilterBtn("3 filters applied");
                Assert.Multiple(() =>
                {
                    Assert.That(Pages.HomePage.IsFilterWithNameIsDisplayed("Condition: New"), Is.True, "Condition: New filter is not applied/ not displayed in the page");
                    Assert.That(Pages.HomePage.IsFilterWithNameIsDisplayed("Price: $200.00 to $500.00"), Is.True, "Price: $200.00 to $500.00 filter is not applied/ not displayed in the page");
                    Assert.That(Pages.HomePage.IsFilterWithNameIsDisplayed("Item Location: Worldwide"), Is.True, "Item Location: Worldwide filter is not applied/ not displayed in the page");
                });
                ;
            }
        }

        [When(@"User Search '([^']*)' item")]
        public void WhenUserSearchItem(string item)
        {
            Pages.HomePage.SearchProductWithName(item).ClickOnSearchIcon();
        }

        [When(@"select the category as '([^']*)'")]
        public void WhenSelectTheCategoryAs(string link)
        {
            Pages.HomePage.ClickOnLink(link);
        }

        [Then(@"Verify the first result name matches with the searched item name i\.e\.,'([^']*)'")]
        public void ThenVerifyTheFirstResultNameMatchesWithTheSearchedItemNameI_E_(string expectedText)
        {
            string itemName = Pages.HomePage.GetFirstItemTitle().ToLower();
            Assert.That(itemName, Does.Contain(expectedText.ToLower()), $"First item Title does not contain - {expectedText} text");
        }

    }
}
