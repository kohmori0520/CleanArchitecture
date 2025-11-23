namespace Clean.Architecture.UseCases.Categories.List;

public record ListCategoriesQuery : Ardalis.SharedKernel.IQuery<Result<IEnumerable<CategoryDTO>>>;