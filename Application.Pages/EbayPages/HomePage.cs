using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pages.EbayPages
{
    public class HomePage
    {
        private readonly HomePage_Map Map;

        public HomePage()
        {
            Map = new HomePage_Map();
        }

        public HomePage ClickOnBtn(string btn)
        {
            //Map.Btn_ShopByCat.Click();
            Driver.SafeNormalClick(Map.Btn_ShopByCat, btn);
            return this;
        }

        public void ClickOnLink(string link)
        {
            By loc = By.XPath(string.Format(Map.link_SubCat, link));
            Driver.SafeNormalClick(loc, link);
        }

        public FilterPage ClickOnAllFilter()
        {
            Driver.SafeNormalClick(Map.Btn_AllFilter, "All filter");
            return new FilterPage();
        }

        public bool VerifyFilterIsCreatedWith(string btn)
        {
            By loc = By.XPath(string.Format(Map.Btn_AppliedFilter, btn));
            return Driver.FindElement(loc).Displayed;
        }

        public void ClickOnAppliedFilterBtn(string btn)
        {
            By loc = By.XPath(string.Format(Map.Btn_AppliedFilter, btn));
            Driver.SafeNormalClick(loc, btn);
        }

        public bool IsFilterWithNameIsDisplayed(string text)
        {
            By loc = By.XPath(string.Format(Map.view_AppliedFilter, text));
            return Driver.FindElement(loc).Displayed;
        }

        public HomePage SearchProductWithName(string item)
        {
            Driver.SafeType(Map.Search_box, item, true, element_name: "Search Box");
            return this;
        }

        public void ClickOnSearchIcon()
        {
            Driver.SafeNormalClick(Map.Search_icon, element_name: "Search Icon");
        }

        public string GetFirstItemTitle()
        {
            return Driver.SafeGetText(Map.FirstItem, element_name: "First Item");
        }
    }

    sealed class HomePage_Map
    {
        public By Btn_ShopByCat => By.Id("gh-shop-a");
        public string link_SubCat => "//a[contains(.,'{0}')]";
        public string Btn_AppliedFilter => "//button/span[.='{0}']";
        public string view_AppliedFilter => "//span[contains(.,'{0}')]";
        public By Btn_AllFilter => By.XPath("//button[.='All Filters']");

        
        public By Search_box => By.XPath("//div[@id='gh-ac-box']//input[@type='text']");
        public By Search_icon => By.Id("gh-btn");
        public By FirstItem => By.XPath("(//li/div//a//span[@role='heading'])[2]");
    }
}
