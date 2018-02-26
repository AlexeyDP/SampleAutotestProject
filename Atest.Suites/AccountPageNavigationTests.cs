using Atest.Pages;
using Atest.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using Atest.Pages.Data;

namespace Atest.Suites
{
    [TestFixture]
    public class AccountPageNavigationTests
    {
        #region Fields
        private IBrowser _browser;
        private IWebDriver _driver;
        private WishList _wishList;
        private UserData defaultCredentials = new UserData(ConfigurationManager.AppSettings["defaultUserName"].ToString(), ConfigurationManager.AppSettings["defaultUserPass"].ToString());        
        #endregion Fields

        #region SetUp and TearDown
        [OneTimeSetUp]
        public void StartTests()
        {
            _browser = new Browser();
            _driver = _browser.GetChromeDriver();
            _wishList = new LoginPage(_driver)
                            .LoginAs(defaultCredentials)
                            .GotoWishList();           
        }

        [OneTimeTearDown]
        public void EndTests()
        {
            _browser.DriverClose();
        }
        #endregion SetUp and TearDown

        [TestCase("Swissotel Le Plaza Basel")]
        [TestCase("Jumeirah Beach Hotel")]
        [TestCase("INVALID HOTEL Name")]//the test should be failed
        public void CheckHotelInWishListTest(string hotelName)
        {                        
            Assert.IsTrue(_wishList.IsHotelInWishList(hotelName), $"The hotel {hotelName} is not foud in wishlist");
        }
    }
}
