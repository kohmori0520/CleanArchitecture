using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Customers;

public class GetCustomerValidator : Validator<GetCustomerByIdRequest>
{
  public GetCustomerValidator()
  {
    RuleFor(x => x.CustomerId)
      .GreaterThan(0);
  }
}