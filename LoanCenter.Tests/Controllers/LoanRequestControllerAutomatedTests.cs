using System.Net;
using System.Text;
using System.Text.Json;

using LoanCenter.Models;
using LoanCenter.SwaggerExamples;

namespace LoanCenter.Tests.Controllers;

public class LoanRequestControllerAutomatedTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public LoanRequestControllerAutomatedTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async void PostLoanRequest_ReturnsStatusCode201()
    {
        // Arrange
        var client = _factory.CreateClient();

        var loanRequest = LoanRequestCases.Valid1;
        var jsonString = JsonSerializer.Serialize(loanRequest);
        var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/loanrequest", httpContent);

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async void PostLoanRequest_ReturnsBadRequest_WhenRequestIs_Invalid()
    {
        // Arrange
        var client = _factory.CreateClient();

        var loanRequest = new LoanRequest();
        var jsonString = JsonSerializer.Serialize(loanRequest);
        var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/loanrequest", httpContent);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}