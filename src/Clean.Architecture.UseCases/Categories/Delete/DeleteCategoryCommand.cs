using Clean.Architecture.Core.CategoryAggregate;

namespace Clean.Architecture.UseCases.Categories.Delete;

/// <summary>
/// カテゴリを削除するコマンド
/// </summary>
/// <param name="CategoryId">カテゴリID</param>
public record DeleteCategoryCommand(int CategoryId) : Ardalis.SharedKernel.ICommand<Result>;