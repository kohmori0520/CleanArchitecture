using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Books;

public class UpdateBookRequest
{
  public const string Route = "/api/Books/{BookId:int}";
  public static string BuildRoute(int bookId) => Route.Replace("{BookId:int}", bookId.ToString());

  public int BookId { get; set; }
  
  [Required]
  public string? Title { get; set; }
  
  [Required]
  public string? Author { get; set; }

  [MaxLength(1000)]
  public string? Description { get; set; }
}

