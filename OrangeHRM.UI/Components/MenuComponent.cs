using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace OrangeHRM.UI
{
    public class MenuComponent
    {
        private IWebDriver driver;

        internal MenuComponent(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.Id, Using = "menu-content")]
        private IWebElement Menu { get; set; }

        private IReadOnlyCollection<IWebElement> GetItems(IWebElement parent, int level)
        {
            Thread.Sleep(100);
            var items = parent.FindElements(By.ClassName($"level{level}"));
            return items;
        }

        public void OpenMenu(params string[] menuItemTexts)
        {
            int level = 1;
            IWebElement parent = Menu;
            foreach (var menuItemText in menuItemTexts)
            {
                parent = GetItems(parent, level).First(i => i.Text.Equals(menuItemText));
                parent.Click();
                level++;
            }
        }
    }
}
