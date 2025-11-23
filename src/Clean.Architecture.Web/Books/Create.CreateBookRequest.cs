namespace Clean.Architecture.Web.Books;

public class CreateBookRequest
{
  public const string Route = "/api/Books";
  public string? Title { get; set; }
  public string? Author { get; set; }
  public string? ISBN { get; set; }
  public string? Description { get; set; }
}

