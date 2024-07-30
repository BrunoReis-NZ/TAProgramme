using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TAProgramme.Pages;
using TAProgramme.Utilities;
using TechTalk.SpecFlow;

namespace TAProgramme.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        [Given(@"I logged in to TurUp portal successfully")]
        public void GivenILoggedInToTurUpPortalSuccessfully()
        {
            // Open Chrome Browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);
        }

        [When(@"I Navigate to time and Material Page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            // HomePage object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);
        }

        [When(@"I create a time record")]
        public void WhenICreateATimeRecord()
        {
            // TMPage object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateTimeRecord(driver);
        }

        [Then(@"The time record should be created successfully")]
        public void ThenTheTimeRecordShouldBeCreatedSuccessfully()
        {
            // TMPage object initialization and definition
            TMPage tmPageObj = new TMPage();

            string newCode = tmPageObj.GetCode(driver);
            string newDescription = tmPageObj.GetDescription(driver);
            string newPrice = tmPageObj.GetPrice(driver);

            Assert.That(newCode, Is.EqualTo("TA Programme"), "Actual code and expected code did not match");
            Assert.That(newDescription, Is.EqualTo("This is a description"), "Actual description and expected description did not match");
            Assert.That(newPrice, Is.EqualTo("$12.00"), "Actual price and expected price did not match");
        }

        [When(@"I update the '([^']*)' on a existing time record")]
        public void WhenIUpdateTheOnAExistingTimeRecord(string code)
        {
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditTimeRecord(driver, code);
        }

        [Then(@"The record should have the updated '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string code)
        {
            TMPage tmPageObj = new TMPage();

            string editedCode = tmPageObj.GetEditedCode(driver);

            Assert.That(editedCode, Is.EqualTo(code), "Actual code and expected code did not match");
            
        }

    }
}
