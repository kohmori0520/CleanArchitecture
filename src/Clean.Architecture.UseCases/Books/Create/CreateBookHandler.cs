using Clean.Architecture.Core.BookAggregate;

namespace Clean.Architecture.UseCases.Books.Create;

/// <summary>
/// CreateBookCommandのハンドラ
/// </summary>
public class CreateBookHandler(IRepository<Book> _repository)
  : ICommandHandler<CreateBookCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateBookCommand request,
    CancellationToken cancellationToken)
  {
    var newBook = new Book(request.Title, request.Author);

    // ISBNが指定されていれば設定
    if (!string.IsNullOrEmpty(request.ISBN))
    {
      newBook.SetISBN(request.ISBN);
    }
    // 説明が指定されていれば設定
    if (!string.IsNullOrEmpty(request.Description))
    {
      newBook.UpdateDescription(request.Description);
    }
    var createdItem = await _repository.AddAsync(newBook, cancellationToken);

    return createdItem.Id;
  }
}

