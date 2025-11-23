using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Customers;

public class CreateCustomerValidator : Validator<CreateCustomerRequest>
{
  public CreateCustomerValidator()
  {
    RuleFor(x => x.CompanyName)
      .NotEmpty()
      .WithMessage("Company name is required.")
      .MinimumLength(1)
      .MaximumLength(100);
    RuleFor(x => x.ContactPersonName)
      .MaximumLength(100)
      .When(x => !string.IsNullOrEmpty(x.ContactPersonName))
      .WithMessage("Contact person name must be less than 100 characters.");
    RuleFor(x => x.PhoneNumber)
      .MaximumLength(20)
      .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
      .WithMessage("Phone number must be less than 20 characters.");
    RuleFor(x => x.EmailAddress)
      .MaximumLength(100)
      .When(x => !string.IsNullOrEmpty(x.EmailAddress))
      .WithMessage("Email address must be less than 100 characters.");
    RuleFor(x => x.Address)
      .MaximumLength(200)
      .When(x => !string.IsNullOrEmpty(x.Address))
      .WithMessage("Address must be less than 200 characters.");
    RuleFor(x => x.Notes)
      .MaximumLength(1000)
      .When(x => !string.IsNullOrEmpty(x.Notes))
      .WithMessage("Notes must be less than 1000 characters.");
    RuleFor(x => x.Website)
      .MaximumLength(200)
      .When(x => !string.IsNullOrEmpty(x.Website))
      .WithMessage("Website must be less than 200 characters.");
  }
}