using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atest.Utils
{

    public enum Browsers
    {
        [Description("Internet Explorer")]
        IE,

        [Description("Mozilla Firefox")]
        FF,

        [Description("Google Chrome")]
        GH
    }
    public static class Browser
    {
       

        #region Private
        private static IWebDriver _webDriver;
        private static IWebDriver WebDriver
        {
            get { return _webDriver ?? StartWebDriver(); }
        }

        private static IWebDriver StartWebDriver()
        {
            if (_webDriver != null) return _webDriver;

            switch (SelectedBrowser)
            {
                case Browsers.FF:
                    _webDriver = StartFireFox();
                    break;
                case Browsers.GH:
                    _webDriver = StartChrome();
                    break;
                default:
                    throw new Exception($"Unknown browser {SelectedBrowser} selected");
            }

            _webDriver.Manage().Window.Maximize();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            return WebDriver;
        }

        private static ChromeDriver StartChrome()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddArgument("--disable-extensions");

            return new ChromeDriver(options);
        }

        private static FirefoxDriver StartFireFox()
        {
            FirefoxProfile ffp = new FirefoxProfile();
            ffp.AcceptUntrustedCertificates = true;
            ffp.EnableNativeEvents = false;
            ffp.SetPreference("browser.download.defaultFolder", 2);
            ffp.SetPreference("browser.download.manager.closeWhenDone", true);
            ffp.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/x-zip-compressed;application/xml;text/xml;text/comma-separated-values;text/csv;application/csv;application/excel;application/vnd.ms-excel;application/vnd.msexcel;text/anytext;");

            return new FirefoxDriver(ffp);
        }

        #endregion Private

        #region Public
        public static Browsers SelectedBrowser
        {
            get { return Browsers.GH; }
        }
        public static void Start()
        {
            _webDriver = StartWebDriver();
        }

        public static void Quit()
        {
            if (_webDriver == null) return;
            _webDriver.Quit();
            _webDriver = null;
        }
        #endregion Public






    }

}
