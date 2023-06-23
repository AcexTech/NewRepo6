Feature: Login

Test to verify that a registered user is able to login to the application with valid credentials

@tag1
Scenario: As a user I should be able to login to the application with my credentials
	Given I navigate to the adactin website
	When I enter my userName and  password as "Reason10"
	And I click on the login button
	Then the search hotel page should be displayed
	

#	Scenario Outline:  I should be able to login to the application with my credentials
#	Given I navigate to the adactin website "https://adactinhotelapp.com/SearchHotel.php"
#	When I enter my "<userName>" and "<password>"
#	And I click on the log in button
#	Then the search hotel page is be displayed 
#
#	Examples: 
#	| userName        | password      |
#	| EfeEhigiator    | Reason10      |
#	| johnuser212     | iloveYOU101   |
	


