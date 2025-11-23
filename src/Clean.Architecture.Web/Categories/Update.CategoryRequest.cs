using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Categories;

public class UpdateCategoryRequest
{
  public const string Route = "/Categories/{CategoryId:int}";
  public static string BuildRoute(int categoryId) => Route.Replace("{CategoryId:int}", categoryId.ToString());

  public int CategoryId { get; set; }
  [Required]
  public string? Name { get; set; }
  public string? Description { get; set; }
}