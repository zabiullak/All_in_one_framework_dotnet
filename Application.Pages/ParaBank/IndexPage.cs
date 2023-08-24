using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pages.ParaBank
{
    public class IndexPage
    {
        readonly IndexPage_Map Map;
        
        public IndexPage()
        {
            Map = new IndexPage_Map();
        }

        public void ClickOnLogin()
        {
            Map.Login.Click();
        }

        public void EnterUserName(string uN)
        {
            Map.UserName.SendKeys(uN);
        }

        public void EnterUserPassword(string pwd)
        {
            Map.Password.SendKeys(pwd);
        }
    }

    sealed class IndexPage_Map
    {
        public Element UserName => Driver.FindElement(By.Name("username"));
        public Element Password => Driver.FindElement(By.Name("password"));
        public Element Login => Driver.FindElement(By.XPath("//input[@value='Log In']"));
    }
}
