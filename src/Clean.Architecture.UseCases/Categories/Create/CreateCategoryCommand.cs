namespace Clean.Architecture.UseCases.Categories.Create;

/// <summary>
/// 新しいカテゴリを作成するコマンド
/// </summary>
/// <param name="Name">カテゴリ名</param>
/// <param name="Description">説明（オプション）</param>
public record CreateCategoryCommand(string Name, string? Description) : Ardalis.SharedKernel.ICommand<Result<int>>;