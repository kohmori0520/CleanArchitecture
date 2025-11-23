using Clean.Architecture.Core.BookAggregate;

namespace Clean.Architecture.UseCases.Books.Update;

/// <summary>
/// UpdateBookCommandのハンドラ
/// </summary>
public class UpdateBookHandler(IRepository<Book> _repository)
  : ICommandHandler<UpdateBookCommand, Result<BookDTO>>
{
  public async Task<Result<BookDTO>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
  {
    var existingBook = await _repository.GetByIdAsync(request.BookId, cancellationToken);
    
    if (existingBook == null)
    {
      return Result.NotFound();
    }

    // タイトルが指定されていれば更新
    if (!string.IsNullOrEmpty(request.NewTitle))
    {
      existingBook.UpdateTitle(request.NewTitle);
    }

    // 著者が指定されていれば更新
    if (!string.IsNullOrEmpty(request.NewAuthor))
    {
      existingBook.UpdateAuthor(request.NewAuthor);
    }

    // 説明が指定されていれば更新
    if (!string.IsNullOrEmpty(request.NewDescription))
    {
      existingBook.UpdateDescription(request.NewDescription);
    }

    await _repository.UpdateAsync(existingBook, cancellationToken);

    return new BookDTO(
      existingBook.Id,
      existingBook.Title,
      existingBook.Author,
      existingBook.Status.Name,
      existingBook.ISBN?.Value,
      existingBook.Description
      );
  }
}

