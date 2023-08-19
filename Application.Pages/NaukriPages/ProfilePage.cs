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

        public string GetTheUploadedFileName()
        {
            return Map.attachedFile.Text;
        }

        public ProfilePage UploadNewFileAs(string fileName)
        {
            Map.file_AttachCV.SendKeys(FolderUtils.GetResourceFolder()+ fileName);
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