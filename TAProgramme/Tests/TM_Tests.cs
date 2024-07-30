using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAProgramme.Pages;
using TAProgramme.Utilities;

namespace TAProgramme.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            // Open Chrome Browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            // HomePage object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);

        }

        [Test, Order(1)]
        public void CreateTimeTest()
        {
            // TMPage object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateTimeRecord(driver);
        }

        [Test, Order(2)]
        public void EditTimeTest()
        {
            TMPage tmPageObj = new TMPage();
            // Edit Time Record
            tmPageObj.EditTimeRecord(driver, "");


        }

        [Test, Order(3)]
        public void DeleteTimeTest()
        {
            TMPage tmPageObj = new TMPage();
            // Delete Time Record
            tmPageObj.DeleteTimeRecord(driver);

        }

        [TearDown]
        public void CloseTestRun()
        {
            // Close the browser
            driver.Quit();
        }
    }
}
