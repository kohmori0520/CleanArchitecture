namespace Clean.Architecture.Core.CategoryAggregate;

/// <summary>
/// 本のカテゴリを表すエンティティ
/// </summary>
public class Category : EntityBase, IAggregateRoot
{
  /// <summary>
  /// コンストラクタ: カテゴリを作成
  /// </summary>
  public Category(string name, string? description = null)
  {
    UpdateName(name);
    if (!string.IsNullOrEmpty(description))
    {
      UpdateDescription(description);
    }
  }

  public string Name { get; private set; } = default!;
  public string? Description { get; private set; }

  /// <summary>
  /// カテゴリ名を更新
  /// </summary>
  public Category UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
    return this;
  }

  /// <summary>
  /// 説明を更新（nullを許可）
  /// </summary>
  public Category UpdateDescription(string? newDescription)
  {
    Description = newDescription;
    return this;
  }



}