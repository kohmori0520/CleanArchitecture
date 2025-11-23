using Clean.Architecture.Core.CategoryAggregate;

namespace Clean.Architecture.UseCases.Categories.Update;
/// <summary>
/// カテゴリを更新するコマンド
/// </summary>
/// <param name="CategoryId">カテゴリID</param>
/// <param name="newName">新しいカテゴリ名</param>
/// <param name="newDescription">新しいカテゴリ説明</param>
public record UpdateCategoryCommand(int CategoryId, string newName, string? newDescription) : ICommand<Result<CategoryDTO>>;