namespace Clean.Architecture.UseCases.Customers.Get;

public record GetCustomerQuery(int CustomerId) : Ardalis.SharedKernel.IQuery<Result<CustomerDTO>>;