using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace OrangeHRM.UI
{
    public class ViewAttendanceRecordPage : Page
    {
        public ViewAttendanceRecordPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        private const string UrlPart = "/client/#/noncore/attendance/viewAttendanceRecord";

        [FindsBy(How = How.Id, Using = "attendance_employeeName_empName")]
        private IWebElement EmployeeName { get; set; }

        [FindsBy(How = How.Id, Using = "attendance_date")]
        private IWebElement Date { get; set; }

        [FindsBy(How = How.Id, Using = "btView")]
        private IWebElement View { get; set; }

        [FindsBy(How = How.Id, Using = "resultTable")]
        private IWebElement ResultTable { get; set; }

        [FindsBy(How = How.Id, Using = "btnAdd")]
        private IWebElement Add { get; set; }

        private CalendarComponent CalendarComponent => new CalendarComponent(driver);

        public override bool IsVisible => driver.Url.Contains(UrlPart);

        public IEnumerable<ViewAttendanceRecordTableRowElement> TableRows
        {
            get
            {
                SwitchToFrame();
                List<ViewAttendanceRecordTableRowElement> rows = new List<ViewAttendanceRecordTableRowElement>();
                foreach (var row in ResultTable.FindElements(By.TagName("tr")).Skip(1))
                {
                    rows.Add(new ViewAttendanceRecordTableRowElement(driver, row));
                }
                SwitchToParent();
                return rows;
            }
        }

        public void SetEmployeeName(string employeeName)
        {
            SwitchToFrame();
            EmployeeName.Clear();
            EmployeeName.SendKeys(employeeName);
            SwitchToParent();
        }

        public void SelectDay(int day)
        {
            SwitchToFrame();
            Date.Click();
            CalendarComponent.SelectDay(day);
            SwitchToParent();
        }

        public void ClickView()
        {
            SwitchToFrame();
            View.Click();
            SwitchToParent();
        }

        public void ClickAdd()
        {
            SwitchToFrame();
            Add.Click();
            SwitchToParent();
        }
    }

    public class ViewAttendanceRecordTableRowElement
    {
        internal ViewAttendanceRecordTableRowElement(IWebDriver driver, IWebElement row)
        {
            this.driver = driver;
            this.row = row;
        }

        private const int PunchInIndex = 1;
        private const int SelectionOffset = 1;

        private IWebDriver driver;
        private IWebElement row;

        private IWebElement GetCellInRowByIndex(int index)
        {
            var cell = row.FindElements(By.TagName("td"))[index];
            return cell;
        }

        public string PunchInText
        {
            get
            {
                driver.SwitchTo().Frame(0);
                var text = GetCellInRowByIndex(PunchInIndex).Text;
                driver.SwitchTo().ParentFrame();
                return text;
            }
        }

        public string PunchInTextWithSelection
        {
            get
            {
                driver.SwitchTo().Frame(0);
                var text = GetCellInRowByIndex(PunchInIndex + SelectionOffset).Text;
                driver.SwitchTo().ParentFrame();
                return text;
            }
        }
    }
}
