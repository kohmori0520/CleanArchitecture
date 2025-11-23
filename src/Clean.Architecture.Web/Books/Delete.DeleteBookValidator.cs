using FluentValidation;

namespace Clean.Architecture.Web.Books;

/// <summary>
/// DeleteBookRequestのバリデーション
/// </summary>
public class DeleteBookValidator : Validator<DeleteBookRequest>
{
  public DeleteBookValidator()
  {
    RuleFor(x => x.BookId)
      .GreaterThan(0);
  }
}

