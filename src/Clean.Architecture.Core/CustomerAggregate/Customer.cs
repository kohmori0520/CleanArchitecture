using System.Globalization;
using Ardalis.SmartEnum;
namespace Clean.Architecture.Core.CustomerAggregate;

/// <summary>
/// 顧客を表すエンティティ
/// </summary>
public class Customer : EntityBase, IAggregateRoot
{
  /// <summary>
  /// コンストラクタ: 顧客を作成
  /// </summary>
  public Customer(string companyName)
  {
    UpdateCompanyName(companyName);
  }
  // 必須項目
  public string CompanyName { get; private set; } = default!;
  public CompanyStatus Status { get; private set; } = CompanyStatus.NotSet;
  // オプション項目
  public string? ContactPersonName { get; private set; }
  public string? PhoneNumber { get; private set; }
  public string? EmailAddress { get; private set; }
  public string? Address { get; private set; }
  public string? Notes { get; private set; }
  public string? Website { get; private set; }

  /// <summary>
  /// 顧客名を更新
  /// </summary>
  public Customer UpdateCompanyName(string newName)
  {
    CompanyName = Guard.Against.NullOrEmpty(newName, nameof(newName));
    return this;
  }

  /// <summary>
  /// 顧客状態を更新
  /// </summary>
  public Customer UpdateStatus(CompanyStatus newStatus)
  {
    Status = Guard.Against.Null(newStatus, nameof(newStatus));
    return this;
  }

  /// <summary>
  /// 連絡先名を更新
  /// </summary>
  public Customer UpdateContactPersonName(string? newContactPersonName)
  {
    ContactPersonName = newContactPersonName;
    return this;
  }

  /// <summary>
  /// 電話番号を更新
  /// </summary>
  public Customer UpdatePhoneNumber(string? newPhoneNumber)
  {
    PhoneNumber = newPhoneNumber;
    return this;
  }

  /// <summary>
  /// メールアドレスを更新
  /// </summary>
  public Customer UpdateEmailAddress(string? newEmailAddress)
  {
    EmailAddress = newEmailAddress;
    return this;
  }

  /// <summary>
  /// 住所を更新
  /// </summary>
  public Customer UpdateAddress(string? newAddress)
  {
    Address = newAddress;
    return this;
  }

  /// <summary>
  /// 備考を更新
  /// </summary>
  public Customer UpdateNotes(string? newNotes)
  {
    Notes = newNotes;
    return this;
  }

  /// <summary>
  /// ウェブサイトを更新
  /// </summary>
  public Customer UpdateWebsite(string? newWebsite)
  {
    Website = newWebsite;
    return this;
  }
}