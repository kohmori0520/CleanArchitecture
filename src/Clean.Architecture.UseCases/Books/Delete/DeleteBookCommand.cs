namespace Clean.Architecture.UseCases.Books.Delete;

/// <summary>
/// 本を削除するコマンド
/// </summary>
public record DeleteBookCommand(int BookId) : Ardalis.SharedKernel.ICommand<Result>;

