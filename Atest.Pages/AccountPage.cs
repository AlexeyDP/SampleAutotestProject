using NUnit.Framework;
using OpenQA.Selenium;
using static Atest.Utils.WaitHelper;

namespace Atest.Pages
{
    public class AccountPage
    {
        #region Private
        private readonly string PageUrl = "http:////www.phptravels.net//account//";       
        private IWebDriver _driver;
        private string _expectedPageTitle = "My Account";
        #endregion Private

        #region Properties
        public string Title{ get { return _driver.Title; }}
        public string ExpectedTitle { get { return _expectedPageTitle; } }
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