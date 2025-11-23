using Clean.Architecture.UseCases.Categories.Update;

namespace Clean.Architecture.Web.Categories;

public class Update(IMediator _mediator)
  : Endpoint<UpdateCategoryRequest, UpdateCategoryResponse>
{
  public override void Configure()
  {
    Put(UpdateCategoryRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateCategoryRequest request,
    CancellationToken cancellationToken)
    {
      var result = await _mediator.Send(new UpdateCategoryCommand(request.CategoryId, request.Name!, request.Description), cancellationToken);
      if (result.IsSuccess)
      {
        Response = new UpdateCategoryResponse(result.Value);
      }
      else if (result.Status == ResultStatus.NotFound)
      {
        await SendNotFoundAsync(cancellationToken);
        return;
      }
    }
}