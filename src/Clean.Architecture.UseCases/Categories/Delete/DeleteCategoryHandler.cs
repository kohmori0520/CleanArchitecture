using Clean.Architecture.Core.CategoryAggregate;

namespace Clean.Architecture.UseCases.Categories.Delete;

/// <summary>
/// DeleteCategoryCommandのハンドラ
/// </summary>
public class DeleteCategoryHandler(IRepository<Category> _repository) : ICommandHandler<DeleteCategoryCommand, Result>
{
  public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
  {
    /// <summary>
    /// カテゴリを取得
    /// </summary>
    var categoryToDelete = await _repository.GetByIdAsync(request.CategoryId, cancellationToken);

    if (categoryToDelete == null)
    {
      return Result.NotFound();
    }

    /// <summary>
    /// カテゴリを削除
    /// </summary>
    await _repository.DeleteAsync(categoryToDelete, cancellationToken);

    return Result.Success();
  }
}