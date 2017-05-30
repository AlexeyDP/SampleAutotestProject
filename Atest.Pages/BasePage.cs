using OpenQA.Selenium;

namespace Atest.Pages
{

    public abstract class BasePage
    {
        private readonly string PageUrl;
        private readonly string PageTitle;
        private IWebDriver _drvier;

        public BasePage (IWebDriver webdriver)
        {
            _drvier = webdriver;
        }

        public void Open()
        {
            _drvier.Navigate().GoToUrl(PageUrl); 
        }

        public bool IsOpened()
        {
            return PageTitle.Equals(_drvier.Title);
        }
    }
}
