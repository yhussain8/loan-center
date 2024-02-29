using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanCenter.Controllers
{
    [Route("/loanRequest")]
    [ApiController]
    public class LoanRequestController : ControllerBase
    {
        [HttpPost]
        public IActionResult LoanRequest(string emailAddress)
        {
            Console.WriteLine(emailAddress);
            return StatusCode(201);
        }
    }
}