using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace Atest.Suites.DevToolsTest
{
    [TestFixture]
    public class DevToolsSample
    {
        private string _driverPath = $"{AppDomain.CurrentDomain.BaseDirectory}Resources\\";
        [Test]
        public void Start()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddAdditionalCapability("useAutomationExtension", false);
            //options.AddArgument("--start-maximized");
            options.BinaryLocation = _driverPath;

            var _service = ChromeDriverService.CreateDefaultService(_driverPath);
            _service.EnableVerboseLogging = true;
            _service.Start();

            IWebDriver _drriver = new RemoteWebDriver(_service.ServiceUrl, options.ToCapabilities());

                 
        }
    }
}
