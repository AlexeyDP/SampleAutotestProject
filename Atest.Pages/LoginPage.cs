using Atest.Pages.Data;
using NUnit.Framework;
using OpenQA.Selenium;
using Atest.Utils;

namespace Atest.Pages
{
    public class LoginPage 
    {
        #region Fields
        private readonly string PageUrl = "http:////www.phptravels.net//login";
        private string PageTitle = "Login";
        private IWebDriver _driver;
        private By _userEmail = By.Name("username");
        private By _userPassword = By.Name("password");
        private By _rememberCheckBox = By.CssSelector("#loginfrm > div.wow.fadeIn.animated > button");
        private By _loginButton = By.CssSelector("#loginfrm > div.wow.fadeIn.animated > button");
        private By _invalidLoginAlertText = By.XPath("//div[@class='alert alert-danger']");
        #endregion Fields

        #region Constructors
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl(PageUrl);
            _driver.WaitForPageLoad();
            Assert.AreEqual(PageTitle, _driver.Title);
        }
        #endregion Constructors

        #region Elements        
        public IWebElement userEmail { get { return _driver.WaitForClickable(_userEmail); } }
        public IWebElement userPassword { get { return _driver.WaitForClickable(_userPassword); } }
        public IWebElement rememberMeCheckBox { get { return _driver.WaitForClickable(_rememberCheckBox); } }
        public IWebElement loginButton { get { return _driver.WaitForClickable(_loginButton); } }
        public string invalidLoginAlertText { get { return _driver.WaitForVisible(_invalidLoginAlertText).Text; } }
        #endregion Elements

        public AccountPage LoginAs(UserData userCredentials, bool remember = false)
        {
            userEmail.SendKeys(userCredentials.userEmail);
            userPassword.SendKeys(userCredentials.userPass); 
            if (remember) { rememberMeCheckBox.Click(); }

            loginButton.Click();            
            _driver.WaitAjax();

            return new AccountPage(_driver);
           
        }
        
        
    }
}
