using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OrangeHRM.UI
{
    public abstract class Page
    {
        protected IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "page-title")]
        protected IWebElement Title { get; set; }

        protected void SwitchToFrame()
        {
            driver.SwitchTo().Frame(0);
        }

        protected void SwitchToParent()
        {
            driver.SwitchTo().ParentFrame();
        }

        public abstract bool IsVisible { get; }
    }
}
