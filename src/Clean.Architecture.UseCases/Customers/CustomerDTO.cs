namespace Clean.Architecture.UseCases.Customers;

public record CustomerDTO(
    int Id,
    string CompanyName,
    string Status,
    string? ContactPersonName,
    string? PhoneNumber,
    string? EmailAddress,
    string? Address,
    string? Notes,
    string? Website);