using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Core.Factory
{
    public class FirefoxDriverFactory : IDriverFactory
    {
        public IWebDriver CreateDriver() => new FirefoxDriver();
    }
}
