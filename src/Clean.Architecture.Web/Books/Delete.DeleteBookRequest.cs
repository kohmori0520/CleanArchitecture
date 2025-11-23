namespace Clean.Architecture.Web.Books;

public class DeleteBookRequest
{
  public const string Route = "/api/Books/{BookId:int}";
  public static string BuildRoute(int bookId) => Route.Replace("{BookId:int}", bookId.ToString());

  public int BookId { get; set; }
}

