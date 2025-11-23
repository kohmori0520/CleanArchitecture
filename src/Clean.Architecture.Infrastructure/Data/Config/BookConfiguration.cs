using Clean.Architecture.Core.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Architecture.Infrastructure.Data.Config;

/// <summary>
/// BookエンティティのEntity Framework設定
/// </summary>
public class BookConfiguration : IEntityTypeConfiguration<Book>
{
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    builder.Property(b => b.Title)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.Property(b => b.Author)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    // ISBN Value Objectの設定
    builder.OwnsOne(b => b.ISBN, isbn =>
    {
      isbn.Property(i => i.Value)
        .HasColumnName("ISBN")
        .HasMaxLength(20);
    });

    // BookStatusの設定（Smart Enumを文字列として保存）
    builder.Property(b => b.Status)
      .HasConversion(
        status => status.Name,
        name => BookStatus.FromName(name, false))
      .HasMaxLength(50);

    builder.Property(b => b.PublishedDate)
      .IsRequired(false);
  }
}

