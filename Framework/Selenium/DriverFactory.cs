﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Selenium
{
    public static class DriverFactory
    {
        static ChromeOptions chrome_options = new ChromeOptions();
        static EdgeOptions edge_options = new EdgeOptions();

        public static IWebDriver Build(string browserName, string type)
        {
            Log.Information($"Browser: {browserName}");

            if (type.ToLower() == "local")
            {
                switch (browserName.ToLower())
                {
                    case "chrome":
                        return new ChromeDriver(AddChromeOptions());
                    case "edge":
                        return new EdgeDriver(AddEdgeOptions());
                    default:
                        throw new System.ArgumentException($"{browserName} not supported locally.");
                }
            }
            else if (type.ToLower() == "remote")
            {
                return BuildRemoteDriver(browserName);
            }
            else
            {
                throw new ArgumentException($"{type} is invalid. Choose 'local' or 'remote'.");
            }

        }

        public static ChromeOptions AddChromeOptions()
        {
            Log.Information("Launching google chrome with new profile..");
            chrome_options.AddArguments("--disable-extensions");
            chrome_options.AddArguments("--disable-notifications");
            //options.AddUserProfilePreference("download.default_directory", _autoUtils.GetRepoDownloadFolder());
            chrome_options.AddUserProfilePreference("download.prompt_for_download", false);
            chrome_options.AddUserProfilePreference("safebrowsing.enabled", true);
            chrome_options.AddArgument("no-sandbox");
            chrome_options.AddArguments("enable-features=NetworkServiceInProcess");
            chrome_options.AddArguments("disable-features=NetworkService");
            if (TestContext.Parameters["headless"].ToLower() == "true" || TestContext.Parameters["headless"].ToLower() == "yes")
            {
                chrome_options.AddArgument("--headless=new");
            }
            return chrome_options;
        }

        public static EdgeOptions AddEdgeOptions()
        {
            Log.Information("Launching google chrome with new profile..");
            edge_options.AddArguments("--disable-extensions");
            edge_options.AddArguments("--disable-notifications");
            //options.AddUserProfilePreference("download.default_directory", _autoUtils.GetRepoDownloadFolder());
            edge_options.AddUserProfilePreference("download.prompt_for_download", false);
            edge_options.AddUserProfilePreference("safebrowsing.enabled", true);
            edge_options.AddArgument("no-sandbox");
            edge_options.AddArguments("enable-features=NetworkServiceInProcess");
            edge_options.AddArguments("disable-features=NetworkService");
            if (TestContext.Parameters["headless"].ToLower() == "true" || TestContext.Parameters["headless"].ToLower() == "yes")
            {
                edge_options.AddArgument("--headless=new");
            }
            return edge_options;
        }

        private static IWebDriver BuildRemoteDriver(string browserName)
        {
            //var DOCKER_GRID_HUB_URI = new Uri("http://localhost:4444/wd/hub");
            RemoteWebDriver driver;

            switch (browserName.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions
                    {
                        BrowserVersion = "",
                        //PlatformName = "Windows 10",
                    };

                    chromeOptions.AddArgument("--start-maximized");

                    driver = new RemoteWebDriver(new Uri(TestContext.Parameters["DOCKER_GRID_HUB_URI"]), chromeOptions.ToCapabilities());
                    break;

                case "edge":
                    var edgexOptions = new EdgeOptions
                    {
                        BrowserVersion = "",
                        //PlatformName = "Windows 10",
                    };

                    driver = new RemoteWebDriver(new Uri(TestContext.Parameters["DOCKER_GRID_HUB_URI"]), edgexOptions.ToCapabilities());
                    break;

                default:
                    throw new ArgumentException($"{browserName} is not supported remotely.");
            }
            return driver;
        }
    }
}
