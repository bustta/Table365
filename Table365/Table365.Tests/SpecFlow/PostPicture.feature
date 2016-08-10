Feature: PostPicture
	ensure the photo be saved sucessfully

@mytag
Scenario: Add two numbers
	Given I have received a photo from client side
	When save into DB
	Then the count of table Photo should be plus one
