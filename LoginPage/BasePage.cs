using OpenQA.Selenium;

namespace POMs
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;
        protected const string BaseUrl = "https://www.saucedemo.com/";
        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
