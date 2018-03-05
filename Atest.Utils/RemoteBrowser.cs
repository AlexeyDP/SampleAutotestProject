using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Atest.Utils
{
    public class RemoteBrowser : IBrowser
    {
        private IWebDriver _webdriver;
        private WebDriverWait _wait;

        public void DriverClose()
        {
            throw new NotImplementedException();
        }

        public IWebDriver GetChromeDriver()
        {
            ChromeOptions _options = new ChromeOptions();
            _webdriver = new RemoteWebDriver(new Uri("http://172.31.134.70:4444/wd/hub"), _options.ToCapabilities());
            _webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _webdriver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(5));

            return _webdriver;
        }

        public IWebDriver GetFirefoxDriver()
        {
            throw new NotImplementedException();
        }

        public IWebDriver GetIeDriver()
        {
            throw new NotImplementedException();
        }
    }
}
