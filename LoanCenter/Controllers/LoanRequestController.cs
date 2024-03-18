using Microsoft.AspNetCore.Mvc;

using LoanCenter.Models;

namespace LoanCenter.Controllers;

[Route("/loanRequest")]
[ApiController]
public class LoanRequestController : ControllerBase
{
    [HttpPost]
    public IActionResult LoanRequest(LoanRequest request)
    {
        Console.WriteLine(request.EmailAddress);
        return StatusCode(201);
    }
}