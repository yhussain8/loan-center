using System.Net;
using System.Text;
using System.Text.Json;
using LoanCenter.Controllers;
using LoanCenter.Models;
using LoanCenter.Validators;

namespace LoanCenter.Tests.Controllers;

public class LoanRequestController_UnitTests
{
    private readonly LoanRequestValidator _validator = new LoanRequestValidator();

    [Fact]
    public void LoanRequest_ReturnsStatusCode201()
    {
        var controller = new LoanRequestController(_validator);

        LoanRequest testLoanRequest = new() { EmailAddress = "nick@coach.com" };
        var result = controller.LoanRequest(testLoanRequest);

        var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
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

        var loanRequest = new LoanRequest()
        {
            Owner = true,
            PropertyType = LoanProperty.SingleFamilyHome,
            PropertyCost = 1000,
            DownPayment = 300,
            LengthInYears = LoanLength.TwentyFive,
            EmailAddress = "nick@coach.com",
            PhoneNumber = "416-555-7777",
        };
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