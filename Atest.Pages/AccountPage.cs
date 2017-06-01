using OpenQA.Selenium;

namespace Atest.Pages
{
    public class AccountPage
    {
        #region Private
        private readonly string PageUrl = "http:////www.phptravels.net//account//";
        private string PageTitle = "My Account";
        private IWebDriver _driver;
        #endregion Private

        #region Properties
        public string Title
        {
            get { return PageTitle; }
        }
        #endregion Properties

        #region Constructors
        public AccountPage(IWebDriver driver)
        {
            _driver = driver;
        }
        #endregion Constructors

        #region Elements
        #endregion Elements
    }
}