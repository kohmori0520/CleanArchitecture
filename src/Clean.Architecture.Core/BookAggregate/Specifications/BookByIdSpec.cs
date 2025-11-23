namespace Clean.Architecture.Core.BookAggregate.Specifications;

/// <summary>
/// IDで本を検索するSpecification
/// </summary>
public class BookByIdSpec : Specification<Book>
{
  public BookByIdSpec(int bookId)
  {
    Query.Where(book => book.Id == bookId);
  }
}

