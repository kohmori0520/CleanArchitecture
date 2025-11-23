using Clean.Architecture.UseCases.Customers.Update;

namespace Clean.Architecture.Web.Customers;

public class Update(IMediator _mediator)
  : Endpoint<UpdateCustomerRequest, UpdateCustomerResponse>
{
  public override void Configure()
  {
    Put(UpdateCustomerRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateCustomerRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(
      new UpdateCustomerCommand(
        request.CustomerId,
        request.CompanyName,
        request.ContactPersonName,
        request.PhoneNumber,
        request.EmailAddress,
        request.Address,
        request.Notes,
        request.Website),
      cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new UpdateCustomerResponse(result.Value);
    }
  }
}