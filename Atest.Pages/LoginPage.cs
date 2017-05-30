using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Atest.Pages
{
    class LoginPage : BasePage
    {
        [FindsBy(How = How.Name, Using = "username")]
        protected IWebElement userEmail;

        [FindsBy(How = How.Name, Using = "password")]
        protected IWebElement userPassword;

        [FindsBy(How = How.Id, Using = "remember-me")]
        protected IWebElement rememberMeCheckBox;

        [FindsBy(How = How.CssSelector, Using = "#loginfrm > div.wow.fadeIn.animated > button")]
        protected IWebElement loginButton;

        private readonly string PageUrl = "http:////www.phptravels.net//login";
        private readonly string PageTitle = "Login";
        
        public LoginPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public AccountPage LoginAs(string email, string password, bool remember = false)
        {
            userEmail.SendKeys(email);
            userPassword.SendKeys(password);
            if (remember) { rememberMeCheckBox.Click(); }
            loginButton.Click();

            return new AccountPage();
           
        }
        
        
    }
}
