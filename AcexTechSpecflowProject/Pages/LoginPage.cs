using AcexTechSpecflowProject.UtilityHelper;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcexTechSpecflowProject.Pages
{
    public class LoginPage
    {
        IWebDriver driver;

        IWebElement UsernameTextBox => driver.FindElement(By.Id("username"));
        IWebElement PasswordTextBox => driver.FindElement(By.Id("password"));
        IWebElement SignInButton => driver.FindElement(By.XPath("//*[@id=\"login\"]")); 

        string BaseURL = "https://adactinhotelapp.com/SearchHotel.php";
        public LoginPage()
        {
            driver = Hooks.driver; 
        }

        public void LaunchURL()
        {
            driver.Navigate().GoToUrl(BaseURL);
        }

        // datat driven launch url
        public void DataDrivenLaunchURL(string url)
        {
            driver.Navigate().GoToUrl(BaseURL);
        }


        // function to enter username and password
        public void EnterUsernameAndPassword(string password)
        {
            UsernameTextBox.SendKeys("EfeEhigiator");
            PasswordTextBox.SendKeys(password);
        }

        // Data driver entering username and password

        public void DataDriverEnterUsernameAndPassword(string userName, string password)
        {
            UsernameTextBox.SendKeys(userName);
            PasswordTextBox.SendKeys(password);
        }

        public void ClickSignInButton()
        {
            SignInButton.Click();
        }

        public void VerifySearchHotelPage()
        {
            string ActualTitle = "Adactin.com - Search Hotel";
            string ExpectedTitle = driver.Title;
             Assert.AreEqual(ExpectedTitle, ActualTitle);

            if (ActualTitle.Equals(ExpectedTitle))
            {
                Console.WriteLine("Test case passed");
            }
            else
            {
                Console.WriteLine("Test case failed");
            }
        }
    }
    
}
