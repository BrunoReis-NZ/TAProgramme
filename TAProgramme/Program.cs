using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TAProgramme.Pages;

public class Program
{
    private static void Main(string[] args)
    {
        // Open Chrome Browser
        IWebDriver driver = new ChromeDriver();

        // Implicit wait
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        // Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver);

        // HomePage object initialization and definition
        HomePage homePageObj = new HomePage();
        homePageObj.NavigateToTMPage(driver);

        // TMPage object initialization and definition
        TMPage tmPageObj = new TMPage();
        tmPageObj.CreateTimeRecord(driver);

        // Edit Time Record
        tmPageObj.EditTimeRecord(driver);

        // Delete Time Record
        tmPageObj.DeleteTimeRecord(driver);



    }
}