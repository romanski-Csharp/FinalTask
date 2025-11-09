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
    }
}
