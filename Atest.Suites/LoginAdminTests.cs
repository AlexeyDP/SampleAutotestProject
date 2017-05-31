using Atest.Pages;
using Atest.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Atest.Suites
{
    [TestFixture]
    public class LoginAdminTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [OneTimeSetUp]
        public void StartTests()
        {
            IBrowser browser = new Browser();
            _driver = browser.GetChromeDriver();
            _loginPage = new LoginPage(_driver);
            PageFactory.InitElements(_driver, _loginPage);
        }

       [OneTimeTearDown]
       public void EndTests()
        {
            _driver.Quit();
        }

        [Test]
        public void OpenLogin()
        {
            Assert.AreEqual(_loginPage.Title, _driver.Title);
            
        }

             

    }
}
