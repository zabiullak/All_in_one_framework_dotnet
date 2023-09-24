using com.sun.tools.javac.util;
using javax.swing.text.html;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Automation_Selenium.Tests.XPathFunctions
{
    [TestFixture]
    public class XpathFuncTest
    {
        [Test]
        public void _position_()
        {
            By loc = By.XPath("//*[position()=3]"); //*[3]  - both are same
        }

        [Test]
        public void _count_()
        {
            By loc = By.XPath("(//tr[count(./th)=5 ])[position()=2]");
        }

        [Test]
        public void _normalize_space_()
        {
            //html code
            //<label>    who cares         about spaces   </ label >

            By loc = By.XPath("//label[normalize-space(text())='who cares about spaces']");
            By loc1 = By.XPath("//label[normalize-space(@id)='who cares about spaces']");
        }
    }
}
