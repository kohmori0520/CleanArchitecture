using Clean.Architecture.Core.CustomerAggregate;
using Clean.Architecture.Core.CustomerAggregate.Specifications;

namespace Clean.Architecture.UseCases.Customers.Get;

/// <summary>
/// GetCustomerQueryのハンドラ
/// </summary>
public class GetCustomerHandler(IReadRepository<Customer> _repository)
  : IQueryHandler<GetCustomerQuery, Result<CustomerDTO>>
{
  public async Task<Result<CustomerDTO>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
  {
    var spec = new CustomerByIdSpec(request.CustomerId);
    var customer = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

    if (customer == null)
    {
      return Result.NotFound();
    }

    return new CustomerDTO(
      customer.Id,
      customer.CompanyName,
      customer.Status.Name,  // CompanyStatus → string
      customer.ContactPersonName,
      customer.PhoneNumber,
      customer.EmailAddress,
      customer.Address,
      customer.Notes,
      customer.Website);
  }
}