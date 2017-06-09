using Atest.Pages;
using Atest.Pages.Data;
using Atest.Suites.TestCaseSources;
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
       
        #region SetUp and TearDown
        [SetUp]
        public void StartTests()
        {
            IBrowser browser = new Browser();
            _driver = browser.GetChromeDriver();
            _loginPage = new LoginPage(_driver);            
        }

        [TearDown]
        public void EndTests()
        {
            _driver.Quit();
        }
        #endregion SetUp and TearDown

        [Test]
        public void OpenLogin()
        {
            Assert.AreEqual(_loginPage.Title, _driver.Title);
            
        }

        [Test, TestCaseSource(typeof(UserLoginData), "PositiveLogins")]
        public string PositiveLoginTest(string login, string password)
        {
            AccountPage accPage = _loginPage.LoginAs(new UserData(login, password));
            return accPage.Title;
        }

        [Test, TestCaseSource(typeof(UserLoginData), "NegativeLogins")]
        public string NegativeLoginTest(string login, string password)
        {
            _loginPage.LoginAs(new UserData(login, password));
            return _loginPage.invalidLoginAlertText;
        }


    }
}
