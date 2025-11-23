using Clean.Architecture.Core.CustomerAggregate;

namespace Clean.Architecture.UseCases.Customers.Create;

/// <summary>
/// CreateCustomerCommandのハンドラ
/// </summary>
public class CreateCustomerHandler(IRepository<Customer> _repository)
  : ICommandHandler<CreateCustomerCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
  {
    var newCustomer = new Customer(request.CompanyName);

    // オプション項目を設定
    if (!string.IsNullOrEmpty(request.ContactPersonName))
      newCustomer.UpdateContactPersonName(request.ContactPersonName);

    if (!string.IsNullOrEmpty(request.PhoneNumber))
      newCustomer.UpdatePhoneNumber(request.PhoneNumber);

    if (!string.IsNullOrEmpty(request.EmailAddress))
      newCustomer.UpdateEmailAddress(request.EmailAddress);

    if (!string.IsNullOrEmpty(request.Address))
      newCustomer.UpdateAddress(request.Address);

    if (!string.IsNullOrEmpty(request.Notes))
      newCustomer.UpdateNotes(request.Notes);

    if (!string.IsNullOrEmpty(request.Website))
      newCustomer.UpdateWebsite(request.Website);

    var createdItem = await _repository.AddAsync(newCustomer, cancellationToken);
    return createdItem.Id;
  }
}