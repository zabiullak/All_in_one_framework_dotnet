using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pages.BookStorePages
{
    public class HomePage
    {
        readonly HomePage_Map Map;

        public HomePage()
        {
            Map = new HomePage_Map();
        }

        public void ClickOnTab(string tabName)
        {
            By loc = By.XPath(string.Format(Map.TabLink, tabName));
            Driver.SafeNormalClick(loc, element_name: tabName);
        }
    }

    public class HomePage_Map
    {
        public string TabLink = "//li/a[.='{0}']";
    }
}
