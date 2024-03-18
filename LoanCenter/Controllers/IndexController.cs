using Microsoft.AspNetCore.Mvc;

namespace LoanCenter.Controllers;

[Route("/index")]
[ApiController]
public class IndexController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello Nick!");
    }
}