namespace Clean.Architecture.Web.Customers;

public record CustomerRecord(int Id, string CompanyName, string Status, string? ContactPersonName, string? PhoneNumber, string? EmailAddress, string? Address, string? Notes, string? Website);