using System.Text;
using System.Text.Json;

using LoanCenter.Controllers;
using LoanCenter.Models;

namespace LoanCenter.Tests;

public class LoanRequestController_UnitTests
{
    [Fact]
    public void LoanRequest_ReturnsStatusCode201()
    {
        var controller = new LoanRequestController();

        LoanRequest testLoanRequest = new() { EmailAddress = "nick@coach.com" };
        var result = controller.LoanRequest(testLoanRequest);

        var statusCodeResult  = Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(201, statusCodeResult.StatusCode);
    }
}

public class LoanRequestController_AutomatedTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public LoanRequestController_AutomatedTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async void PostLoanRequest_ReturnsStatusCode201()
    {
        // Arrange
        var client = _factory.CreateClient();

        var loanRequest = new LoanRequest() { EmailAddress = "nick@coach.com" };
        var jsonString = JsonSerializer.Serialize(loanRequest);
        var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/loanrequest", httpContent);

        // Assert
        response.EnsureSuccessStatusCode();
    }
}