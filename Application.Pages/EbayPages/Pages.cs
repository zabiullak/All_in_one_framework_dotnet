using Framework.Selenium;
using NUnit.Framework;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pages.EbayPages
{
    public class Pages
    {
        [ThreadStatic] public static HomePage HomePage;
        [ThreadStatic] public static FilterPage FilterPage;

        public static void Init()
        {

            HomePage = new HomePage();
            FilterPage = new FilterPage();
        }

        public static HomePage NavigateToEbaySite()
        {
            Driver.Goto(TestContext.Parameters["url"]);
            Log.Information($"Landed on Url -> {TestContext.Parameters["url"]}");
            return new HomePage();
        }
    }
}
