using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atest.Utils
{
    public static class WaitHelper
    {
        public static IWebElement WaitForClickable(IWebDriver webdriver, By elementSelector, int timeout = 3)
        {
            IWebElement elem;
            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(timeout));

            return elem = wait.Until(ExpectedConditions.ElementToBeClickable(elementSelector));

        }

        public static IWebElement WaitForVisible(IWebDriver webdriver, By elementSelector, int timeout = 3)
        {
            IWebElement elem;
            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(timeout));

            return elem = wait.Until(ExpectedConditions.ElementIsVisible(elementSelector));
        }
    }
}
