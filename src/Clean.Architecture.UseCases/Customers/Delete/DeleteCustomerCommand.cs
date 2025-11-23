namespace Clean.Architecture.UseCases.Customers.Delete;

/// <summary>
/// 顧客を削除するコマンド
/// </summary>
/// <param name="CustomerId">顧客ID</param>
public record DeleteCustomerCommand(int CustomerId) : Ardalis.SharedKernel.ICommand<Result>;