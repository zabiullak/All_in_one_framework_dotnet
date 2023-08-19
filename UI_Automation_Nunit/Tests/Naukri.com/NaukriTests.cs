using Application.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Automation_Nunit.Base;

namespace UI_Automation_Nunit.Tests.Naukri.com
{
    [TestFixture]
    internal class NaukriTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void LoginNaukriDotCom()
        {
            string title = Pages.NavigateToNaukri().LoginWithValidCreds().GetTheTitleOfThePage();

            Assert.That(title, Is.EqualTo("Home | Mynaukri"), "User not landed on Home Page");
        }

        [Test]
        [Parallelizable]
        public void UploadUpdatedResume()
        {
            LoginNaukriDotCom();
            string fileName = Pages.HomePage.ClickOnViewProfile().UploadNewFileAs("MohamadZabiulla_SDET_CSharp.pdf").GetTheUploadedFileName();

            Assert.That(fileName, Is.EqualTo("MohamadZabiulla_SDET_CSharp.pdf"), "File was not updated successfully");
        }
    }
}
