using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrangeHRM.UI;
using System.Linq;
using TechTalk.SpecFlow;

namespace OrangeHRM.Specs
{
    [Binding]
    public class EmployeeRecordsPunchInSteps
    {
        IWebDriver driver;

        [Given(@"I logged in to the '(.*)' hrm using '(.*)' / '(.*)' credentials")]
        public void GivenILoggedInToTheHrmUsingCredentials(string url, string username, string password)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            LoginPage loginPage = new LoginPage(driver);
            Assert.IsTrue(loginPage.IsVisible, "Login page is not visible");
            loginPage.DoLogin(username, password);
        }
        
        [Given(@"I navigated to View Attendance Record page")]
        public void GivenINavigatedToViewAttendanceRecordPage()
        {
            DashboardPage dashboardPage = new DashboardPage(driver);
            Assert.IsTrue(dashboardPage.IsVisible, "Dashboard page is not visible");
            dashboardPage.MenuComponent.OpenMenu("Time", "Attendance", "Employee Records");
        }
        
        [Given(@"I set '(.*)' as employee name")]
        public void GivenISetAsEmployeeName(string employeeName)
        {
            ViewAttendanceRecordPage viewAttendanceRecordPage = new ViewAttendanceRecordPage(driver);
            Assert.IsTrue(viewAttendanceRecordPage.IsVisible, "View Attendance Record page is not visible");
            viewAttendanceRecordPage.SetEmployeeName(employeeName);
        }
        
        [Given(@"I selected '(.*)' day")]
        public void GivenISelectedDay(int day)
        {
            ViewAttendanceRecordPage viewAttendanceRecordPage = new ViewAttendanceRecordPage(driver);
            Assert.IsTrue(viewAttendanceRecordPage.IsVisible, "View Attendance Record page is not visible");
            viewAttendanceRecordPage.SelectDay(day);
        }
        
        [Given(@"I clicked View button")]
        public void GivenIClickedViewButton()
        {
            ViewAttendanceRecordPage viewAttendanceRecordPage = new ViewAttendanceRecordPage(driver);
            Assert.IsTrue(viewAttendanceRecordPage.IsVisible, "View Attendance Record page is not visible");
            viewAttendanceRecordPage.ClickView(); ;
        }
        
        [Given(@"'(.*)' value is shown in Pinch In cell")]
        public void GivenValueIsShownInPinchInCell(string value)
        {
            ViewAttendanceRecordPage viewAttendanceRecordPage = new ViewAttendanceRecordPage(driver);
            Assert.IsTrue(viewAttendanceRecordPage.IsVisible, "View Attendance Record page is not visible");
            Assert.AreEqual(value, viewAttendanceRecordPage.TableRows.First().PunchInText);
        }
        
        [When(@"I click Add button")]
        public void WhenIClickAddButton()
        {
            ViewAttendanceRecordPage viewAttendanceRecordPage = new ViewAttendanceRecordPage(driver);
            Assert.IsTrue(viewAttendanceRecordPage.IsVisible, "View Attendance Record page is not visible");
            viewAttendanceRecordPage.ClickAdd();
        }
        
        [When(@"I set '(.*)' as attendance time")]
        public void WhenISetAsAttendanceTime(string attendanceTime)
        {
            ProxyPunchInPunchOutPage proxyPunchInPunchOutPage = new ProxyPunchInPunchOutPage(driver);
            Assert.IsTrue(proxyPunchInPunchOutPage.IsVisible, "Proxy Punch In Punch Out page is not visible");
            proxyPunchInPunchOutPage.SetAttendanceTime(attendanceTime);
        }
        
        [When(@"I click In button twice")]
        public void WhenIClickInButtonTwice()
        {
            ProxyPunchInPunchOutPage proxyPunchInPunchOutPage = new ProxyPunchInPunchOutPage(driver);
            Assert.IsTrue(proxyPunchInPunchOutPage.IsVisible, "Proxy Punch In Punch Out page is not visible");
            proxyPunchInPunchOutPage.ClickIn();
            proxyPunchInPunchOutPage.ClickIn();
        }
        
        [Then(@"'(.*)' value should be shown in Pinch In cell")]
        public void ThenValueShouldBeShownInPinchInCell(string value)
        {
            ViewAttendanceRecordPage viewAttendanceRecordPage = new ViewAttendanceRecordPage(driver);
            Assert.IsTrue(viewAttendanceRecordPage.IsVisible, "View Attendance Record page is not visible");
            Assert.AreEqual(value, viewAttendanceRecordPage.TableRows.First().PunchInTextWithSelection);
        }
    }
}
