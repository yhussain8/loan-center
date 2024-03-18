using Microsoft.AspNetCore.Mvc;

namespace LoanCenter.Controllers;

[Route("/index")]
[ApiController]
public class IndexController : ControllerBase
{
    /// <summary>
    /// Gets a friendly greeting
    /// </summary>
    /// <returns>A greeting string</returns>
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello Nick!");
    }
}