using Clean.Architecture.UseCases.Categories;
using Clean.Architecture.UseCases.Categories.List;

namespace Clean.Architecture.Web.Categories;

public class List(IMediator _mediator) : EndpointWithoutRequest<CategoryListResponse>
{
  public override void Configure()
  {
    Get("/Categories");
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "List all Categories";
      s.Description = "List all categories - returns a CategoryListResponse containing the Categories.";
    });
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListCategoriesQuery(), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CategoryListResponse
      {
        Categories = result.Value.Select(c => new CategoryRecord(c.Id, c.Name, c.Description)).ToList()
      };
    }
  }
}