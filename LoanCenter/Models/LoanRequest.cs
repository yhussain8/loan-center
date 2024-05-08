using System.ComponentModel;

namespace LoanCenter.Models;

/// <summary>
/// Input data for a customer loan request
/// </summary>
public class LoanRequest
{
    /// <summary>
    /// Represents if the customer is the existing owner of the property
    /// </summary>
    public bool? Owner { get; set; }
    // todo: rename to IsOwner

    /// <summary>
    /// Type of property
    /// </summary>
    public LoanProperty? PropertyType { get; set; }

    /// <summary>
    /// Total purchase price of property in $CAD
    /// </summary>
    public decimal? PropertyCost { get; set; }

    /// <summary>
    /// Total down payment cost of property in $CAD
    /// </summary>
    public decimal? DownPayment { get; set; }

    /// <summary>
    /// Length of loan amortization in years
    /// </summary>
    public LoanLength? LengthInYears { get; set; }

    /// <summary>
    /// Customer contact email address
    /// </summary>
    public string? EmailAddress { get; set; } = string.Empty;

    /// <summary>
    /// Customer contact phone number
    /// </summary>
    public string? PhoneNumber { get; set; } = string.Empty;
}

/// <summary>
/// Loan property type
/// </summary>
public enum LoanProperty
{
    /// <summary>
    /// Single family home
    /// </summary>
    SingleFamilyHome,

    /// <summary>
    /// Plex-type property (e.g. Duplex, Triplex)
    /// </summary>
    Plex,

    /// <summary>
    /// Commerical property
    /// </summary>
    Commercial
}

/// <summary>
/// Loan length in years
/// </summary>
public enum LoanLength
{
    /// <summary>
    /// Five year loan
    /// </summary>
    Five = 5,

    /// <summary>
    /// Ten year loan
    /// </summary>
    Ten = 10,

    /// <summary>
    /// Fifteen year loan
    /// </summary>
    Fifteen = 15,

    /// <summary>
    /// Twenty year loan
    /// </summary>
    Twenty = 20,

    /// <summary>
    /// Twenty-five year loan
    /// </summary>
    TwentyFive = 25
}