using Ardalis.SmartEnum;

namespace Clean.Architecture.Core.CustomerAggregate;

public class CompanyStatus : SmartEnum<CompanyStatus>
{
  public static readonly CompanyStatus Active = new(nameof(Active), 1);
  public static readonly CompanyStatus Inactive = new(nameof(Inactive), 2);
  public static readonly CompanyStatus NotSet = new(nameof(NotSet), 0);

  protected CompanyStatus(string name, int value) : base(name, value) { }
}