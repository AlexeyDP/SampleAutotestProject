using Atest.Pages.Data;
using static Atest.Utils.WaitHelper;
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
        #endregion Fields

        #region Constructors
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl(PageUrl);
            WaitForPageLoad(_driver);
            Assert.AreEqual(PageTitle, _driver.Title);
        }
        #endregion Constructors

        #region Elements        
        public IWebElement userEmail { get { return WaitForClickable(_driver, By.Name("username")); } }
        public IWebElement userPassword { get { return WaitForClickable(_driver, By.Name("password")); } }
        public IWebElement rememberMeCheckBox { get { return WaitForClickable(_driver, By.CssSelector("#loginfrm > div.wow.fadeIn.animated > button")); } }
        public IWebElement loginButton { get { return WaitForClickable(_driver, By.CssSelector("#loginfrm > div.wow.fadeIn.animated > button")); } }
        public string invalidLoginAlertText { get { return WaitForVisible(_driver, By.XPath("//div[@class='alert alert-danger']")).Text; } }
        #endregion Elements

        public AccountPage LoginAs(UserData userCredentials, bool remember = false)
        {
            userEmail.SendKeys(userCredentials.userEmail);
            userPassword.SendKeys(userCredentials.userPass); 
            if (remember) { rememberMeCheckBox.Click(); }

            loginButton.Click();            
            WaitAjax(_driver);

            return new AccountPage(_driver);
           
        }
        
        
    }
}
