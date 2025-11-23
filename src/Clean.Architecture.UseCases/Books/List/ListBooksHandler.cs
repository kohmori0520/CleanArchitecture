using Clean.Architecture.Core.BookAggregate;

namespace Clean.Architecture.UseCases.Books.List;

/// <summary>
/// ListBooksQueryのハンドラ
/// </summary>
public class ListBooksHandler(IRepository<Book> _repository)
  : IQueryHandler<ListBooksQuery, Result<IEnumerable<BookDTO>>>
{
  public async Task<Result<IEnumerable<BookDTO>>> Handle(ListBooksQuery request, CancellationToken cancellationToken)
  {
    var books = await _repository.ListAsync(cancellationToken);
    
    var result = books
      .Select(book => new BookDTO(
        book.Id,
        book.Title,
        book.Author,
        book.Status.Name,
        book.ISBN?.Value,
        book.Description))
      .ToList();

    return Result.Success(result.AsEnumerable());
  }
}

