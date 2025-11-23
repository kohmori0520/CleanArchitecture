using Clean.Architecture.UseCases.Categories.Create;
namespace Clean.Architecture.Web.Categories;

public class Create(IMediator _mediator) : Endpoint<CreateCategoryRequest, CreateCategoryResponse>
{
  public override void Configure()
  {
    Post(CreateCategoryRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Create a new Category";
      s.Description = "Create a new Category with a name and Description";
      s.ExampleRequest = new CreateCategoryRequest { Name = "Category Name", Description = "Category Description" };
    });
  }

  public override async Task HandleAsync(
    CreateCategoryRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(
      new CreateCategoryCommand(request.Name!, request.Description),
      cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateCategoryResponse(result.Value, request.Name!, request.Description!);
      return;
    }
  }
}