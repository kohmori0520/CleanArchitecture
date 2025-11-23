using Clean.Architecture.UseCases.Customers;

namespace Clean.Architecture.Web.Customers;

public class UpdateCustomerResponse(CustomerDTO customer)
{
  public CustomerDTO Customer { get; set; } = customer;
}