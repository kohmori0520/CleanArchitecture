using Clean.Architecture.UseCases.Books;
using Clean.Architecture.UseCases.Books.List;

namespace Clean.Architecture.Web.Books;

/// <summary>
/// List all Books
/// </summary>
/// <remarks>
/// Returns a list of all Books.
/// </remarks>
public class List(IMediator _mediator)
  : EndpointWithoutRequest<BookListResponse>
{
  public override void Configure()
  {
    Get("/api/Books");
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "List all Books.";
      s.Description = "Returns a list of all Books in the system.";
    });
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListBooksQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new BookListResponse
      {
        Books = result.Value.Select(b => new BookRecord(b.Id, b.Title, b.Author, b.Status, b.ISBN, b.Description)).ToList()
      };
    }
  }
}

