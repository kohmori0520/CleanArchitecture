using Clean.Architecture.UseCases.Books.Delete;

namespace Clean.Architecture.Web.Books;

/// <summary>
/// Delete a Book
/// </summary>
/// <remarks>
/// Deletes a Book by its ID.
/// </remarks>
public class Delete(IMediator _mediator)
  : Endpoint<DeleteBookRequest>
{
  public override void Configure()
  {
    Delete(DeleteBookRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Delete a Book.";
      s.Description = "Deletes a Book by its ID.";
    });
  }

  public override async Task HandleAsync(
    DeleteBookRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(
      new DeleteBookCommand(request.BookId),
      cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    }
  }
}

