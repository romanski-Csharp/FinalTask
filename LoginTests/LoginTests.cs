using OpenQA.Selenium;
using POMs;
using Core;

namespace SauceDemoTests
{
    [Collection("ParallelTests")]
    public class LoginTests
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage loginPage;

        [Fact]
        public void Login_EmptyCredentials()
        {
            var driver = DriverManager.GetDriver(BrowserType.Edge);
            var loginPage = new LoginPage(driver);
            loginPage.Open();
            loginPage.Login(string.Empty, string.Empty);
            Assert.Equal("Epic sadface: Username is required", loginPage.GetErrorText());
            DriverManager.Quit();
        }

        [Fact]
        public void Login_EmptyPassword()
        {
            var driver = DriverManager.GetDriver(BrowserType.Edge);
            var loginPage = new LoginPage(driver);
            loginPage.Open();
            loginPage.Login("any credentials", string.Empty);
            Assert.Equal("Epic sadface: Password is required", loginPage.GetErrorText());
            DriverManager.Quit();
        }

        [Theory]
        [MemberData(nameof(TestData.GetValidCredentials), MemberType = typeof(TestData))]
        public void Login_RightCredentials(string username, string password)
        {
            var driver = DriverManager.GetDriver(BrowserType.FireFox);
            var loginPage = new LoginPage(driver);
            loginPage.Open();
            loginPage.Login(username, password);

            Assert.Equal("Swag Labs", loginPage.AppLogoTxt());
        }
    }
}