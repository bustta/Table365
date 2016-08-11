Feature: PostTablePhoto
	ensure the photo be saved sucessfully

@mytag
Scenario: post photo of table
	Given I have received a photo from client side
	When save into DB
	Then the count of table Photo should be plus one
