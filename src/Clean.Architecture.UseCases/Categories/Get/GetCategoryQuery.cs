namespace Clean.Architecture.UseCases.Categories.Get;

public record GetCategoryQuery(int CategoryId) : Ardalis.SharedKernel.IQuery<Result<CategoryDTO>>;