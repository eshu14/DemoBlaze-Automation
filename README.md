# DemoBlaze
Contains a Core automation project and a test project.

Selenium WebDriver based automated tests.

Technology-wise it is a Microsoft .NET Core project using: We can install the below packages in Visual studio 2019.

.NET Core 3.1
xUnit.net
Fluent Assertions
Selenium WebDriver
Running tests on local machine

By default the tests run on Chrome browser. In order to run the tests locally, download the ChromeDriver to a local path.

Create an environment variable containing that local path to the webdriver:

ChromeWebDriver=C:\SeleniumWebDrivers\ChromeWebDriver

Restore the nuget packages for the solution and execute the tests using the Test Explorer.


For example:

Browser = Windows Chrome
