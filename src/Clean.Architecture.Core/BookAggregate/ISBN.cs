namespace Clean.Architecture.Core.BookAggregate;

/// <summary>
/// ISBN（国際標準図書番号）を表すValue Object
/// </summary>
public class ISBN : ValueObject
{
  public ISBN(string value)
  {
    Value = Guard.Against.NullOrEmpty(value, nameof(value));

    // ISBNの簡易バリデーション（実際はもっと厳密なチェックが必要）
    var cleanedValue = value.Replace("-", "").Replace(" ", "");

    if (cleanedValue.Length != 10 && cleanedValue.Length != 13)
    {
      throw new ArgumentException("ISBN must be 10 or 13 digits", nameof(value));
    }
  }

  public string Value { get; private set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }

  public override string ToString() => Value;
}

