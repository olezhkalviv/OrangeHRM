﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrangeHRM.UI;
using System;
using System.Linq;
using System.Threading;

namespace OrangeHRM.Tests
{
    [TestFixture]
    class TempFixture
    {
        private IWebDriver driver;

        private const string Url = "https://orangehrm-demo-6x.orangehrmlive.com/auth/login";
        private const string Username = "admin";
        private const string Password = "admin123";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Url);
            LoginPage loginPage = new LoginPage(driver);
            Assert.IsTrue(loginPage.IsVisible, "Login page is not visible");
            loginPage.DoLogin(Username, Password);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test()
        {
            var level1Text = "Time";
            var level2Text = "Attendance";
            var level3Text = "Employee Records";
            var employeeName = "Andrew Keller";
            var day = 14;
            var empty = "No attendance records to display";
            var attendanceTime = "00:15";

            DashboardPage dashboardPage = new DashboardPage(driver);
            Assert.IsTrue(dashboardPage.IsVisible, "Dashboard page is not visible");
            dashboardPage.MenuComponent.OpenMenu(level1Text, level2Text, level3Text);
            Thread.Sleep(1000);
            ViewAttendanceRecordPage viewAttendanceRecordPage = new ViewAttendanceRecordPage(driver);
            Assert.IsTrue(viewAttendanceRecordPage.IsVisible, "View Attendance Record Page is not visible");
            viewAttendanceRecordPage.SetEmployeeName(employeeName);
            Thread.Sleep(1000);
            viewAttendanceRecordPage.SelectDay(day);
            Thread.Sleep(1000);
            viewAttendanceRecordPage.ClickView();
            Thread.Sleep(1000);
            Assert.AreEqual(empty, viewAttendanceRecordPage.TableRows.First().PunchInText);
            viewAttendanceRecordPage.ClickAdd();
            Thread.Sleep(1000);
            ProxyPunchInPunchOutPage proxyPunchInPunchOutPage = new ProxyPunchInPunchOutPage(driver);
            Assert.IsTrue(proxyPunchInPunchOutPage.IsVisible, "Proxy Punch In Punch Out page is not visible");
            proxyPunchInPunchOutPage.SetAttendanceTime(attendanceTime);
            Thread.Sleep(1000);
            proxyPunchInPunchOutPage.ClickIn();
            proxyPunchInPunchOutPage.ClickIn();
            Thread.Sleep(1000);
            Assert.IsTrue(viewAttendanceRecordPage.IsVisible, "View Attendance Record Page is not visible");
            Assert.AreEqual($"{DateTime.Now.ToString("yyyy-MM-")}{day} {attendanceTime}:00 GMT 3.0", viewAttendanceRecordPage.TableRows.First().PunchInTextWithSelection);
        }
    }
}
