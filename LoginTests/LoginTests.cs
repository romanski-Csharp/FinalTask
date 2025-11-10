using Core;
using Core.Logs;
using FluentAssertions;
using OpenQA.Selenium;
using POMs;

namespace SauceDemoTests
{
    public class LoginTests
    {
        [Theory]
        [MemberData(nameof(TestData.Browsers), MemberType = typeof(TestData))]
        public void Login_EmptyCredentials(BrowserType browser)
        {
            IWebDriver driver = null;
            try
            {
                Logger.Info($"[UC1] Starting test on {browser}");
                driver = DriverManager.GetDriver(browser);
                var loginPage = new LoginPage(driver);
                loginPage.Open();
                loginPage.Login(string.Empty, string.Empty);
                Logger.Info("Validating error message for empty credentials...");
                loginPage.GetErrorText().Should().Be("Epic sadface: Username is required");
            }
            finally
            {
                DriverManager.Quit();
            }
        }

        [Theory]
        [MemberData(nameof(TestData.Browsers), MemberType = typeof(TestData))]
        public void Login_EmptyPassword(BrowserType browser)
        {
            IWebDriver driver = null;
            try
            {
                Logger.Info($"[UC2] Starting test on {browser}");
                driver = DriverManager.GetDriver(browser);
                var loginPage = new LoginPage(driver);
                loginPage.Open();
                loginPage.Login("any_user", string.Empty);
                Logger.Info("Validating error message for empty password...");
                loginPage.GetErrorText().Should().Be("Epic sadface: Password is required");
            }
            finally
            {
                DriverManager.Quit();
            }
        }

        [Theory]
        [MemberData(nameof(TestData.ValidCredentials), MemberType = typeof(TestData))]
        public void Login_RightCredentials(string username, string password, bool shouldLogin)
        {
            IWebDriver driver = null;
            try
            {
                Logger.Info($"[UC3] Login test for user: {username}");
                driver = DriverManager.GetDriver(BrowserType.Edge);
                var loginPage = new LoginPage(driver);
                loginPage.Open();
                loginPage.Login(username, password);
                if (shouldLogin)
                {
                    Logger.Info($"Validating successful login for {username}");
                    loginPage.AppLogoTxt().Should().Be("Swag Labs");
                    Logger.Info("Then user should be redirected to dashboard.");
                }
                else
                {
                    Logger.Info($"Validating login failure for {username}");
                    loginPage.GetErrorText().Should().Be("Epic sadface: Sorry, this user has been locked out.");
                    Logger.Info("Then user should see an error about being locked out.");
                }
            }
            finally
            {
                DriverManager.Quit();
            }
        }
    }
}