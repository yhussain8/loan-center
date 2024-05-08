using LoanCenter.Controllers;
using LoanCenter.Models;
using LoanCenter.Validators;

namespace LoanCenter.Tests;

public class LoanRequestValidatorTests
{
    private readonly LoanRequestValidator _validator = new LoanRequestValidator();

    [Theory]
    [InlineData(true, 1, 1000, 300, 5, "someone@website.com", "123-4567-890", true)]
    [InlineData(null, 1, 1000, 300, 5, "someone@website.com", "123-4567-890", false)]
    [InlineData(true, null, 1000, 300, 5, "someone@website.com", "123-4567-890", false)]
    [InlineData(true, 7, 1000, 300, 5, "someone@website.com", "123-4567-890", false)]
    [InlineData(true, 100, 1000, 300, 5, "someone@website.com", "123-4567-890", false)]
    [InlineData(true, 1, null, 300, 5, "someone@website.com", "123-4567-890", false)]
    [InlineData(true, 1, 1000, null, 5, "someone@website.com", "123-4567-890", false)]
    [InlineData(true, 1, 1000, 300, null, "someone@website.com", "123-4567-890", false)]
    [InlineData(true, 1, 1000, 300, 17, "someone@website.com", "123-4567-890", false)]
    [InlineData(true, 1, 1000, 300, 5, "jim", "123-4567-890", false)]
    [InlineData(true, 1, 1000, 300, 5, "someone@website.com", "abc", false)]
    public async Task Validator_ShouldReturn_Expected(
        bool? owner,
        int? propertyType,
        int? propertyCost,
        int? downPayment,
        int? lengthInYears,
        string? emailAddress,
        string? phoneNumber,
        bool expectedResult
    )
    {
        var loanRequest = new LoanRequest()
        {
            Owner = owner,
            PropertyType = (LoanProperty?)propertyType,
            PropertyCost = (decimal?)propertyCost,
            DownPayment = (decimal?)downPayment,
            LengthInYears = (LoanLength?)lengthInYears, 
            EmailAddress = emailAddress, 
            PhoneNumber = phoneNumber
        };

        var validationResult = await _validator.ValidateAsync(loanRequest);
        Assert.Equal(expectedResult, validationResult.IsValid);
    }
}