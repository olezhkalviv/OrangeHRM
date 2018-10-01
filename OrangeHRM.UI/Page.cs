using OpenQA.Selenium;

namespace OrangeHRM.UI
{
    public abstract class Page
    {
        protected IWebDriver driver;

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
