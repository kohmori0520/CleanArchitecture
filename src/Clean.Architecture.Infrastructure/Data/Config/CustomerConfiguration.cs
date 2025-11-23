using Clean.Architecture.Core.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Architecture.Infrastructure.Data.Config;

/// <summary>
/// CustomerエンティティのEntity Framework設定
/// </summary>
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
  public void Configure(EntityTypeBuilder<Customer> builder)
  {
    builder.Property(c => c.CompanyName)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    // CompanyStatusの設定（Smart Enumを文字列として保存）
    builder.Property(c => c.Status)
      .HasConversion(
        status => status.Name,
        name => CompanyStatus.FromName(name, false))
      .HasMaxLength(50);

    // オプション項目
    builder.Property(c => c.ContactPersonName)
      .HasMaxLength(100)
      .IsRequired(false);

    builder.Property(c => c.PhoneNumber)
      .HasMaxLength(50)
      .IsRequired(false);

    builder.Property(c => c.EmailAddress)
      .HasMaxLength(200)
      .IsRequired(false);

    builder.Property(c => c.Address)
      .HasMaxLength(500)
      .IsRequired(false);

    builder.Property(c => c.Notes)
      .HasMaxLength(2000)
      .IsRequired(false);

    builder.Property(c => c.Website)
      .HasMaxLength(200)
      .IsRequired(false);
  }
}

