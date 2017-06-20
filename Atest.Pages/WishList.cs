using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Atest.Utils.WaitHelper;

namespace Atest.Pages
{
    public class WishList : AccountPage
    {
        #region Constructors
        public WishList(IWebDriver driver) : base(driver) { }
        #endregion Constructors

        #region Elements
        private IEnumerable<IWebElement> WishListElements
        {
            get
            {
                WaitForVisible(driver, By.Id("wishlist"));
                return driver.FindElements(By.XPath("//div[contains(@id,'wish') and @id!='wishlist']"));
            }
        }       
        #endregion Elements

        public bool IsHotelInWishList(string hotelName)
        {
            var searchedHotelName = WishListElements.Where(e => e.FindElement(By.XPath(".//a[@class='dark']")).Text == hotelName);
            return searchedHotelName.Any();
        }
    }
}
