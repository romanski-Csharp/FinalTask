using Core;
using POMs;

namespace SauceDemoTests
{
    public static class TestData
    {
        private const string password = "secret_sauce"; 
        public static IEnumerable<object[]> Browsers =>
            new List<object[]>
            {
                new object[] { BrowserType.Edge },
                new object[] { BrowserType.FireFox }
            };
        public static IEnumerable<object[]> ValidCredentials =>
            new List<object[]>
            {
                new object[]{ "standard_user", password, true},
                new object[]{ "locked_out_user", password, false},
                new object[]{ "problem_user", password, true},
                new object[]{ "performance_glitch_user", password, true},
                new object[]{ "error_user", password, true},
                new object[]{ "visual_user", password, true}
            };
        
    }
}
