using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Categories;

public class CreateCategoryValidator : Validator<CreateCategoryRequest>
{
  public CreateCategoryValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(1)
      .MaximumLength(100);
    RuleFor(x => x.Description)
      .MaximumLength(200)
      .When(x => !string.IsNullOrEmpty(x.Description))
      .WithMessage("Description must be less than 200 characters.");
  }
}