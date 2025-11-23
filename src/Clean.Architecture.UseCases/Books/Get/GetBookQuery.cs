namespace Clean.Architecture.UseCases.Books.Get;

/// <summary>
/// IDで本を取得するクエリ
/// </summary>
public record GetBookQuery(int BookId) : Ardalis.SharedKernel.IQuery<Result<BookDTO>>;

