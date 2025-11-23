using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Categories;

public class GetCategoryValidator : Validator<GetCategoryByIdRequest>
{
  public GetCategoryValidator()
  {
    RuleFor(x => x.CategoryId)
      .GreaterThan(0);
  }
}