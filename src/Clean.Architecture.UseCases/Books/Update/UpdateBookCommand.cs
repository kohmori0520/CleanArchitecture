namespace Clean.Architecture.UseCases.Books.Update;

/// <summary>
/// 本を更新するコマンド
/// </summary>
public record UpdateBookCommand(int BookId, string? NewTitle, string? NewAuthor, string? NewDescription) : Ardalis.SharedKernel.ICommand<Result<BookDTO>>;

