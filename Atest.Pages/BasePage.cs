using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Atest.Utils.Browser;

namespace Atest.Pages
{
    
    public abstract class BasePage
    {
        private readonly string PageUrl;
        private readonly string PageTitle;
        public void Open()
        {
            Navigate(PageUrl);
        }

        public bool IsOpened()
        {
            return PageTitle.Equals(WebDriver.Title);
        }
    }
}
