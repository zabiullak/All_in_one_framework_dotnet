using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Selenium
{
    public class WebListener : EventFiringWebDriver
    {
        private EventFiringWebDriver firingDriver;

        public WebListener(IWebDriver driver) : base(driver)
        {
            firingDriver = new EventFiringWebDriver(driver);
            firingDriver.Navigating += new EventHandler<WebDriverNavigationEventArgs>(WhenNavigating);
            firingDriver.Navigated += new EventHandler<WebDriverNavigationEventArgs>(AfterNavigation);
            firingDriver.NavigatingBack += new EventHandler<WebDriverNavigationEventArgs>(WhenNavigatingBack);
            firingDriver.NavigatedBack += new EventHandler<WebDriverNavigationEventArgs>(AfterNavigatedBack);
            firingDriver.NavigatingForward += new EventHandler<WebDriverNavigationEventArgs>(WhenNavigatingForward);
            firingDriver.NavigatedForward += new EventHandler<WebDriverNavigationEventArgs>(AfterNavigatedForward);
            firingDriver.FindingElement += new EventHandler<FindElementEventArgs>(WhenFindingElement);
            firingDriver.FindElementCompleted += new EventHandler<FindElementEventArgs>(AfterElementIsFound);
            firingDriver.ElementClicking += new EventHandler<WebElementEventArgs>(WhenClickingElement);
            firingDriver.ElementClicked += new EventHandler<WebElementEventArgs>(WhenElementIsClicked);
            firingDriver.ExceptionThrown += new EventHandler<WebDriverExceptionEventArgs>(WhenExceptionThrown);
            //firingDriver.ElementValueChanging += new EventHandler<WebElementEventArgs>(WhenElementValueisChanging);
            //firingDriver.ElementValueChanged += new EventHandler<WebElementEventArgs>(AfterElementValueChanged);
            //firingDriver.ExceptionThrown += new EventHandler<WebDriverExceptionEventArgs>(WhenExceptionIsThrown);
        }

        public IWebDriver Driver
        {
            get { return firingDriver; }
        }

        private void WhenExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            //Log.Information();
        }

        private void WhenElementIsClicked(object sender, WebElementEventArgs e)
        {
            Log.Information("Clicked element");
        }

        private void AfterElementIsFound(object sender, FindElementEventArgs e)
        {
            Log.Information("Found Element " + e.FindMethod.ToString());
        }

        private void WhenClickingElement(object sender, WebElementEventArgs e)
        {
            Log.Information("Clicking element");
        }

        private void WhenFindingElement(object sender, FindElementEventArgs e)
        {
            // Log.Information();
        }

        private void AfterNavigatedForward(object sender, WebDriverNavigationEventArgs e)
        {
            Log.Information("Navigated forward");
        }

        private void WhenNavigatingForward(object sender, WebDriverNavigationEventArgs e)
        {
            //Log.Information("Navigating forward");
        }

        private void AfterNavigatedBack(object sender, WebDriverNavigationEventArgs e)
        {
            Log.Information("Navigated back");
        }

        private void WhenNavigatingBack(object sender, WebDriverNavigationEventArgs e)
        {
            //Log.Information("Navigating back");
        }

        private void AfterNavigation(object sender, WebDriverNavigationEventArgs e)
        {
            Log.Information("Navigated to url " + e.Url);
        }

        private void WhenNavigating(object sender, WebDriverNavigationEventArgs e)
        {
            //Log.Information("Navigating to url " + e.Url);
        }
    }
}
