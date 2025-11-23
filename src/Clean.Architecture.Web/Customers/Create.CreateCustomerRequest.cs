using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Customers;

public class CreateCustomerRequest
{
  public const string Route = "/Customers";

  [Required]
  public string? CompanyName { get; set; }
  public string? ContactPersonName { get; set; }
  public string? PhoneNumber { get; set; }
  public string? EmailAddress { get; set; }
  public string? Address { get; set; }
  public string? Notes { get; set; }
  public string? Website { get; set; }
}