Feature: ParaBank

A short summary of the feature

@tag1
Scenario: Validate user able to login succussfully
	Given Navigate to Url 'https://parabank.parasoft.com/'
	When Enter User Name as 'pintu'
	And Enter Password as 'chotu'
	Then Click on Login
	And Validate that User succussfully landed to home screen