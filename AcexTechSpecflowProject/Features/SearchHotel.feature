Feature: SearchHotel

Test to verify that a customer is able to search and book a hotel
@tag1
Scenario: AS a customer I should be able to search and make a hotel booking
	Given I am logged in to the adacting website "Reason10"
	When I search hotel with the below search criterias
	| field           | value          |
	| Location        | London         |
	| Hotels          | Hotel Sunshine |
	| RoomType        | Double         |
	| NumberOfRooms   | 1 - One        |
	| CheckInDate     | 20/10/2023     |
	| CheckOutDate    | 30/10/2023     |
	| AdultsPerRoom   | 2 - Two        |
	| ChildrenPerRoom | 0 - None       |
And I click on the search button
Then the Search hotel page should display
And the Book Itinerary button is displayed at the top of the page 

	
