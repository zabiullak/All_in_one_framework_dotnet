using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pages.NaukriPages
{
    public class HomePage
    {
        private HomePage_Map Map;

        public HomePage()
        {
            Map = new HomePage_Map(); 
        }

        public ProfilePage ClickOnViewProfile()
        {
            Map.link_ViewPofile.Click();
            Driver.Wait.Until(d => d.Title == "Profile | Mynaukri");
            return new ProfilePage();
        }
    }

    sealed class HomePage_Map
    {
        public Element link_ViewPofile => Driver.FindElement(By.XPath("//div[@class='view-profile-wrapper']/a"));
    }
}
