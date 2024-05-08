using LoanCenter.Models;

namespace LoanCenter.SwaggerExamples;

public static class LoanRequestCases
{
    public static LoanRequest Valid1 = new()
    {
        Owner = false,
        PropertyType = LoanProperty.SingleFamilyHome,
        PropertyCost = 800_000,
        DownPayment = 200_000,
        LengthInYears = LoanLength.TwentyFive,
        EmailAddress = "jim_smith@gmail.com",
        PhoneNumber = "416-555-1234"
    };
    public static LoanRequest Valid2 = new()
    {
        Owner = true,
        PropertyType = LoanProperty.Plex,
        PropertyCost = 1_400_000,
        DownPayment = 400_000,
        LengthInYears = LoanLength.Fifteen,
        EmailAddress = "jane_brown@gmail.com",
        PhoneNumber = "905-555-9876"
    };
}