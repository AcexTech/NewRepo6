using AcexTechSpecflowProject.UtilityHelper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcexTechSpecflowProject.Pages
{
    public class SearchHotelPage
    {
        IWebDriver driver;
        Waits waits;

        IWebElement SelectLocation => driver.FindElement(By.Id("location"));
        IWebElement SelectHotel => driver.FindElement(By.Id("hotels"));
        IWebElement SelectRomeType => driver.FindElement(By.Id("room_type"));
        IWebElement SelectNumberOfRooms => driver.FindElement(By.Id("room_nos"));
        IWebElement EnterCheckInDate => driver.FindElement(By.Id("datepick_in"));
        IWebElement EnterCheckOutDate => driver.FindElement(By.Id("datepick_out"));
        IWebElement SelectAdultsPerRoom => driver.FindElement(By.Id("adult_room"));
        IWebElement SelectChildrenPerRoom => driver.FindElement(By.Id("child_room"));
        IWebElement SearchButton => driver.FindElement(By.Id("Submit"));
        IWebElement BookItinaryButton => driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr[1]/td[2]/a[2]"));

        IWebElement BookedHotel => driver.FindElement(By.Id("hotel_name_0"));

        public SearchHotelPage() 
        {
            driver = Hooks.driver;
            waits = new Waits();
        }

        // Entering search criteria
        public void EnterSearchCriteria(Table table)
        {
            
            var dictionary = TableExtension.ToDictionary(table);
            var test = dictionary["Location"];

            
            waits.WaitForElement(driver, SelectLocation);

            SelectElement selectLocation = new SelectElement(SelectLocation);
            selectLocation.SelectByText(dictionary["Location"]);

            SelectElement selectHotel = new SelectElement(SelectHotel);
            selectHotel.SelectByText(dictionary["Hotels"]);

            SelectElement selectRoomType = new SelectElement(SelectRomeType);
            selectRoomType.SelectByText(dictionary["RoomType"]);

            SelectElement noOfRooms = new SelectElement(SelectNumberOfRooms);
            noOfRooms.SelectByText(dictionary["NumberOfRooms"]);

            EnterCheckInDate.SendKeys(dictionary["CheckInDate"]);
            EnterCheckOutDate.SendKeys(dictionary["CheckOutDate"]);

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait1.Until(driver => (SelectAdultsPerRoom));

            SelectElement adultsPerRoom = new SelectElement(SelectAdultsPerRoom);
            adultsPerRoom.SelectByText(dictionary["AdultsPerRoom"]);

            SelectElement childrenPerRoom = new SelectElement(SelectChildrenPerRoom);
            childrenPerRoom.SelectByText(dictionary["ChildrenPerRoom"]);
        }

        public void ClickSearchButton()
        {
            waits.WaitForElement(driver, SearchButton);
            SearchButton.Click();
        }

        // Validating that we are on the hotel display page
        public void ValidateIteneraryPage()
        {
           
            string ExpectedText = BookItinaryButton.Text;
            string ActualText = "Booked Itinerary";
            Assert.AreEqual(ExpectedText, ActualText);

            //Thread.Sleep(3000);
            //string ExpectedBookedHotel = "Hotel Sunshine";
            //string ActualBookedHotel = BookedHotel.Text;
            //Assert.AreEqual(ExpectedBookedHotel, ActualBookedHotel);
            

            if (BookItinaryButton.Displayed)
            {
                Console.WriteLine("Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }

           
        }
        





    }
}
