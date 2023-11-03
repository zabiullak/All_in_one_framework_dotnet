using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pages.EbayPages
{
    public class FilterPage
    {
        private readonly FilterPage_Map Map;

        public FilterPage()
        {
            Map = new FilterPage_Map();
        }

        public HomePage ClickOnApplyFilter()
        {
            Map.btn_Apply.Click();
            return new HomePage();
        }

        public void EnterPriceRange(string startRange, string endRange)
        {
            Map.textBox_filter.First().SendKeys(startRange);
            Map.textBox_filter.Last().SendKeys(endRange);
        }

        public FilterPage GotToTab(string tabName)
        {
            By loc = By.XPath(string.Format(Map.tab_filter, tabName));
            Driver.SafeNormalClick(loc, tabName);
            return this;
        }

        public FilterPage SelectCheckBox(string checkBoxName)
        {
            By loc = By.XPath(string.Format(Map.checkbox_filter, checkBoxName));
            Driver.SafeActionClick(loc, checkBoxName);
            return this;
        }
    }
    sealed class FilterPage_Map
    {
        public string tab_filter => "//div[@role='tab']/span[.='{0}']";
        public string checkbox_filter => "//div[contains(@id,'{0}')]//input";
        public Elements textBox_filter => Driver.FindElements(By.XPath("//div[contains(@id,'price')]//input[@type='text']"));
        public Element btn_Apply => Driver.FindElement(By.XPath("//button[.='Apply']"));
    }
}
