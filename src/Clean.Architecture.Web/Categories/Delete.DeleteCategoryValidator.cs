using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Categories;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class DeleteCategoryValidator : Validator<DeleteCategoryRequest>
{
  public DeleteCategoryValidator()
  {
    RuleFor(x => x.CategoryId)
      .GreaterThan(0);
  }
}