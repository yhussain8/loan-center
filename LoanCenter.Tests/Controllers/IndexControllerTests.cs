using LoanCenter.Controllers;

namespace LoanCenter.Tests.Controllers;

public class IndexController_UnitTests
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

public class IndexController_AutomatedTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public IndexController_AutomatedTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async void GetIndex_ReturnsHelloNick()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/index");
        var responseString = await response.Content.ReadAsStringAsync();

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("Hello Nick!", responseString);
    }
}