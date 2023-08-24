# UI_Automation using Selenium with C#.Net language binding

List of libraries used in this repo:

1. Nunit
2. Selenium.WebDriver
3. Playwright
4. RestSharp
5. ExtentReport
6. SeriLog

This repo supports the following:

1. Parallel testing 
    * supports running tests in cross-browser. (update browser detail in .runsetting file)
    * supports running tests in the same browsers.
        - Spin up the Docker file by triggering the 'SeleniumGrid_DockerUp.bat' (update type = remote in .runsetting file)
    * Selenium Grid Stand Alone .jar is added to run the Parallel tests within the local machine itself for that run 'SeleniumGrid_Standalone.bat' file
2. Screenshot image of failed tests.
3. Proper log message to debug the failures.
4. Extent HTML report to view BDD - Specflow Scenario results.

Additional Info: 

1. for Parallel Execution of Nunit tests add [Parallelizable] tag to the respective tests and trigger via cmd / using IDE
2. The proper POM is followed and #CleanCode is taken care
