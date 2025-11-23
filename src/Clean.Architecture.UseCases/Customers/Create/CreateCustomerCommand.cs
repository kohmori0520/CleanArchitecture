namespace Clean.Architecture.UseCases.Customers.Create;

/// <summary>
/// 新しい顧客を作成するコマンド
/// </summary>
/// <param name="CompanyName">会社名</param>
public record CreateCustomerCommand(
    string CompanyName,
    string? ContactPersonName,
    string? PhoneNumber,
    string? EmailAddress,
    string? Address,
    string? Notes,
    string? Website
) : Ardalis.SharedKernel.ICommand<Result<int>>;