using Clean.Architecture.Core.BookAggregate;

namespace Clean.Architecture.UseCases.Books.Create;

/// <summary>
/// 新しい本を作成するコマンド
/// </summary>
/// <param name="Title">本のタイトル</param>
/// <param name="Author">著者名</param>
/// <param name="ISBN">ISBN（オプション）</param>
public record CreateBookCommand(string Title, string Author, string? ISBN, string? Description) : Ardalis.SharedKernel.ICommand<Result<int>>;

