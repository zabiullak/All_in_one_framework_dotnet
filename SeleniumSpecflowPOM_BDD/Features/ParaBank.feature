Feature: ParaBank

A short summary of the feature

@parabank @specflow
Scenario: Validate user able to login succussfully
	Given Navigate to Url 'https://parabank.parasoft.com/'
	When Enter User Name as 'abc'
	And Enter Password as '123'
	Then Click on Login
	And Validate that User succussfully landed to home screen