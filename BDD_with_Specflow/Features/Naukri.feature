Feature: Naukri

	Uploade Resume in Naukri profile

@Login
Scenario: Valid User able to Login successfully
	Given Login to Naukri profile with valid creds
	Then  Validate Title of the Page


@FileUpload
Scenario: Valid User able to Upload the Resume successfully
	Given Login to Naukri profile with valid creds
	Then  Navigate to Profile session
	And   Upload the Resume 
	Then  Validate the uploaded resume file name