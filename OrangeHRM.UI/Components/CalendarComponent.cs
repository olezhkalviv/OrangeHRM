﻿using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Support.PageObjects;

namespace OrangeHRM.UI
{
    internal class CalendarComponent
    {
        internal CalendarComponent(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "attendance_date_root")]
        private IWebElement Calendar { get; set; }

        internal void SelectDay(int day)
        {
            var item = Calendar.FindElements(By.ClassName("picker__day")).First(d => d.Text.Equals(day.ToString()));
            item.Click();
        }
    }
}
