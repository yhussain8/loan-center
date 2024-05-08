using LoanCenter.Models;
using LoanCenter.SwaggerExamples;
using Swashbuckle.AspNetCore.Filters;

namespace LoanCenter.SwaggerExamples;
public class LoanRequestExamples : IMultipleExamplesProvider<LoanRequest>
{
    public IEnumerable<SwaggerExample<LoanRequest>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "Valid 1",
            LoanRequestCases.Valid1
        );

        yield return SwaggerExample.Create(
            "Valid 2",
            LoanRequestCases.Valid2
        );
    }
}