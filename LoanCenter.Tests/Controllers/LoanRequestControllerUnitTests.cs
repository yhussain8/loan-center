using LoanCenter.Controllers;
using LoanCenter.Models;
using LoanCenter.Validators;

namespace LoanCenter.Tests.Controllers;

public class LoanRequestControllerUnitTests
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