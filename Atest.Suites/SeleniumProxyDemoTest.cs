using Atest.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace Atest.Suites
{
    [TestFixture]
    public class SeleniumProxyDemoTest
    {
        private IBrowser _browser;
        private IWebDriver _wd;

        [SetUp]
        public void SetUpWithProxy()
        {
            _browser = new ProxyBrowser();
            _wd = _browser.GetChromeDriver();
        }

        [TearDown]
        public void TearDownProxySelenium()
        {
            _browser.DriverClose();
        }

        [Test]
        public void WriteHarDataToConsoleTest()
        {
            _wd.Navigate().GoToUrl("http://www.google.co.uk");

            var proxyBrowser = _browser as ProxyBrowser;
            proxyBrowser.GetHar().ToList().ForEach(x => Console.WriteLine(x.Response.Status + " : " + x.Request.Url + " " +  x.Timings.Wait));        
        }
    }
}
