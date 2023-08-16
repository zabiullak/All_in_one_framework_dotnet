using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Utils
{
    public static class FolderUtils
    {
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../../");

        public static string GetResourceFolder()
        {
            return WORKSPACE_DIRECTORY + "Resources/";
        }

        public static string GetTestResultFolder()
        {
            return WORKSPACE_DIRECTORY + "TestResults/";
        }
    }
}
