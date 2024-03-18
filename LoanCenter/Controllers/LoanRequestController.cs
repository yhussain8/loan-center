using Microsoft.AspNetCore.Mvc;

using LoanCenter.Models;

namespace LoanCenter.Controllers;

[Route("/loanRequest")]
[ApiController]
public class LoanRequestController : ControllerBase
{
    /// <summary>
    /// Accepts a new loan request
    /// </summary>
    /// <response code="201">Loan request accepted</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult LoanRequest(LoanRequest request)
    {
        Console.WriteLine(request.EmailAddress);
        return StatusCode(201);
    }
}