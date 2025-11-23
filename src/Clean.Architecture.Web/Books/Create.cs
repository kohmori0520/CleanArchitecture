using Clean.Architecture.UseCases.Books.Create;

namespace Clean.Architecture.Web.Books;

/// <summary>
/// Create a new Book
/// </summary>
/// <remarks>
/// Creates a new Book given a title and author.
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreateBookRequest, CreateBookResponse>
{
  public override void Configure()
  {
    Post(CreateBookRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Create a new Book.";
      s.Description = "Create a new Book. A valid title and author are required.";
      s.ExampleRequest = new CreateBookRequest
      {
        Title = "Clean Architecture",
        Author = "Robert C. Martin",
        ISBN = "978-0134494166",
        Description = "A book about clean architecture"
      };
    });
  }

  public override async Task HandleAsync(
    CreateBookRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(
      new CreateBookCommand(request.Title!, request.Author!, request.ISBN, request.Description!),
      cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateBookResponse(result.Value, request.Title!, request.Author!, request.Description!);
      return;
    }

    // TODO: Handle other cases as necessary
  }
}

