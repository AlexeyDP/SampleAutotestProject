using OpenQA.Selenium;

namespace Atest.Utils
{
    public interface IBrowser
    {
        IWebDriver GetFirefoxDriver();
        IWebDriver GetChromeDriver();
        IWebDriver GetIeDriver();
        void DriverClose();
    }
}
