using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Atest.Utils
{
    public class Browser : IBrowser
    {
        public IWebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            string chromeDriverPath = @"d:\CustomProject\SampleAutotestProject\packages\Selenium.Chrome.WebDriver.2.29\driver\";
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddArgument("--disable-extensions");

            IWebDriver webdriver = new ChromeDriver(chromeDriverPath, options);
            webdriver.Manage().Window.Maximize();

            return webdriver;
            
        }

        public IWebDriver GetFirefoxDriver()
        {
            FirefoxProfile ffp = new FirefoxProfile();
            ffp.AcceptUntrustedCertificates = true;
            ffp.EnableNativeEvents = false;
            ffp.SetPreference("browser.download.defaultFolder", 2);
            ffp.SetPreference("browser.download.manager.closeWhenDone", true);
            ffp.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/x-zip-compressed;application/xml;text/xml;text/comma-separated-values;text/csv;application/csv;application/excel;application/vnd.ms-excel;application/vnd.msexcel;text/anytext;");

            return new FirefoxDriver(ffp);
        }

        public IWebDriver GetIeDriver()
        {
            var internetExplorerOptions = new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                InitialBrowserUrl = "about:blank",
                EnableNativeEvents = true
            };

            return new InternetExplorerDriver(internetExplorerOptions);
        }
    }
}
