namespace Clean.Architecture.UseCases.Customers.List;

public record ListCustomersQuery : Ardalis.SharedKernel.IQuery<Result<IEnumerable<CustomerDTO>>>;