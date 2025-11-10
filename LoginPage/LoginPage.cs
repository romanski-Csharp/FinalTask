using OpenQA.Selenium;

namespace POMs
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) 
        { 

        }
        
        private IWebElement Username => _driver.FindElement(By.CssSelector("#user-name"));
        private IWebElement Password => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement LoginBtn => _driver.FindElement(By.CssSelector(".submit-button.btn_action"));
        private IWebElement Error => _driver.FindElement(By.CssSelector("[data-test='error']"));
        private IWebElement Title => _driver.FindElement(By.CssSelector(".app_logo"));

        public void Open() => _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        public void Login(string username, string password)
        {
            Username.Clear();
            Username.SendKeys(username);
            Password.Clear();
            Password.SendKeys(password);
            LoginBtn.Click();
        }

        public string GetErrorText() => Error.Text;

        public string[] GetCredentials()
        {
            var credentialDiv = _driver.FindElement(By.CssSelector("[data-test='login-credentials']"));
            return credentialDiv.Text.Split("\n").Skip(1).ToArray();
        }

        public string GetUniversalPassword()
        {
            var passwordDiv = _driver.FindElement(By.CssSelector("[data-test='login-password']"));
            return passwordDiv.Text.Split('\n').Last();
        }

        public string AppLogoTxt() => Title.Text;
    }
}
