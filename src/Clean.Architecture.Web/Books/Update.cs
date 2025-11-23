using Clean.Architecture.UseCases.Books.Update;

namespace Clean.Architecture.Web.Books;

/// <summary>
/// Update a Book
/// </summary>
/// <remarks>
/// Updates a Book's title and author.
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdateBookRequest, UpdateBookResponse>
{
  public override void Configure()
  {
    Put(UpdateBookRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Update a Book.";
      s.Description = "Updates a Book's title and author.";
      s.ExampleRequest = new UpdateBookRequest
      {
        BookId = 1,
        Title = "Clean Code",
        Author = "Robert C. Martin",
        Description = "A book about clean code"
      };
    });
  }

  public override async Task HandleAsync(
    UpdateBookRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(
      new UpdateBookCommand(request.BookId, request.Title, request.Author, request.Description),
      cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new UpdateBookResponse(result.Value);
    }
  }
}

