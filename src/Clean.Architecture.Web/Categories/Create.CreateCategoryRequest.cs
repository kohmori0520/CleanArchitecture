using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Categories;

public class CreateCategoryRequest
{
  public const string Route = "/Categories";

  [Required]
  public string? Name { get; set; }
  public string? Description { get; set; }
}