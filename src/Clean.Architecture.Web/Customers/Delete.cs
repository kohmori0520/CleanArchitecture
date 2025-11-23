using Clean.Architecture.UseCases.Customers.Delete;

namespace Clean.Architecture.Web.Customers;

public class Delete(IMediator _mediator) : Endpoint<DeleteCustomerRequest>
{
  public override void Configure()
  {
    Delete(DeleteCustomerRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Delete a Customer";
      s.Description = "Delete a Customer by its ID";
      s.ExampleRequest = new DeleteCustomerRequest { CustomerId = 1 };
    });
  }

  public override async Task HandleAsync(
    DeleteCustomerRequest request,
    CancellationToken cancellationToken)
    {
      var command = new DeleteCustomerCommand(request.CustomerId);
      var result = await _mediator.Send(command, cancellationToken);
      if (result.IsSuccess)
      {
        await SendNoContentAsync(cancellationToken);
        return;
      }
      else if (result.Status == ResultStatus.NotFound)
      {
        await SendNotFoundAsync(cancellationToken);
        return;
      }
    }

}