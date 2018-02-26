using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedTester.BrowserMob;
using AutomatedTester.BrowserMob.HAR;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Atest.Utils
{
    public class ProxyBrowser : IBrowser
    {
        private IWebDriver _driver;
        private Server _server;
        private Client _client;
        private Proxy _seleniumProxy;
        private int _port;
        private string _proxyPath;

        #region constructors
        public ProxyBrowser()
        {
            //specify path to your proxy server
            _proxyPath = @"D:\Automation\Libs\browsermob-proxy-2.0-beta-6-bin\browsermob-proxy-2.0-beta-6\bin\browsermob-proxy.bat";
            _port = 9090;
        }

        public ProxyBrowser(string proxyPath, int proxyPort)
        {
            _proxyPath = proxyPath;
            _port = proxyPort;
        }
        #endregion constructors

        #region Private
        private void StartProxy()
        {
            _server = new Server(_proxyPath, _port);
            _server.Start();

            _client = _server.CreateProxy();
            _client.NewHar();

            _seleniumProxy = new Proxy { HttpProxy = _client.SeleniumProxy };

        }
        #endregion Private


        public IWebDriver GetChromeDriver()
        {
            StartProxy();

            var options = new ChromeOptions();
            options.Proxy = _seleniumProxy;
            string _driverPath = $"{AppDomain.CurrentDomain.BaseDirectory}Resources\\";

            _driver = new ChromeDriver(_driverPath, options);

            return _driver;
        }

        public IWebDriver GetFirefoxDriver()
        {
            throw new NotImplementedException();
        }

        public IWebDriver GetIeDriver()
        {
            throw new NotImplementedException();
        }

        public Entry[] GetHar()
        {
            HarResult harData = _client.GetHar();

            return harData.Log.Entries;
        }

        public void DriverClose()
        {
            _driver.Quit();
            _server.Stop();
        }
    }
}
