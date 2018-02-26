using AutomatedTester.BrowserMob;
using AutomatedTester.BrowserMob.HAR;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atest.Suites
{
    [TestFixture]
    public class SeleniumProxyTest
    {
        /// <summary>
        /// path to browsermobproxy .bat or another proxy
        /// </summary>
        private string _proxyPath = @"D:\Automation\Libs\browsermob-proxy-2.0-beta-6-bin\browsermob-proxy-2.0-beta-6\bin\browsermob-proxy.bat";
        private IWebDriver _wd;
        private Server _server;
        private Client _client;

        [SetUp]
        public void SetUpProxy()
        {
            _server = new Server(_proxyPath, 5555);
            _server.Start();

            _client = _server.CreateProxy();
            _client.NewHar("google");

            var seleniumProxy = new Proxy { HttpProxy = _client.SeleniumProxy };

            ChromeOptions options = new ChromeOptions();
            options.Proxy = seleniumProxy;

            _wd = new ChromeDriver(options);
        }

        [TearDown]
        public void ShutDownProxy()
        {
            _wd.Quit();
            _server.Stop();
            
        }


        [Test]
        public void GetResponseDetails()
        {
            _wd.Navigate().GoToUrl("http://www.google.co.uk");
            HarResult harData = _client.GetHar();
            var data = harData.Log.Entries;

            data.ToList().ForEach(x => Console.WriteLine(x.Response.Status + " : " + x.Request.Url));
        }
    }
}
