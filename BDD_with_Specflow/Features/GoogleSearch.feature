Feature: GoogleSearch

A short summary of the feature

@google
Scenario: Verify User able to launch google home page
	Given Navigate to Url 'https://www.google.com/'
	Then Validate the Home screen page
