using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<IWebElement> ProfileNavbarTabs
        {
            get
            {
                WaitForVisible(_driver, By.CssSelector("div > div.col-md-1.offset-0 > ul"));
                return _driver.FindElements(By.XPath("//ul[@class='nav profile-tabs']//a"));
            }
        }
        #endregion Elements

        public void ClickProfileTab(string tabName)
        {
            var foundTabs = from tab in ProfileNavbarTabs
                              where tab.Text.Equals(tabName)
                              select tab;

            if (!foundTabs.Any()) throw new NoSuchElementException($"Tab with the name {tabName} is not found");

            foundTabs.Single().Click();           
            WaitAjax(_driver);            
        }


    }
}