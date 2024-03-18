# Notes

## Rewriting Unit Tests to Automated Tests Using WebApplicationFactory

- Install latest version of Microsoft.AspNetCore.Mvc.Testing
- Create a different class for automated tests in the same test file
- Wrote test using HTTP Client created by WebApplicationFactory
- Test initially failed and I took two steps to resolve:
	- Made all internal objects of LoanCenter visible to LoanCenter.Tests via .csproj
	- Made Program class public by creating a partial class in Program.cs
- Had to convert LoanRequest object > JSON > String > HTTP Content to use with HTTP Client