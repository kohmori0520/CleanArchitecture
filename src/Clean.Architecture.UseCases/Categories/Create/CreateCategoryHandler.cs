using Clean.Architecture.Core.CategoryAggregate;

namespace Clean.Architecture.UseCases.Categories.Create;

/// <summary>
/// CreateCategoryCommandのハンドラ
/// </summary>
public class CreateCategoryHandler(IRepository<Category> _repository)
  : ICommandHandler<CreateCategoryCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
  {
    var newCategory = new Category(request.Name, request.Description);
    var createdItem = await _repository.AddAsync(newCategory, cancellationToken);

    return createdItem.Id;
  }
}