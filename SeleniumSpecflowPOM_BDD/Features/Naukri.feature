﻿Feature: Naukri

	Uploade Resume in Naukri profile

@Login @specflow
Scenario: Valid User able to Login successfully
	Given Login to Naukri profile with valid creds
	Then  Validate Title of the Page


@FileUpload 
Scenario: Valid User able to Upload the Resume successfully
	Given Login to Naukri profile with valid creds
	Then  Navigate to Profile session
	And   Upload the Resume file 'Resume.pdf'
	Then  Validate the uploaded resume file name