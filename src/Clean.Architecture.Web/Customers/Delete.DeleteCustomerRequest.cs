namespace Clean.Architecture.Web.Customers;

public class DeleteCustomerRequest
{
  public const string Route = "/Customers/{CustomerId:int}";
  public static string BuildRoute(int customerId) => Route.Replace("{CustomerId:int}", customerId.ToString());
  public int CustomerId { get; set; }
}
