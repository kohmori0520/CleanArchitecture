namespace Clean.Architecture.Core.BookAggregate;

/// <summary>
/// 本の状態を表すSmart Enum
/// </summary>
public class BookStatus : SmartEnum<BookStatus>
{
  public static readonly BookStatus Available = new(nameof(Available), 1);
  public static readonly BookStatus Lent = new(nameof(Lent), 2);
  public static readonly BookStatus Reserved = new(nameof(Reserved), 3);
  public static readonly BookStatus NotSet = new(nameof(NotSet), 0);

  protected BookStatus(string name, int value) : base(name, value) { }
}

