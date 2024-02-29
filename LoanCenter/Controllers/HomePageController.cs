using Microsoft.AspNetCore.Mvc;

namespace LoanCenter.Controllers
{
    [Route("/index")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello Nick!");
        }
    }
}