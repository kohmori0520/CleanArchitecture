using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Customers;

public class DeleteCustomerValidator : Validator<DeleteCustomerRequest>
{
  public DeleteCustomerValidator()
  {
    RuleFor(x => x.CustomerId)
      .GreaterThan(0);
  }
}