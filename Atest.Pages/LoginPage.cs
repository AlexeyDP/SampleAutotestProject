using Atest.Pages.Data;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Atest.Pages
{
    public class LoginPage 
    {
        #region Private
        private readonly string PageUrl = "http:////www.phptravels.net//login";
        private string PageTitle = "Login";
        private IWebDriver _driver;
        #endregion Private

        #region Constructors
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl(PageUrl);
            Assert.AreEqual(PageTitle, _driver.Title);
        }
        #endregion Constructors

        #region Properties
        public string Title
        {
            get { return PageTitle; }
        }
        #endregion Properties

        #region Elements
        public IWebElement userEmail{ get { return _driver.FindElement(By.Name("username")); }} 

        public IWebElement userPassword { get { return _driver.FindElement(By.Name("password")); } }

        public IWebElement rememberMeCheckBox { get { return _driver.FindElement(By.Id("remember-me")); } }

        public IWebElement loginButton { get { return _driver.FindElement(By.CssSelector("#loginfrm > div.wow.fadeIn.animated > button")); } }
        public string invalidLoginAlertText { get { return _driver.FindElement(By.ClassName("alert alert-danger")).Text; } }

        #endregion Elements
                 
        public AccountPage LoginAs(UserData userCredentials, bool remember = false)
        {
            userEmail.SendKeys(userCredentials.userEmail);
            userPassword.SendKeys(userCredentials.userPass);
            if (remember) { rememberMeCheckBox.Click(); }
            loginButton.Click();

            return new AccountPage(_driver);
           
        }
        
        
    }
}
