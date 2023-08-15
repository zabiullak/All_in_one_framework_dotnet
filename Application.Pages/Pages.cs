using Application.Pages.NaukriPages;
using Framework.Selenium;
using Framework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pages
{
    public class Pages
    {
        [ThreadStatic] public static LoginPage LoginPage;
        [ThreadStatic] public static HomePage HomePage;
        [ThreadStatic] public static ProfilePage ProfilePage;

        public static void Init()
        {

            LoginPage = new LoginPage();
            HomePage = new HomePage();
            ProfilePage = new ProfilePage();
        }

        public static LoginPage NavigateToNaukri()
        {
            Driver.Goto(TestContext.Parameters["url"]);
            FW.Log.Info($"Landed on Url -> {TestContext.Parameters["url"]}");
            return new LoginPage();
        }
    }
}
