namespace Clean.Architecture.UseCases.Books;

public record BookDTO(int Id, string Title, string Author, string Status, string? ISBN, string? Description);

