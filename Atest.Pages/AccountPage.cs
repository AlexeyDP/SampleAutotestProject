using OpenQA.Selenium;

namespace Atest.Pages
{
    public class AccountPage
    {
        private readonly string PageUrl = "http:////www.phptravels.net//login";
        private string PageTitle = "Login";
        private IWebDriver _driver;

        public AccountPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}