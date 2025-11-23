using Clean.Architecture.Core.CustomerAggregate;

namespace Clean.Architecture.UseCases.Customers.Delete;

/// <summary>
/// DeleteCustomerCommandのハンドラ
/// </summary>
public class DeleteCustomerHandler(IRepository<Customer> _repository)
  : ICommandHandler<DeleteCustomerCommand, Result>
{
  public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
  {
    var customerToDelete = await _repository.GetByIdAsync(request.CustomerId, cancellationToken);

    if (customerToDelete == null)
    {
      return Result.NotFound();
    }

    await _repository.DeleteAsync(customerToDelete, cancellationToken);

    return Result.Success();
  }
}