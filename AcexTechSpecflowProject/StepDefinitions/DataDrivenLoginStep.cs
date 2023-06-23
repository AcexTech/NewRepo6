using AcexTechSpecflowProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcexTechSpecflowProject.StepDefinitions
{
    [Binding]
    public class DataDrivenLoginStep
    {

        LoginPage loginPage;
        public DataDrivenLoginStep()
        {
            loginPage = new LoginPage();
        }

        [Given(@"I navigate to the adactin website ""([^""]*)""")]
        public void GivenINavigateToTheAdactinWebsite(string url) 
        {
            loginPage.DataDrivenLaunchURL(url);
        }

        [When(@"I enter my ""([^""]*)"" and ""([^""]*)""")]
        public void WhenIEnterMyAnd(string userName, string password) 
        {
            loginPage.DataDriverEnterUsernameAndPassword(userName, password);
        }

        [When(@"I click on the log in button")]
        public void WhenIClickOnTheLogInButton()
        {
            loginPage.ClickSignInButton();
        }

        [Then(@"the search hotel page is be displayed")]
        public void ThenTheSearchHotelPageIsBeDisplayed()
        {
            loginPage.VerifySearchHotelPage();
        }

    }
}
