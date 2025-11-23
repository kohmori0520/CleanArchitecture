namespace Clean.Architecture.UseCases.Books.List;

/// <summary>
/// 本の一覧を取得するクエリ
/// </summary>
public record ListBooksQuery(int? Skip, int? Take) : Ardalis.SharedKernel.IQuery<Result<IEnumerable<BookDTO>>>;

