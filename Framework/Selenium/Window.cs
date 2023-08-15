using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Selenium
{
    public class Window
    {
        public ReadOnlyCollection<string> CurrentWindows => Driver.Current.WindowHandles;

        public void SwitchTo(int windowIndex)
        {
            Driver.Current.SwitchTo().Window(CurrentWindows[windowIndex]);
        }

        public Size ScreenSize
        {
            get
            {
                var js = "return [window.screen.availWidth, window.screen.availHeight];";
                var jse = (IJavaScriptExecutor)Driver.Current;

                dynamic dimensions = jse.ExecuteScript(js, null);
                var x = Convert.ToInt32(dimensions[0]);
                var y = Convert.ToInt32(dimensions[1]);

                return new Size(x, y);
            }
        }

        public void Maximize()
        {
            Driver.Current.Manage().Window.Position = new Point(0, 0);
            Driver.Current.Manage().Window.Size = ScreenSize;
        }
    }
}
