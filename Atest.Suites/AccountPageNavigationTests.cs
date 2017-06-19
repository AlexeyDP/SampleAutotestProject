using Atest.Pages;
using Atest.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Atest.Pages.Data;

namespace Atest.Suites
{
    [TestFixture]
    public class AccountPageNavigationTests
    {
        private IWebDriver _driver;
        private AccountPage _accPage;
        private UserData defaultCredentials = new UserData(ConfigurationManager.AppSettings["defaultUserName"].ToString(), ConfigurationManager.AppSettings["defaultUserPass"].ToString());


        #region SetUp and TearDown
        [SetUp]
        public void StartTests()
        {
            IBrowser browser = new Browser();
            _driver = browser.GetChromeDriver();
           _accPage = new LoginPage(_driver).LoginAs(defaultCredentials);           
        }

        [TearDown]
        public void EndTests()
        {
            _driver.Quit();
        }
        #endregion SetUp and TearDown

        [Test, Description("does not check anything, only for make sure method with LINQ  works")]
        public void ClickMenuItemTest()
        {
            _accPage.ClickProfileTab("My Profile");
        }
    }
}
