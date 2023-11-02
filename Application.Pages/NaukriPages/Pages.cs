using Application.Pages.NaukriPages;
using Framework.Selenium;
using Framework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Pages.ParaBank;
using Serilog;

namespace Application.Pages.NaukriPages
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
            Log.Information($"Landed on Url -> {TestContext.Parameters["url"]}");
            return new LoginPage();
        }
    }
}
