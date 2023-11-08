using Application.Pages.EbayPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pages.BookStorePages
{
    public static class Pages
    {
        [ThreadStatic] public static HomePage HomePage;

        public static void Init()
        {
            HomePage = new HomePage();
        }
    }


}
