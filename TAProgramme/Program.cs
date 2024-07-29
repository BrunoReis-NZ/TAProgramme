using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
        // Open Chrome Browser
        IWebDriver driver = new ChromeDriver();
        
        // Launch TurnUp portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
        driver.Manage().Window.Maximize();
        Thread.Sleep(1000);

        // Identify username textbox and enter valid username
        IWebElement username = driver.FindElement(By.Id("UserName"));
        username.SendKeys("hari");

        // Identify password textbox and enter valid password
        IWebElement password = driver.FindElement(By.Id("Password"));
        password.SendKeys("123123");

        // Identify login button and click
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
        loginButton.Click();
        Thread.Sleep(2000);

        // Validate that user is logged in successfully
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

        if (helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("Logged in successfully, test passed.");
        }
        else
        {
            Console.WriteLine("Login failed, test failed.");
        }

        // Create a time record

        // Navigate to Time & Material page
        IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
        administrationTab.Click();

        IWebElement timeMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeMaterialOption.Click();

        // Click on Create New button
        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
        createNewButton.Click();

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

        // Click on Save button
        IWebElement saveButton = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
        saveButton.Click();
        Thread.Sleep(2000);

        // Validate that the time record is created successfully
        IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButton.Click();
        Thread.Sleep(2000);

        IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

        if (newCode.Text == "TA Programme")
        {
            Console.WriteLine("Time record created successfully, test passed.");
        }
        else
        {
            Console.WriteLine("Time record not created, test failed.");
        }

    }
}