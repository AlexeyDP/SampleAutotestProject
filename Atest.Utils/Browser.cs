using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Atest.Utils
{
    public class Browser : IBrowser
    {
        private IWebDriver _webdriver;

        public IWebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            string chromeDriverPath = $"{AppDomain.CurrentDomain.BaseDirectory}Resources\\";
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddArgument("--disable-extensions");

            _webdriver = new ChromeDriver(chromeDriverPath, options);
            _webdriver.Manage().Window.Maximize();

            return _webdriver;
            
        }

        public IWebDriver GetFirefoxDriver()
        {
            FirefoxProfile ffp = new FirefoxProfile();
            ffp.AcceptUntrustedCertificates = true;
            ffp.EnableNativeEvents = false;
            ffp.SetPreference("browser.download.defaultFolder", 2);
            ffp.SetPreference("browser.download.manager.closeWhenDone", true);
            ffp.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/x-zip-compressed;application/xml;text/xml;text/comma-separated-values;text/csv;application/csv;application/excel;application/vnd.ms-excel;application/vnd.msexcel;text/anytext;");

            _webdriver = new FirefoxDriver(ffp);
            _webdriver.Manage().Window.Maximize();

            return _webdriver;
        }

        public IWebDriver GetIeDriver()
        {
            var internetExplorerOptions = new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                InitialBrowserUrl = "about:blank",
                EnableNativeEvents = true
            };

            _webdriver =  new InternetExplorerDriver(internetExplorerOptions);
            _webdriver.Manage().Window.Maximize();

            return _webdriver;
        }

        public void DriverClose()
        {
            _webdriver.Quit();
        }
    }
}
