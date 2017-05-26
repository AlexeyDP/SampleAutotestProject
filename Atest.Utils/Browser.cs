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
    public class Browser
    {
        #region Private
        private IWebDriver _webDriver;
        private Browsers _selectedBrowser;         
        private ChromeDriver StartChrome()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddArgument("--disable-extensions");

            return new ChromeDriver(options);
        }
        private FirefoxDriver StartFireFox()
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

        #region Constructors
        /// <summary>
        /// Temporary solution. Will be value from config in the future
        /// </summary>
        public Browser()
        {
            _selectedBrowser = Browsers.GH;
        }

        public Browser(Browsers browserType)
        {
            _selectedBrowser = browserType;
        }

        #endregion Constructors

        #region Public
        public void StartDriver()
        {
            switch (_selectedBrowser)
            {
                case Browsers.FF:
                    _webDriver = StartFireFox();
                    break;
                case Browsers.GH:
                    _webDriver = StartChrome();
                    break;
                default:
                    throw new Exception($"Unknown browser {_selectedBrowser} selected");
            }

            _webDriver.Manage().Window.Maximize();

        }

        public void CloseDriver()
        {
            if (_webDriver == null) return;
            _webDriver.Quit();
        }       
        #endregion Public

    }
}
