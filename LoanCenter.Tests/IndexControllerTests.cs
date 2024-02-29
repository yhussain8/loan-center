using LoanCenter.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace LoanCenter.Tests
{
    public class IndexControllerTests
    {
        [Fact]
        public void Index_ReturnsHelloNick()
        {
            var controller = new IndexController();

            var result = controller.Index();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode); ;
            Assert.Equal("Hello Nick!", okResult.Value);
        }
    }
}