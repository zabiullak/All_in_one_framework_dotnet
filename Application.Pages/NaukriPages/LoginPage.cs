using Framework;
using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pages.NaukriPages
{
    public class LoginPage
    {
        private readonly LoginPage_Map Map;

        public LoginPage()
        {
            Map = new LoginPage_Map();
        }

        public string GetTheTitleOfThePage()
        {
            return Driver.Current.Title;
        }

        public LoginPage LoginWithValidCreds()
        {
            Map.UN.SendKeys("zabiulla.edu@gmail.com");
            Map.PWD.SendKeys("naukri123@Zabi");
            Map.Btn_Login.Click();
            Driver.Wait.Until(d => d.Title == "Home | Mynaukri");
            return this;
        }
    }

    sealed class LoginPage_Map
    {
        public Element UN => Driver.FindElement(By.Id("usernameField"));
        public Element PWD => Driver.FindElement(By.Id("passwordField"));
        public Element Btn_Login => Driver.FindElement(By.XPath("//button[.='Login']"));
    }
}
