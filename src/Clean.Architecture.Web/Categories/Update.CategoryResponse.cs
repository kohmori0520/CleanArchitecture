using Clean.Architecture.UseCases.Categories;

namespace Clean.Architecture.Web.Categories;

public class UpdateCategoryResponse(CategoryDTO category)
{
  public CategoryDTO Category { get; set; } = category;
}