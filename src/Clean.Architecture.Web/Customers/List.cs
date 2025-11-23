using Clean.Architecture.UseCases.Customers;
using Clean.Architecture.UseCases.Customers.List;

namespace Clean.Architecture.Web.Customers;

public class List(IMediator _mediator) : EndpointWithoutRequest<CustomerListResponse>
{
  public override void Configure()
  {
    Get("/Customers");
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "List all Customers";
      s.Description = "List all customers - returns a CustomerListResponse containing the Customers.";
    });
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListCustomersQuery(), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CustomerListResponse
      {
        Customers = result.Value.Select(c => new CustomerRecord(c.Id, c.CompanyName, c.Status, c.ContactPersonName, c.PhoneNumber, c.EmailAddress, c.Address, c.Notes, c.Website)).ToList()
      };
    }
  }
}