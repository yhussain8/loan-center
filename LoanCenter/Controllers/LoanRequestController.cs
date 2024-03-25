using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

using LoanCenter.Models;
using LoanCenter.SwaggerExamples;

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
    [SwaggerRequestExample(typeof(LoanRequest), typeof(LoanRequestExamples))]
    public IActionResult LoanRequest(LoanRequest request)
    {
        Console.WriteLine(request.EmailAddress);
        return StatusCode(201);
    }
}