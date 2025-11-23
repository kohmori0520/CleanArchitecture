using Clean.Architecture.Core.BookAggregate;
using Clean.Architecture.Core.BookAggregate.Specifications;

namespace Clean.Architecture.UseCases.Books.Get;

/// <summary>
/// GetBookQueryのハンドラ
/// </summary>
public class GetBookHandler(IRepository<Book> _repository)
  : IQueryHandler<GetBookQuery, Result<BookDTO>>
{
  public async Task<Result<BookDTO>> Handle(GetBookQuery request, CancellationToken cancellationToken)
  {
    var spec = new BookByIdSpec(request.BookId);
    var book = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    
    if (book == null)
    {
      return Result.NotFound();
    }

    return new BookDTO(
      book.Id,
      book.Title,
      book.Author,
      book.Status.Name,
      book.ISBN?.Value,
      book.Description);
  }
}

