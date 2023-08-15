using Framework.Selenium;
using Framework.Utils;
using OpenQA.Selenium;

namespace Application.Pages.NaukriPages
{
    public class ProfilePage
    {
        ProfilePage_Map Map;
        public ProfilePage()
        {
            Map = new ProfilePage_Map();
        }

        //public ProfilePage ClickOnAttachCV()
        //{
        //    //Map.file_AttachCV.Click();
        //    //Thread.Sleep(5000);
        //    return this;
        //}

        //public ProfilePage EnterFileLocationAndOpen()
        //{
        //    Map.file_AttachCV.SendKeys(@"C:\Users\Mohamad.Khaja\Desktop\Learing\UI_Automation_Nunit\Resources\MohamadZabiulla_SDET_CSharp.pdf");
        //    return this;
        //}

        public string GetTheUploadedFileName()
        {
            return Map.attachedFile.Text;
        }

        public ProfilePage SendFileLocation()
        {
            Map.file_AttachCV.SendKeys(FolderUtils.GetResourceFolder()+ "MohamadZabiulla_SDET_CSharp.pdf");
            Thread.Sleep(10000);
            return this;
        }
    }

    sealed class ProfilePage_Map
    {
        public Element file_AttachCV => Driver.FindElement(By.Id("attachCV"));
        public Element attachedFile => Driver.FindElement(By.XPath("//div[@class='truncate exten']"));
    }
}