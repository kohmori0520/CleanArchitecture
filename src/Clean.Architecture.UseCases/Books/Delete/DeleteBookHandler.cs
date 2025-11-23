using Clean.Architecture.Core.BookAggregate;

namespace Clean.Architecture.UseCases.Books.Delete;

/// <summary>
/// DeleteBookCommandのハンドラ
/// </summary>
public class DeleteBookHandler(IRepository<Book> _repository)
  : ICommandHandler<DeleteBookCommand, Result>
{
  public async Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
  {
    var bookToDelete = await _repository.GetByIdAsync(request.BookId, cancellationToken);
    
    if (bookToDelete == null)
    {
      return Result.NotFound();
    }

    await _repository.DeleteAsync(bookToDelete, cancellationToken);

    return Result.Success();
  }
}

