using OpenQA.Selenium;

namespace Core.Factory
{
    public interface IDriverFactory
    {
        IWebDriver CreateDriver();
    }
}
