namespace Clean.Architecture.Core.CategoryAggregate.Specifications;

public class CategoryByIdSpec : Specification<Category>
{
  public CategoryByIdSpec(int categoryId)
  {
    Query.Where(category => category.Id == categoryId);
  }
}
