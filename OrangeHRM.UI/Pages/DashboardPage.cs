using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OrangeHRM.UI
{
    public class DashboardPage : Page
    {
        public DashboardPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        private const string UrlPart = "/client/#/dashboard";

        public MenuComponent MenuComponent => new MenuComponent(driver);

        public override bool IsVisible => driver.Url.Contains(UrlPart);
    }
}
