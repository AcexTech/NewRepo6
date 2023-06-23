using AcexTechSpecflowProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcexTechSpecflowProject.StepDefinitions
{
    [Binding]
    public class SearchHotelStep 
    {
        SearchHotelPage searchHotelPage;
        LoginPage loginPage;

        public SearchHotelStep()
        {
            searchHotelPage = new SearchHotelPage();
            loginPage = new LoginPage();
        }
      

        [Given(@"I am logged in to the adacting website ""([^""]*)""")]
        public void GivenIAmLoggedInToTheAdactingWebsite(string password)
        {
            loginPage.LaunchURL();
            loginPage.EnterUsernameAndPassword(password);
            loginPage.ClickSignInButton();
        }


        [When(@"I search hotel with the below search criterias")]
        public void WhenISearchHotelWithTheBelowSearchCriterias(Table table)
        {
            searchHotelPage.EnterSearchCriteria(table);
        }

        [When(@"I click on the search button")]
        public void WhenIClickOnTheSearchButton()
        {
            searchHotelPage.ClickSearchButton();
        }

        [Then(@"the Search hotel page should display")]
        public void ThenTheSearchHotelPageShouldDisplay()
        {
            
        }

        [Then(@"the Book Itinerary button is displayed at the top of the page")]
        public void ThenTheBookItineraryButtonIsDisplayedAtTheTopOfThePage()
        {
            searchHotelPage.ValidateIteneraryPage();    
        }

    }
}
