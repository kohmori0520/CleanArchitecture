namespace Clean.Architecture.Web.Books;

public class GetBookByIdRequest
{
  public const string Route = "/api/Books/{BookId:int}";
  public static string BuildRoute(int bookId) => Route.Replace("{BookId:int}", bookId.ToString());

  public int BookId { get; set; }
}

