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

namespace Application.Pages.ParaBank
{
    public class Pages
    {
        [ThreadStatic] public static IndexPage IndexPage;

        public static void Init()
        {

            IndexPage = new IndexPage();
        }

        //public static LoginPage NavigateToNaukri()
        //{
        //    Driver.Goto(TestContext.Parameters["url"]);
        //    Log.Information($"Landed on Url -> {TestContext.Parameters["url"]}");
        //    return new LoginPage();
        //}
    }
}
