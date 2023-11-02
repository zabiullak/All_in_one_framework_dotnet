using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic] private static IWebDriver? _driver;

        [ThreadStatic] public static Wait? Wait;

        [ThreadStatic] public static Window? Window;

        [ThreadStatic] public static WebListener? webListener;

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

        public static void Goto(string? url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }
            //Log.Information(url);
            Current.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Finds the element based on the locator provided.
        /// </summary>
        /// <param name="by">FindBy mechanism.</param>
        /// <param name="elementName">Name of element for logging purposes.</param>
        public static Element FindElement(By by, [Optional] string eleName)
        {
            var wait = new WebDriverWait(Current, TimeSpan.FromSeconds(Convert.ToInt32(TestContext.Parameters["waitSecond"])));
            IWebElement webelement = wait.Until(ExpectedConditions.ElementExists(by));
            return new Element(webelement, eleName)
            {
                FoundBy = by
            };
        }

        /// <summary>
        /// Finds the elements based on the locator provided.
        /// </summary>
        /// <param name="by">FindBy mechanism.</param>
        public static Elements FindElements(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }

        public static void SafeNormalClick(By locator, string element_name = "", Boolean throwException = true)
        {
            try
            {
                ScrollIntoView(locator);
                IsElementClickable(locator);
                IWebElement ele = FindElement(locator, element_name);
                if (ele != null)
                {
                    ele.Click();
                    Console.WriteLine("In If block::Clicked on element::" + ele);
                }
                Console.WriteLine("Clicked on element " + locator);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("In Catch block NoSuchElementException e");
                //_autoUtils.getScreenshot(Driver);
                if (throwException)
                {
                    Assert.Fail("Given element " + element_name + "\n The locator is : [" + locator + "]. does not Exist - Follow the below exception.. \n" +
                           e.Message.Replace('{', '[').Replace('}', ']') + "\n Please refer to the above [Screenshot] for more information...");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("In Catch block Exception e");
                Console.WriteLine("Unable to click on : " + element_name + "\n element [" + locator + "].element - Follow the below exception.. \n" +
                          e.Message.Replace('{', '[').Replace('}', ']'));
                //_autoUtils.getScreenshot(Driver);
                if (throwException)
                {
                    Assert.Fail("Unable  to click  on " + element_name + "\n The locator is : [" + locator.ToString() + "]. Element - Follow the below exception.. \n" +
                            e.Message.Replace('{', '[').Replace('}', ']') + "\n Please refer to the above [Screenshot] for more information...");
                }

            }
        }

        public static bool SafeActionClick(By bylocator, [Optional] string eleName)
        {
            IWebElement webelement = WaitUntilElementExists(bylocator);

            if (webelement != null)
            {
                try
                {
                    new Actions(Current).MoveToElement(webelement).Click().Perform();
                    return true;
                }
                catch (Exception)
                {
                    //TestLog.AttachImage("Click here for Screenshot", _autoutilities.getScreenshot(Driver));	               
                    //_autoutilities.getScreenshot(Driver);
                    return false;
                }
            }
            else { return false; }
        }

        public static void SafeType(By locator, string text, bool clear = false, string element_name = "")
        {
            try
            {
                if (clear)
                    FindElement(locator, element_name).Clear();
                FindElement(locator).SendKeys(text);
                Console.WriteLine("Entered text " + text + " in the field " + locator);
            }
            catch (NoSuchElementException e)
            {
                //_autoutilities.getScreenshot(Driver);
                //TestLog.AttachImage("Click here for Screenshot",_autoutilities.getScreenshot(Driver));
                Console.WriteLine("Given element " + locator + ". does not Exist - Follow the below exception.. \n" +
                          e.Message.Replace('{', '[').Replace('}', ']'));
                Assert.Fail("Given element " + element_name + "[" + locator + "]. does not Exist - Follow the below exception.. \n" +
                            e.Message.Replace('{', '[').Replace('}', ']') + "\n Please refer to the above [Screenshot] for more information...");


            }
            catch (Exception e)
            {
                //TestLog.AttachImage("Click here for Screenshot", _autoutilities.getScreenshot(Driver));
                // _autoutilities.getScreenshot(Driver);
                Console.WriteLine("Unable to enter text" + locator + ". - Follow the below exception.. \n" +
                          e.Message.Replace('{', '[').Replace('}', ']'));
                Assert.Fail("Unable  to enter text " + element_name + "\n The locator is : [" + locator.ToString() + "] - Follow the below exception.. \n" +
                            e.Message.Replace('{', '[').Replace('}', ']') + "\n Please refer to the above [Screenshot] for more information...");

            }
        }

        public static void JavaScriptSafeType(By locator, string text, string element_name = "")
        {
            IJavaScriptExecutor? JsDriver = Current as IJavaScriptExecutor;
            try
            {
                ScrollIntoView(locator);
                JsDriver.ExecuteScript("arguments[0].innerHTML='" + text + "';", FindElement(locator, element_name));
                Console.WriteLine("Entered text " + text + " in the field " + locator);
            }

            catch (Exception e)
            {
                //_autoutilities.getScreenshot(Driver);
                Console.WriteLine("Unable to enter text" + locator + ". - Follow the below exception.. \n" +
                          e.Message.Replace('{', '[').Replace('}', ']'));
                Assert.Fail("Unable  to enter text " + element_name + "\n The locator is : [" + locator.ToString() + "] - Follow the below exception.. \n" +
                            e.Message.Replace('{', '[').Replace('}', ']') + "\n Please refer to the above [Screenshot] for more information...");

            }
        }

        public static string SafeGetText(By locator, string element_name = "")
        {
            int repeat = 0;
            while (repeat <= 3)
            {
                try
                {
                    ScrollIntoView(locator);
                    IWebElement ele = FindElement(locator);
                    if (ele == null)
                        return null;
                    string text = ele.Text.Trim();
                    Console.WriteLine("Taken " + element_name + "[" + locator + "] locater text");
                    return text;
                }
                catch (StaleElementReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception e)
                {
                    //TestLog.AttachImage("Click here for Screenshot", _autoutilities.getScreenshot(Driver));
                    //_autoutilities.getScreenshot(Driver);
                    Console.WriteLine(e.Message.Replace('{', '[').Replace('}', ']'));
                    Assert.Fail("unable to get text for " + element_name + "\n" + e.Message.Replace('{', '[').Replace('}', ']') + "\n Please refer to the above [Screenshot] for more information...");
                }
                repeat++;
            }
            return null;
        }

        public static string SafeGetAttributeValue(By locator, string attributeName, int timeOutInSeconds = 60, string element_name = "", Boolean throwException = true)
        {
            try
            {

                ScrollIntoView(locator);
                IWebElement ele = FindElement(locator);
                string ele_value = ele.GetAttribute(attributeName);
                Console.WriteLine("Took " + element_name + "[" + locator + "] locater value");

                return ele_value;

            }
            catch (Exception e)
            {
                if (throwException)
                {
                    //_autoutilities.getScreenshot(Driver);
                    Console.WriteLine("Unable to get attribute value. Follow the below exception \n" +
                                e.Message.Replace('{', '[').Replace('}', ']'));
                    Assert.Fail("Unable to get attribute value. Follow the below exception \n" +
                                e.Message.Replace('{', '[').Replace('}', ']') + "\n Please refer to the above [Screenshot] for more information...");
                }
            }
            return null;
        }


        public static bool IsElementClickable(By locator)
        {
            Current.SetImplicitWait(0);
            try
            {
                Console.WriteLine("Waiting for element: " + locator + " for " + Convert.ToInt32(TestContext.Parameters["waitSecond"]) + " seconds");
                var wait = new WebDriverWait(Current, TimeSpan.FromSeconds(Convert.ToInt32(TestContext.Parameters["waitSecond"])));
                IWebElement webelement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable((locator)));
                Current.SetImplicitWait(TimeOuts.IMPLICITWAIT);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                Current.SetImplicitWait(TimeOuts.IMPLICITWAIT);
                return false;
            }
            catch (UnhandledAlertException e)
            {
                Console.WriteLine("Alert displayed is " + e.AlertText);
                Current.SwitchTo().Alert().Accept();
                Current.SetImplicitWait(TimeOuts.IMPLICITWAIT);
                return false;
            }
            catch (Exception)
            {
                Current.SetImplicitWait(TimeOuts.IMPLICITWAIT);
                return false;
            }
        }

        /*
        * Method : IsTextPresentOnPageSource
        * Purpose: Checks whether the particular string exists in the page source
        * Params : String text
        * Returns: True when particular string exists, if not False
        */
        public static bool IsTextPresentOnPageSource(string text)
        {
            try
            {
                return Current.PageSource.Contains(text);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void ScrollIntoView(By locator)
        {
            IJavaScriptExecutor? JsDriver = Current as IJavaScriptExecutor;
            try
            {
                JsDriver.ExecuteScript("arguments[0].scrollIntoView(true);window.scrollBy(0," + (-200) + ");", Driver.FindElement(locator));
                Console.WriteLine("ScrollIntoView element::" + Driver.FindElement(locator));
            }
            catch (Exception e)
            {
                //_autoutilities.getScreenshot(Driver);
                Console.WriteLine("Exception occured when pressing escape on element:  Exception is " + e.Message + e.StackTrace);
            }
        }

        public static void PressEnter()
        {
            try
            {
                Actions actionBuilder = new Actions(Current);
                actionBuilder.SendKeys(Keys.Enter).Build().Perform();
            }
            catch (Exception e)
            {
                //_autoutilities.getScreenshot(Driver);
                Console.WriteLine("Exception occured when pressing escape on element:  Exception is " + e.Message + e.StackTrace);
            }
        }

        //public static Element WaitUntilElementIsDisplayed(By by)
        //{
        //    var wait = new WebDriverWait(Current, TimeSpan.FromSeconds(Convert.ToInt32(TestContext.Parameters["waitSecond"])));
        //    IWebElement webelement = wait.Until(ExpectedConditions.ElementToBeClickable(by));
        //    return new Element(webelement, "")
        //    {
        //        FoundBy = by
        //    };
        //}

        /// <summary>
        /// Drags an element from it's current position to the location of another element.
        /// </summary>
        /// <param name="dragElement">Drag element.</param>
        /// <param name="dropOnElement">Drop element.</param>
        public static void DragAndDrop(Element dragElement, Element dropOnElement)
        {
            var actions = new Actions(Current);
            actions.DragAndDrop(dragElement.Current, dropOnElement.Current);
            actions.Build().Perform();
        }

        public static void Refresh()
        {
            Current.Navigate().Refresh();
        }

        /// <summary>
        /// Selects the dropdown option. This only works for 'select' elements.
        /// </summary>
        /// <param name="by">Select option by: INDEX | TEXT | VALUE.</param>
        /// <param name="element">The Select element.</param>
        /// <param name="value">Value to select the option.</param>
        public static void SelectDropdownOption(DropdownBy by, Element element, dynamic value)
        {
            var dropdown = new SelectElement(element.Current);

            switch (by)
            {
                case DropdownBy.INDEX:
                    dropdown.SelectByIndex((int)value);
                    break;
                case DropdownBy.TEXT:
                    dropdown.SelectByText((string)value);
                    break;
                case DropdownBy.VALUE:
                    dropdown.SelectByValue((string)value);
                    break;
            }
        }

        private static void SetImplicitWait(this IWebDriver driver, int seconds)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
            }
            catch (UnhandledAlertException e)
            {
                Log.Information("Alert displayed is " + e.AlertText);
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                Log.Error("unable to set implicit wait due to " + e.Message);
            }
        }

        private static IWebElement WaitUntilElementExists(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Current, TimeSpan.FromSeconds(Convert.ToInt32(TestContext.Parameters["waitSecond"])));
                IWebElement element = wait.Until(ExpectedConditions.ElementExists((locator)));
                return element;
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }

        public static string TakeScreenShot(string imageName)
        {
            var ss = ((ITakesScreenshot)Current).GetScreenshot();
            var ssFileName = Path.Combine(FW.CurrentTestDirectory.FullName, imageName);
            string screenShotLocation = $"{ssFileName}.png";
            ss.SaveAsFile(screenShotLocation, ScreenshotImageFormat.Png);
            return screenShotLocation;
        }

        public static void Quit()
        {
            Log.Information("Close Browser");
            Current.Quit();
        }

        public enum DropdownBy
        {
            INDEX = 0,
            TEXT = 1,
            VALUE = 2
        }

    }
}
