using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic] private static IWebDriver? _driver;

        [ThreadStatic] public static Wait? Wait;

        [ThreadStatic] public static Window? Window;

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");

        public static void Init()
        {
            _driver = DriverFactory.Build(TestContext.Parameters["browser"], TestContext.Parameters["type"]);
            Wait = new Wait(Convert.ToInt32(TestContext.Parameters["waitSecond"]));
            Window = new Window();
            Window.Maximize();
            webListener = new WebListener(_driver);
            _driver = webListener.Driver;
        }
    }
}
