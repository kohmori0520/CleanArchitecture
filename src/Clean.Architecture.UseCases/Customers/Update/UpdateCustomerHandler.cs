using Clean.Architecture.Core.CustomerAggregate;

namespace Clean.Architecture.UseCases.Customers.Update;

/// <summary>
/// UpdateCustomerCommandのハンドラ
/// </summary>
public class UpdateCustomerHandler(IRepository<Customer> _repository) 
  : ICommandHandler<UpdateCustomerCommand, Result<CustomerDTO>>
{
  public async Task<Result<CustomerDTO>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
  {
    var existingCustomer = await _repository.GetByIdAsync(request.CustomerId, cancellationToken);
    
    if (existingCustomer == null)
    {
      return Result.NotFound();
    }

    // 各項目を更新（指定されていれば）
    if (!string.IsNullOrEmpty(request.NewCompanyName))
      existingCustomer.UpdateCompanyName(request.NewCompanyName);
    
    if (!string.IsNullOrEmpty(request.NewContactPersonName))
      existingCustomer.UpdateContactPersonName(request.NewContactPersonName);
    
    if (!string.IsNullOrEmpty(request.NewPhoneNumber))
      existingCustomer.UpdatePhoneNumber(request.NewPhoneNumber);
    
    if (!string.IsNullOrEmpty(request.NewEmailAddress))
      existingCustomer.UpdateEmailAddress(request.NewEmailAddress);
    
    if (!string.IsNullOrEmpty(request.NewAddress))
      existingCustomer.UpdateAddress(request.NewAddress);
    
    if (!string.IsNullOrEmpty(request.NewNotes))
      existingCustomer.UpdateNotes(request.NewNotes);
    
    if (!string.IsNullOrEmpty(request.NewWebsite))
      existingCustomer.UpdateWebsite(request.NewWebsite);

    await _repository.UpdateAsync(existingCustomer, cancellationToken);

    return new CustomerDTO(
      existingCustomer.Id, 
      existingCustomer.CompanyName, 
      existingCustomer.Status.Name,
      existingCustomer.ContactPersonName, 
      existingCustomer.PhoneNumber, 
      existingCustomer.EmailAddress, 
      existingCustomer.Address, 
      existingCustomer.Notes, 
      existingCustomer.Website);
  }
}
