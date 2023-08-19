# UI_Automation using Selenium with C#.Net language binding

library used in this repo are:

1. Nunit
2. Selenium.WebDriver

This repo supports:

1. Parallel testing 
    * supports running tests in cross browser. (update browser detail in .runsetting file)
    * supports runnig tests in same browsers.
        - Spin up the Docker file by triggering the 'SeleniumGrid_DockerUp.bat' (update type = remote in .runsetting file)
    * Also Selenium Grid Standa alone .jar is added to run the Parallel tests within local machine itself for that trigger 'SeleniumGrid_Standalone.bat'
2. Screenshot image of failed tests.
3. proper Log message to debug the failures.
4. Extent HTML report for 

Additional Info: 

1. for Parallel Execution of Nunit tests add [Parallelizable] tag to the respective tests and trigger via cmd / using IDE
2. the proper POM is followed and #CleanCode is taken care