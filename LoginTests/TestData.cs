using Core;
using POMs;

namespace SauceDemoTests
{
    public static class TestData
    {
        public static IEnumerable<object[]> GetValidCredentials()
        {
            var driver = DriverManager.GetDriver(BrowserType.Edge);
            var loginPage = new LoginPage(driver);
            loginPage.Open();

            string[] users = loginPage.GetCredentials();
            string password = loginPage.GetUniversalPassword();

            foreach(string username in users)
            {
                yield return new object[] { username, password };
            }
            DriverManager.Quit();
        }
        
    }
}
