using Clean.Architecture.UseCases.Categories.Delete;

namespace Clean.Architecture.Web.Categories;

public class Delete(IMediator _mediator) : Endpoint<DeleteCategoryRequest>
{
  public override void Configure()
  {
    Delete(DeleteCategoryRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Delete a Category";
      s.Description = "Delete a Category by its ID";
      s.ExampleRequest = new DeleteCategoryRequest { CategoryId = 1 };
    });
  }

  public override async Task HandleAsync(
    DeleteCategoryRequest request,
    CancellationToken cancellationToken)
    {
      var command = new DeleteCategoryCommand(request.CategoryId);
      var result = await _mediator.Send(command, cancellationToken);
      if (result.IsSuccess)
      {
        await SendNoContentAsync(cancellationToken);
        return;
      } 
      else if (result.Status == ResultStatus.NotFound)
      {
        await SendNotFoundAsync(cancellationToken);
        return;
      }
    }

}