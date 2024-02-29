using LoanCenter.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanCenter.Tests
{
    public class LoanRequestControllerTests
    {
        [Fact]
        public void LoanRequest_ReturnsStatusCode201()
        {
            var controller = new LoanRequestController();

            var testEmailAddress = "nick@coach.com";
            var result = controller.LoanRequest(testEmailAddress);

            var statusCodeResult  = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, statusCodeResult.StatusCode);
        }
    }
}