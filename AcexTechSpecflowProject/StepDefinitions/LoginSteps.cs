using AcexTechSpecflowProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcexTechSpecflowProject.StepDefinitions
{
    [Binding]
    public class LoginSteps 
    {
        LoginPage loginpage;

        public LoginSteps()
        {
            loginpage = new LoginPage();
        }

        [Given(@"I navigate to the adactin website")]
        public void GivenINavigateToTheAdactinWebsite()
        {
            loginpage.LaunchURL();
        }

        [When(@"I enter my userName and  password as ""([^""]*)""")]
        public void WhenIEnterMyUserNameAndPasswordAs(string password)
        {
            loginpage.EnterUsernameAndPassword(password);

        }



        [When(@"I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
            loginpage.ClickSignInButton();
        }

        [Then(@"the search hotel page should be displayed")]
        public void ThenTheSearchHotelPageShouldBeDisplayed()
        {
            
        }

    }
}
