using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atest.Utils
{
    public interface IBrowser
    {
        IWebDriver GetFirefoxDriver();
        IWebDriver GetChromeDriver();
        IWebDriver GetIeDriver();
    }
}
