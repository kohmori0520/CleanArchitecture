using Clean.Architecture.UseCases.Books.Get;

namespace Clean.Architecture.Web.Books;

/// <summary>
/// Get a Book by ID
/// </summary>
/// <remarks>
/// Returns a single Book by its ID.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetBookByIdRequest, BookRecord>
{
  public override void Configure()
  {
    Get(GetBookByIdRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Get a Book by ID.";
      s.Description = "Returns a single Book by its ID.";
    });
  }

  public override async Task HandleAsync(
    GetBookByIdRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new GetBookQuery(request.BookId), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new BookRecord(
        result.Value.Id,
        result.Value.Title,
        result.Value.Author,
        result.Value.Status,
        result.Value.ISBN,
        result.Value.Description);
    }
  }
}

