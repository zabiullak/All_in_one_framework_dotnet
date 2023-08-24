using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Utils
{
    public static class Helper
    {
        public static string GetCurrentDate()
        {
            return DateTime.UtcNow.ToString("g").Replace(" ", "_").Replace("/", "_").Replace(":", "_");
        }
    }
}
