using OpenQA.Selenium;
using Core.Logs;

namespace POMs
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) 
        { 
        }
        
        private IWebElement Username => _driver.FindElement(By.CssSelector("#user-name"));
        private IWebElement Password => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement LoginBtn => _driver.FindElement(By.CssSelector("[data-test='login-button']"));
        private IWebElement Error => _driver.FindElement(By.CssSelector("[data-test='error']"));
        private IWebElement Title => _driver.FindElement(By.CssSelector(".app_logo"));

        public void Open()
        {
            Logger.Info("Navigating to Login Page");
            _driver.Navigate().GoToUrl(BaseUrl);
        } 

        public void Login(string username, string password)
        {
            Username.Clear();
            Logger.Info($"Attempting to log in with username='{username}'");
            Username.SendKeys(username);
            Password.Clear();
            Password.SendKeys(password);
            Logger.Info("Clicking on Login button");
            LoginBtn.Click();
        }

        public string GetErrorText()
        {
            Logger.Info("Receiving error message");
            return Error.Text;
        }

        public string AppLogoTxt() => Title.Text;
    }
}
