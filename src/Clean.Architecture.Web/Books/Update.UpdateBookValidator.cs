using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Books;

/// <summary>
/// UpdateBookRequestのバリデーション
/// </summary>
public class UpdateBookValidator : Validator<UpdateBookRequest>
{
  public UpdateBookValidator()
  {
    RuleFor(x => x.BookId)
      .GreaterThan(0);

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

    RuleFor(x => x.Description)
      .MinimumLength(1)
      .MaximumLength(1000)
      .When(x => !string.IsNullOrEmpty(x.Description))
      .WithMessage("Description is must be longer than 1 character and less than 1000 characters");
  }
}
