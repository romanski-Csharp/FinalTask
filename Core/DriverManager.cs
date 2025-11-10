using OpenQA.Selenium;

namespace Core
{
    public class DriverManager
    {
        private static ThreadLocal<IWebDriver> _driver = new();
        public static IWebDriver GetDriver(BrowserType browser)
        {
            if(_driver.Value == null)
            {
                _driver.Value = DriverFactory.CreateDriver(browser);
                _driver.Value.Manage().Window.Maximize();
                _driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            return _driver.Value;
        }
        
        public static void Quit()
        {
            _driver.Value?.Quit();
            _driver.Value = null;
        }
    }
}
