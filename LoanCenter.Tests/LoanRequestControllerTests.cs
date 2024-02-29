using Microsoft.AspNetCore.Mvc;

using LoanCenter.Controllers;
using LoanCenter.Models;

namespace LoanCenter.Tests
{
    public class LoanRequestControllerTests
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
}