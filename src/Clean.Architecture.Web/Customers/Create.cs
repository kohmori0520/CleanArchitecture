using Clean.Architecture.UseCases.Customers.Create;

namespace Clean.Architecture.Web.Customers;

/// <summary>
/// Create a new Customer
/// </summary>
/// <remarks>
/// Creates a new Customer given a company name.
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreateCustomerRequest, CreateCustomerResponse>
{
  public override void Configure()
  {
    Post(CreateCustomerRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Create a new Customer";
      s.Description = "Create a new Customer. Company name is required.";
      s.ExampleRequest = new CreateCustomerRequest
      {
        CompanyName = "株式会社サンプル",
        ContactPersonName = "山田太郎",
        PhoneNumber = "03-1234-5678",
        EmailAddress = "yamada@sample.co.jp",
        Address = "東京都渋谷区",
        Notes = "重要顧客"
      };
    });
  }

  public override async Task HandleAsync(
    CreateCustomerRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(
      new CreateCustomerCommand(
        request.CompanyName!,
        request.ContactPersonName,
        request.PhoneNumber,
        request.EmailAddress,
        request.Address,
        request.Notes,
        request.Website),
      cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateCustomerResponse(
        result.Value,
        request.CompanyName!);
      return;
    }
  }
}