using Core;
using Core.Logs;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using POMs;

namespace SauceDemoTests
{
    public class LoginTests
    {

        [Theory]
        [MemberData(nameof(TestData.Browsers), MemberType = typeof(TestData))]
        public void Login_EmptyCredentials(BrowserType browser)
        {
            Logger.Info($"[UC1] Starting test on {browser}");
            var driver = DriverManager.GetDriver(browser);
            var loginPage = new LoginPage(driver);
            loginPage.Open();
            loginPage.Login(string.Empty, string.Empty);
            Logger.Info("Validating error message for empty credentials...");
            Assert.Equal("Epic sadface: Username is required", loginPage.GetErrorText());
            DriverManager.Quit();
        }

        [Theory]
        [MemberData(nameof(TestData.Browsers), MemberType = typeof(TestData))]
        public void Login_EmptyPassword(BrowserType browser)
        {
            Logger.Info($"[UC2] Starting test on {browser}");
            var driver = DriverManager.GetDriver(browser);
            var loginPage = new LoginPage(driver);
            loginPage.Open();
            loginPage.Login("any_user", string.Empty);
            Logger.Info("Validating error message for empty password...");
            Assert.Equal("Epic sadface: Password is required", loginPage.GetErrorText());
            DriverManager.Quit();
        }

        [Theory]
        [MemberData(nameof(TestData.ValidCredentials), MemberType = typeof(TestData))]
        public void Login_RightCredentials(string username, string password, bool shouldLogin)
        {
            Logger.Info($"[UC3] Login test for user: {username}");
            var driver = DriverManager.GetDriver(BrowserType.Edge); //Edge much faster FireFox, better for big TestCases, like here.
            var loginPage = new LoginPage(driver);
            loginPage.Open();
            loginPage.Login(username, password);
            if (shouldLogin)
            {
                Logger.Info($"Validating successful login for {username}");
                Assert.Equal("Swag Labs", loginPage.AppLogoTxt());
                Logger.Info("Then user should be redirected to dashboard.");
            }
            else
            {
                Logger.Info($"Validating login failure for {username}");
                Assert.Equal("Epic sadface: Sorry, this user has been locked out.", loginPage.GetErrorText());
                Logger.Info("Then user should see an error about being locked out.");
            }
            DriverManager.Quit();
        }
    }
}