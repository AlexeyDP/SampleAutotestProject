using Atest.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atest.Suites.ParallelTests
{
    [TestFixture]
    [Parallelizable]
    public class ParallelizableDemoTest
    {
        private IBrowser _browser;
        private IWebDriver _wd;

        [SetUp]
        public void SetUp()
        {
            _browser = new RemoteBrowser();
            _wd = _browser.GetChromeDriver();
        }
        [TearDown]
        public void TearDown()
        {
            //_wd.Quit();
        }

        [Test]
        public void OpenGoogleSearchWebDriver()
        {
            _wd.Url = "https://www.google.com/";

            IWebElement element =  _wd.FindElement(By.Name("q"));
            element.SendKeys("webdriver");
            element.Submit();
            Assert.AreEqual("webdriver - Поиск в Google", _wd.Title);
        }

    }

    [TestFixture]
    [Parallelizable]
    public class ParallelizableDemoTest2
    {
        private IBrowser _browser;
        private IWebDriver _wd;

        [SetUp]
        public void SetUp()
        {
            _browser = new RemoteBrowser();
            _wd = _browser.GetChromeDriver();
        }
        [TearDown]
        public void TearDown()
        {
           // _wd.Quit();
        }

        

        [Test]
        public void OpenGoogleSearchSelenium()
        {
            _wd.Url = "https://www.google.com/";

            IWebElement element = _wd.FindElement(By.Name("q"));
            element.SendKeys("selenium");
            element.Submit();
            Assert.AreEqual("selenium - Пошук Google", _wd.Title);
        }

    }
}
