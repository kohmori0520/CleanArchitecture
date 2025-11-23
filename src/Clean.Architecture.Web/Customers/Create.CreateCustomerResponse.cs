namespace Clean.Architecture.Web.Customers;

public class CreateCustomerResponse(int id, string companyName)
{
  public int Id { get; set; } = id;
  public string CompanyName { get; set; } = companyName;
}