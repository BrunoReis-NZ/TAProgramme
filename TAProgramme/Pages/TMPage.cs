using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAProgramme.Utilities;

namespace TAProgramme.Pages
{
    public class TMPage
    {
        public void CreateTimeRecord (IWebDriver driver)
        {
            try
            {
                // Click on Create New button
                IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
                createNewButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Create New button not found");
            }
           

            // Select Time in TypeCode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            typeCodeDropdown.Click();

            // Type Code in Code textbox
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.SendKeys("TA Programme");

            // Type Description in Description textbox
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.SendKeys("This is a description");

            // Type Price per unit in Price per unit textbox
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();

            IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
            priceTextBox.SendKeys("12");

            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 3);
            // Click on Save button
            IWebElement saveButton = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            saveButton.Click();
            Thread.Sleep(2000);

            // Validate that the time record is created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(newCode.Text == "TA Programme", "Time record not created successfully");
        }

        public void EditTimeRecord(IWebDriver driver)
        {
            // Put your code here           
        }

        public void DeleteTimeRecord(IWebDriver driver)
        {
            // Put your code here           
        }


    }
}
