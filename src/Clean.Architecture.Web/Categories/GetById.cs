using Clean.Architecture.UseCases.Categories.Get;

namespace Clean.Architecture.Web.Categories;

public class GetById(IMediator _mediator) : Endpoint<GetCategoryByIdRequest, CategoryRecord>
{
  public override void Configure()
  {
    Get(GetCategoryByIdRequest.Route);
    AllowAnonymous();
    Summary(s => {
      s.Summary = "Get a Category by ID";
      s.Description = "Get a Category by ID";
      s.ExampleRequest = new GetCategoryByIdRequest { CategoryId = 1 };
    });
  }

  public override async Task HandleAsync(
    GetCategoryByIdRequest request,
    CancellationToken cancellationToken)
    {
      var query = new GetCategoryQuery(request.CategoryId);
      var result = await _mediator.Send(query, cancellationToken);
      if (result.Status == ResultStatus.NotFound)
      {
        await SendNotFoundAsync(cancellationToken);
        return;
      }
      if (result.IsSuccess)
      {
        Response = new CategoryRecord(result.Value.Id, result.Value.Name, result.Value.Description);
      }
    }
}