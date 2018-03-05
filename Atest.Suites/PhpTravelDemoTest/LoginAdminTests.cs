using Atest.Pages;
using Atest.Pages.Data;
using Atest.Suites.TestCaseSources;
using Atest.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Atest.Suites.PhpTravelDemoTest
{
    [TestFixture]
    public class LoginAdminTests
    {
        #region Fields
        private IBrowser _browser;
        private IWebDriver _driver;
        private LoginPage _loginPage;
        #endregion Fields

        #region SetUp and TearDown
        [SetUp]
        public void StartTests()
        {
            _browser = new Browser();
            _driver = _browser.GetChromeDriver();
            _loginPage = new LoginPage(_driver);            
        }

        [TearDown]
        public void EndTests()
        {
            _browser.DriverClose();
        }
        #endregion SetUp and TearDown

        
        [Test, TestCaseSource(typeof(UserLoginData), "PositiveLogins")]
        public void PositiveLoginTest(string login, string password)
        {
            AccountPage accPage = _loginPage.LoginAs(new UserData(login, password));
            Assert.AreEqual(accPage.ExpectedTitle, accPage.Title);      
        }

        [Test, TestCaseSource(typeof(UserLoginData), "NegativeLogins")]
        public string NegativeLoginTest(string login, string password)
        {
            _loginPage.LoginAs(new UserData(login, password));
            return _loginPage.invalidLoginAlertText;
        }

    }
}
