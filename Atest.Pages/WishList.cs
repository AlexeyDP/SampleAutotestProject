using Atest.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;


namespace Atest.Pages
{
    public class WishList : AccountPage
    {
        #region Fields
        private By _wishList = By.Id("wishlist");
        private By _wishListItems = By.XPath("//div[contains(@id,'wish') and @id!='wishlist']");
        private By _listItemName = By.XPath(".//a[@class='dark']");
        #endregion Fields

        #region Constructors
        public WishList(IWebDriver driver) : base(driver) { }
        #endregion Constructors

        #region Elements
        private IEnumerable<IWebElement> WishListElements
        {
            get
            {
                driver.WaitForVisible(_wishList);
                return driver.FindElements(_wishListItems);
            }
        }       
        #endregion Elements

        public bool IsHotelInWishList(string hotelName)
        {
            var searchedHotelName = WishListElements.Where(e => e.FindElement(_listItemName).Text == hotelName);
            return searchedHotelName.Any();
        }
    }
}
