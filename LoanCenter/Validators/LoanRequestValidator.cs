using FluentValidation;

using LoanCenter.Models;

namespace LoanCenter.Validators;

public class LoanRequestValidator : AbstractValidator<LoanRequest>
{
    public LoanRequestValidator()
    {
        RuleFor(loanRequest => loanRequest.DownPayment)
            .Must((loanRequest, downPayment) => downPayment > (loanRequest.PropertyCost * 0.2m))
            .WithMessage("The down payment must be greater than 20% of the property cost.");
    }
}