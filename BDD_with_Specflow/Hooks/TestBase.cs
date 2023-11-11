using BoDi;
using Framework.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_with_Specflow.Hooks
{
    [Binding]
    public class TestBase : Hook
    {
        private static Process cmd;

        public TestBase(IObjectContainer container) : base(container)
        {
        }

        [BeforeFeature("BookStoreApp")]
        public static void Before_BookStoreApp()
        {
            cmd = new Process();
            cmd.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("cd " + FolderUtils.WORKSPACE_DIRECTORY + "_BookStore");
            cmd.StandardInput.WriteLine("dotnet run");
        }

        [AfterFeature("BookStoreApp")]
        public static void After_BookStoreApp()
        {
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            //Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }
    }
}
