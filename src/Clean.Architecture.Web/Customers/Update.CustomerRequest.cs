using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Customers;

public class UpdateCustomerRequest
{
  public const string Route = "/Customers/{CustomerId:int}";
  public static string BuildRoute(int customerId) => Route.Replace("{CustomerId:int}", customerId.ToString());

  public int CustomerId { get; set; }
  [Required]
  public string? CompanyName { get; set; }
  public string? ContactPersonName { get; set; }
  public string? PhoneNumber { get; set; }
  public string? EmailAddress { get; set; }
  public string? Address { get; set; }
  public string? Notes { get; set; }
  public string? Website { get; set; }
}