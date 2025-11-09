using OpenQA.Selenium;
using POMs;

namespace SauceDemoTests
{
    public class LoginTests
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage loginPage;
        public LoginTests()
        {
            loginPage = new LoginPage(_driver);
            loginPage.Open();
        }
        [Fact]
        public void Test1()
        {

        }
    }
}