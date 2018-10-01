using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OrangeHRM.UI
{
    public class LoginPage : Page
    {
        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        private const string UrlPart = "/auth/login";

        [FindsBy(How = How.Id, Using = "txtUsername")]
        private IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "btnLogin")]
        private IWebElement Login { get; set; }

        public override bool IsVisible => driver.Url.Contains(UrlPart);

        public void SetUsername(string username)
        {
            Username.Clear();
            Username.SendKeys(username);
        }

        public void SetPassword(string password)
        {
            Password.Clear();
            Password.SendKeys(password);
        }

        public void ClickLogin()
        {
            Login.Click();
        }

        public void DoLogin(string username, string password)
        {
            SetUsername(username);
            SetPassword(password);
            ClickLogin();
        }
    }
}
