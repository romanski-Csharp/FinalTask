using Core.Factory;
using OpenQA.Selenium;

namespace Core
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(BrowserType browser)
        {
            IDriverFactory factory = browser switch
            {
                BrowserType.Edge => new EdgeDriverFactory(),
                BrowserType.FireFox => new FirefoxDriverFactory(),
                _ => throw new ArgumentException("Unsupported type of browser")
            };
            return factory.CreateDriver();
        }
    }
}
