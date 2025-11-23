using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Categories;

public class UpdateCategoryValidator : Validator<UpdateCategoryRequest>
{
  public UpdateCategoryValidator()
  {
    RuleFor(x => x.CategoryId)
      .GreaterThan(0)
      .WithMessage("CategoryId must be greater than 0.");
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2);
    RuleFor(x => x.Description)
      .MaximumLength(200)
      .When(x => !string.IsNullOrEmpty(x.Description))
      .WithMessage("Description must be less than 200 characters.");
  }
}