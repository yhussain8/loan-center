# Notes

## Rewriting Unit Tests to Automated Tests Using WebApplicationFactory

- Install latest version of Microsoft.AspNetCore.Mvc.Testing
- Create a different class for automated tests in the same test file
- Wrote test using HTTP Client created by WebApplicationFactory
- Test initially failed and I took two steps to resolve:
	- Made all internal objects of LoanCenter visible to LoanCenter.Tests via .csproj
	- Made Program class public by creating a partial class in Program.cs
- Had to convert LoanRequest object > JSON > String > HTTP Content to use with HTTP Client


---
## To Do List

- implement validations for all API input fields, with unit test (using Theory pattern) that also tests for messages by calling on the same constant field
	- design and implement validations for each field
	- build unit tests
	- design and implement friendly error messages for failing validations
- refactor out minimal APIs
- split controller tests from automated tests
- reuse the same test cases for testing also for Swagger examples

LoanRequest Validator:
- investigate source of default behaviour - fluent validation vs C# leveraging LoanRequest object
- investigate why custom messages are not being displayed
- validate phone number using RegEx or attribute as per: https://stackoverflow.com/questions/12908536/how-to-validate-the-phone-no
- refactor the messages into external object

## Defer to Later
- top-down refactor, styling, comments, and documentation