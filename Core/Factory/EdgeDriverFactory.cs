using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Core.Factory
{
    public class EdgeDriverFactory : IDriverFactory
    {
        public IWebDriver CreateDriver() => new EdgeDriver();
    }
}
