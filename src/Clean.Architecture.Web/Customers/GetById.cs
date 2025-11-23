using Clean.Architecture.UseCases.Customers.Get;

namespace Clean.Architecture.Web.Customers;

public class GetById(IMediator _mediator) : Endpoint<GetCustomerByIdRequest, CustomerRecord>
{
  public override void Configure()
  {
    Get(GetCustomerByIdRequest.Route);
    AllowAnonymous();
    Summary(s => {
      s.Summary = "Get a Customer by ID";
      s.Description = "Get a Customer by ID";
      s.ExampleRequest = new GetCustomerByIdRequest { CustomerId = 1 };
    });
  }

  public override async Task HandleAsync(
    GetCustomerByIdRequest request,
    CancellationToken cancellationToken)
    {
      var query = new GetCustomerQuery(request.CustomerId);
      var result = await _mediator.Send(query, cancellationToken);
      if (result.Status == ResultStatus.NotFound)
      {
        await SendNotFoundAsync(cancellationToken);
        return;
      }
      if (result.IsSuccess)
      {
        Response = new CustomerRecord(result.Value.Id, result.Value.CompanyName, result.Value.Status, result.Value.ContactPersonName, result.Value.PhoneNumber, result.Value.EmailAddress, result.Value.Address, result.Value.Notes, result.Value.Website);
      }
    }
}