using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.ComponentModel;

namespace Atest.Suites
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


    class BaseTest
    {
        #region Constructor
        public BaseTest()
        {
            _selectedBrowser = Browsers.GH;
        }
        public BaseTest(Browsers type)
        {
            _selectedBrowser = type;
        }
        #endregion Constructor
       
        #region Private
        private IWebDriver _webDriver;
        private Browsers _selectedBrowser;

        public IWebDriver WebDriver
        {
            get { return _webDriver; }
        }
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

        private IWebDriver StartWebDriver()
        {
            if (_webDriver == null)
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
                _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            return _webDriver;
        }

        #endregion Private
        
        #region Public

        public void StartDriver()
        {
            _webDriver = StartWebDriver();
        }

        public void QuitDriver()
        {
            _webDriver.Quit();
            _webDriver = null;
        }
        #endregion Public




    }
}
