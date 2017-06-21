using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using static Atest.Utils.WaitHelper;

namespace Atest.Pages
{  
    public class AccountPage
    {
        #region Fields
        private readonly string PageUrl = "http:////www.phptravels.net//account//";               
        private string _expectedPageTitle = "My Account";
        protected IWebDriver driver;
        private By ProfileNavBar = By.CssSelector("div > div.col-md-1.offset-0 > ul");
        private By NavBarTabs = By.XPath("//ul[@class='nav profile-tabs']//a");
        #endregion Fields

        #region Properties
        public string Title{ get { return driver.Title; }}
        public string ExpectedTitle { get { return _expectedPageTitle; } }
        #endregion Properties

        #region Constructors
        public AccountPage(IWebDriver driver)
        {
            this.driver = driver;                       
        }
        #endregion Constructors

        #region Elements
        public IEnumerable<IWebElement> ProfileNavbarTabs
        {
            get
            {
                driver.WaitForVisible(ProfileNavBar);
                return driver.FindElements(NavBarTabs);
            }
        }

        #endregion Elements

        #region Private
        private void ClickProfileTab(string tabName)
        {
            var foundTabs = from tab in ProfileNavbarTabs
                              where tab.Text.Equals(tabName)
                              select tab;

            if (!foundTabs.Any()) throw new NoSuchElementException($"Tab with the name {tabName} is not found");

            foundTabs.Single().Click();           
            driver.WaitAjax();            
        }
        #endregion Private

        #region Public
        public WishList GotoWishList()
        {
            ClickProfileTab("Wishlist");
            return new WishList(driver);
        }

        #endregion Public
    }
}