using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OrangeHRM.UI
{
    public class ProxyPunchInPunchOutPage : Page
    {
        public ProxyPunchInPunchOutPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        private const string UrlPart = "/client/#/noncore/attendance/proxyPunchInPunchOut";

        [FindsBy(How = How.Id, Using = "attendance_time")]
        private IWebElement AttendanceTime { get; set; }

        [FindsBy(How = How.Id, Using = "btnPunchInTrigger")]
        private IWebElement In { get; set; }

        public override bool IsVisible => driver.Url.Contains(UrlPart);

        public void SetAttendanceTime(string time)
        {
            SwitchToFrame();
            AttendanceTime.Clear();
            AttendanceTime.SendKeys(time);
            SwitchToParent();
        }

        public void ClickIn()
        {
            SwitchToFrame();
            In.Click();
            SwitchToParent();
        }
    }
}
