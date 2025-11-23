using Clean.Architecture.Core.CategoryAggregate;

namespace Clean.Architecture.UseCases.Categories.Update;

/// <summary>
/// UpdateCategoryCommandのハンドラ
/// </summary>
public class UpdateCategoryHandler(IRepository<Category> _repository) : ICommandHandler<UpdateCategoryCommand, Result<CategoryDTO>>
{
  public async Task<Result<CategoryDTO>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
  {
    /// <summary>
    /// カテゴリを取得
    /// </summary>
    var existingCategory = await _repository.GetByIdAsync(request.CategoryId, cancellationToken);
    if (existingCategory == null)
    {
      return Result.NotFound();
    }
    /// <summary>
    /// カテゴリ名を更新
    /// </summary>
    if (!string.IsNullOrEmpty(request.newName))
    {
      existingCategory.UpdateName(request.newName);
    }
    /// <summary>
    /// カテゴリ説明を更新
    /// </summary>
    if (!string.IsNullOrEmpty(request.newDescription))
    {
      existingCategory.UpdateDescription(request.newDescription);
    }

    /// <summary>
    /// カテゴリを更新
    /// </summary>
    await _repository.UpdateAsync(existingCategory, cancellationToken);

    return new CategoryDTO(existingCategory.Id, existingCategory.Name, existingCategory.Description);
  }
}
