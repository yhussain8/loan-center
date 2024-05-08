using LoanCenter.Controllers;

namespace LoanCenter.Tests.Controllers;

public class IndexControllerUnitTests
{
    [Fact]
    public void Index_ReturnsHelloNick()
    {
        // Arrange
        var controller = new IndexController();

        // Act
        var result = controller.Index();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
        Assert.Equal("Hello Nick!", okResult.Value);
    }
}