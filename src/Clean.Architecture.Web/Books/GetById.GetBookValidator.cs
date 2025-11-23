using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Books;

/// <summary>
/// GetBookByIdRequestのバリデーション
/// </summary>
public class GetBookValidator : Validator<GetBookByIdRequest>
{
  public GetBookValidator()
  {
    RuleFor(x => x.BookId)
      .GreaterThan(0);
  }
}

