using Core.Logs;
using OpenQA.Selenium;

namespace Core
{
    public static class DriverManager
    {
        private static ThreadLocal<IWebDriver> _driver = new();
        public static IWebDriver GetDriver(BrowserType browser)
        {
            Logger.Info($"[DriverManager] Initializing {browser} browser");
            if (_driver.Value == null)
            {
                _driver.Value = DriverFactory.CreateDriver(browser);
                _driver.Value.Manage().Window.Maximize();
                Logger.Info($"[DriverManager] {browser} launched and maximized");
                _driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            return _driver.Value;
        }

        public static void Quit()
        {
            try
            {
                Logger.Info("[DriverManager] Closing browser session...");
                _driver.Value?.Quit();
                _driver.Value = null;
                Logger.Info("[DriverManager] Browser closed successfully");
            }
            catch (Exception ex)
            {
                Logger.Error("Error closing driver", ex);
            }
        }
    }
}
