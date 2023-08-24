# UI Automation using Selenium with C#.Net and Playwright tool
# API Automation using RestSharp
# Mocking and Stubbing using WireMock.Net

**List of libraries used in this repo:**

1. Nunit
2. Selenium.WebDriver
3. Playwright
4. SpecFlow.NET
5. RestSharp
6. ExtentReport
7. SeriLog

**This repo supports the following:**

1. Parallel testing 
    * supports running tests in cross-browser. (update browser detail in .runsetting file)
    * supports running tests in the same browsers.
        - Spin up the Docker file by triggering the 'SeleniumGrid_DockerUp.bat' (update type = remote in .runsetting file)
    * Selenium Grid Stand Alone .jar is added to run the Parallel tests within the local machine itself for that run 'SeleniumGrid_Standalone.bat' file
2. Screenshot image of failed tests.
3. Proper log message to debug the failures.
4. Extent HTML report to view BDD - Specflow Scenario results.


**Steps to Run Test cases:**

1. Open the cloned repo, Navigate to the dialog box: Test -> Configure Run Settings -> add/select the _.runsetting_ file
2. Go to Test Explorer. Select any test cases to run.  
