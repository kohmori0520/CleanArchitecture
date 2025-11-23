using Clean.Architecture.Core.CategoryAggregate;
using Clean.Architecture.Core.CategoryAggregate.Specifications;

namespace Clean.Architecture.UseCases.Categories.Get;

/// <summary>
/// GetCategoryQueryのハンドラ
/// </summary>
public class GetCategoryHandler(IReadRepository<Category> _repository)
  : IQueryHandler<GetCategoryQuery, Result<CategoryDTO>>
{
  public async Task<Result<CategoryDTO>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
  {
    var spec = new CategoryByIdSpec(request.CategoryId);
    var category = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

    if (category == null)
    {
      return Result.NotFound();
    }

    return new CategoryDTO(category.Id, category.Name, category.Description);
  }
}