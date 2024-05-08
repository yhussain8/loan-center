using FluentValidation;

using LoanCenter.Models;
using System.Text.RegularExpressions;

namespace LoanCenter.Validators;

public class LoanRequestValidator : AbstractValidator<LoanRequest>
{
    public LoanRequestValidator()
    {
        RuleFor(loanRequest => loanRequest.Owner)
            .NotNull()
            .WithMessage("'Owner' is required and must be True or False.");

        RuleFor(loanRequest => loanRequest.PropertyType)
            .NotEmpty()
            .IsInEnum()
            .WithMessage("'Property Type' is required and must be one of SingleFamilyHome, Plex, or Commercial.");

        RuleFor(loanRequest => loanRequest.PropertyCost)
            .NotEmpty()
            .WithMessage("'Property Cost' is required.");

        RuleFor(loanRequest => loanRequest.DownPayment)
            .NotEmpty()
            .WithMessage("'Down Payment' is required.");

        RuleFor(loanRequest => loanRequest.LengthInYears)
            .NotEmpty()
            .IsInEnum()
            .WithMessage("'Length In Years' is required and must be one of 5, 10, 15, 20, or 25.");

        RuleFor(loanRequest => loanRequest.EmailAddress)
            .EmailAddress()
            .WithMessage("'Email Address' is required and must be valid.");

        RuleFor(loanRequest => loanRequest.PhoneNumber)
            .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
            .WithMessage("'Phone Number' is required and must be valid.");
        
        // todo:
        // investigate source of default behaviour - fluent validation vs C# leveraging LoanRequest object
        // investigate why custom messages are not being displayed
        // validate phone number using RegEx or attribute as per: https://stackoverflow.com/questions/12908536/how-to-validate-the-phone-no
        // refactor the messages into external object

        RuleFor(loanRequest => loanRequest.DownPayment)
            .Must((loanRequest, downPayment) => downPayment >= (loanRequest.PropertyCost * 0.05m))
            .WithMessage("The down payment must be greater than or equal to 5% of the property cost.");
    }
}