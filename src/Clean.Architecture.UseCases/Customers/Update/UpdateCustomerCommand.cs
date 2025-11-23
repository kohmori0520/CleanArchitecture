namespace Clean.Architecture.UseCases.Customers.Update;

/// <summary>
/// 顧客を更新するコマンド
/// </summary>
public record UpdateCustomerCommand(
    int CustomerId,
    string? NewCompanyName,
    string? NewContactPersonName,
    string? NewPhoneNumber,
    string? NewEmailAddress,
    string? NewAddress,
    string? NewNotes,
    string? NewWebsite
) : Ardalis.SharedKernel.ICommand<Result<CustomerDTO>>;