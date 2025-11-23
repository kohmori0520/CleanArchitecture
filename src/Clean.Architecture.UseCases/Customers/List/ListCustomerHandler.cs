using Clean.Architecture.Core.CustomerAggregate;

namespace Clean.Architecture.UseCases.Customers.List;

/// <summary>
/// ListCustomersQueryのハンドラ
/// </summary>
public class ListCustomerHandler(IRepository<Customer> _repository)
  : IQueryHandler<ListCustomersQuery, Result<IEnumerable<CustomerDTO>>>
{
  public async Task<Result<IEnumerable<CustomerDTO>>> Handle(ListCustomersQuery request, CancellationToken cancellationToken)
  {
    var customers = await _repository.ListAsync(cancellationToken);

    var result = customers
      .Select(customer => new CustomerDTO(
        customer.Id,
        customer.CompanyName,
        customer.Status.Name,  // CompanyStatus → string
        customer.ContactPersonName,
        customer.PhoneNumber,
        customer.EmailAddress,
        customer.Address,
        customer.Notes,
        customer.Website))
      .ToList();

    return Result.Success(result.AsEnumerable());
  }
}