using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Books;

/// <summary>
/// CreateBookRequestのバリデーション
/// </summary>
public class CreateBookValidator : Validator<CreateBookRequest>
{
  public CreateBookValidator()
  {
    RuleFor(x => x.Title)
      .NotEmpty()
      .WithMessage("Title is required.")
      .MinimumLength(1)
      .MaximumLength(200);

    RuleFor(x => x.Author)
      .NotEmpty()
      .WithMessage("Author is required.")
      .MinimumLength(1)
      .MaximumLength(100);

    RuleFor(x => x.ISBN)
      .Must(isbn => string.IsNullOrEmpty(isbn) || isbn.Replace("-", "").Replace(" ", "").Length == 10 || isbn.Replace("-", "").Replace(" ", "").Length == 13)
      .When(x => !string.IsNullOrEmpty(x.ISBN))
      .WithMessage("ISBN must be 10 or 13 digits.");

    RuleFor(x => x.Description)
      .NotEmpty()
      .WithMessage("Description is required.")
      .MinimumLength(1)
      .MaximumLength(1000);
  }
}

