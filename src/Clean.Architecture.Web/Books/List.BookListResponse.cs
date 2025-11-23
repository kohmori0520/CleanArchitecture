using Clean.Architecture.UseCases.Books;

namespace Clean.Architecture.Web.Books;

public class BookListResponse
{
  public List<BookRecord> Books { get; set; } = [];
}

