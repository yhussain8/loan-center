using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

using LoanCenter.Models;
using LoanCenter.SwaggerExamples;
using FluentValidation.Results;
using FluentValidation.AspNetCore;

namespace LoanCenter.Controllers;

[Route("/loanRequest")]
[ApiController]
public class LoanRequestController : ControllerBase
{
    private IValidator<LoanRequest> _validator;

    public LoanRequestController(IValidator<LoanRequest> validator)
    {
        _validator = validator;
    }

    /// <summary>
    /// Accepts a new loan request
    /// </summary>
    /// <response code="201">Loan request accepted</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [SwaggerRequestExample(typeof(LoanRequest), typeof(LoanRequestExamples))]
    public IActionResult LoanRequest(LoanRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        Console.WriteLine(request.EmailAddress);
        return StatusCode(201);
    }
}