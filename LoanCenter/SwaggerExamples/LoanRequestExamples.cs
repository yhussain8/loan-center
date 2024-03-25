using LoanCenter.Models;
using Swashbuckle.AspNetCore.Filters;

namespace LoanCenter.SwaggerExamples;
public class LoanRequestExamples : IMultipleExamplesProvider<LoanRequest>
{
    public IEnumerable<SwaggerExample<LoanRequest>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "Example 1",
            new LoanRequest()
            {
                Owner = false,
                PropertyType = LoanProperty.SingleFamilyHome,
                PropertyCost = 800_000,
                DownPayment = 200_000,
                LengthInYears = LoanLength.TwentyFive,
                EmailAddress = "jim_smith@gmail.com",
                PhoneNumber = "416-555-1234"
            }
        );

        yield return SwaggerExample.Create(
            "Example 2",
            new LoanRequest()
            {
                Owner = true,
                PropertyType = LoanProperty.SingleFamilyHome,
                PropertyCost = 1_400_000,
                DownPayment = 400_000,
                LengthInYears = LoanLength.Fifteen,
                EmailAddress = "jane_brown@gmail.com",
                PhoneNumber = "905-555-9876"
            }
        );
    }
}