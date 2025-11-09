using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace POMs
{
    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver) : base(driver)
        {
        }
        private IWebElement Footer => _driver.FindElement(By.CssSelector(".footer"));
        public bool IsLogged() => Footer.Displayed;
    }
}
