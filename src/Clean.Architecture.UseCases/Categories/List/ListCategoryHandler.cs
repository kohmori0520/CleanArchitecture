using Clean.Architecture.Core.CategoryAggregate;

namespace Clean.Architecture.UseCases.Categories.List;

/// <summary>
/// ListCategoriesQueryのハンドラ
/// </summary>
public class ListCategoryHandler(IRepository<Category> _repository)
  : IQueryHandler<ListCategoriesQuery, Result<IEnumerable<CategoryDTO>>>
{
  public async Task<Result<IEnumerable<CategoryDTO>>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
  {
    var categories = await _repository.ListAsync(cancellationToken);

    var result = categories
      .Select(category => new CategoryDTO(
        category.Id,
        category.Name,
        category.Description))
      .ToList();

    return Result.Success(result.AsEnumerable());
  }
}