namespace Clean.Architecture.Core.BookAggregate;

/// <summary>
/// 本を表すエンティティ
/// </summary>
public class Book : EntityBase, IAggregateRoot
{
  /// <summary>
  /// コンストラクタ: 必須項目で初期化
  /// </summary>
  public Book(string title, string author)
  {
    UpdateTitle(title);
    UpdateAuthor(author);
  }

  public string Title { get; private set; } = default!;
  public string Author { get; private set; } = default!;
  public BookStatus Status { get; private set; } = BookStatus.Available;
  public ISBN? ISBN { get; private set; }
  public string? Description { get; private set; }
  public DateTime? PublishedDate { get; private set; }

  /// <summary>
  /// タイトルを更新
  /// </summary>
  public Book UpdateTitle(string newTitle)
  {
    Title = Guard.Against.NullOrEmpty(newTitle, nameof(newTitle));
    return this;
  }

  /// <summary>
  /// 著者を更新
  /// </summary>
  public Book UpdateAuthor(string newAuthor)
  {
    Author = Guard.Against.NullOrEmpty(newAuthor, nameof(newAuthor));
    return this;
  }

  /// <summary>
  /// ISBNを設定
  /// </summary>
  public Book SetISBN(string isbnValue)
  {
    ISBN = new ISBN(isbnValue);
    return this;
  }

  /// <summary>
  /// 出版日を設定
  /// </summary>
  public Book SetPublishedDate(DateTime publishedDate)
  {
    PublishedDate = publishedDate;
    return this;
  }

  /// <summary>
  /// 本を貸し出す
  /// </summary>
  public Book MarkAsLent()
  {
    Status = BookStatus.Lent;
    return this;
  }

  /// <summary>
  /// 本を利用可能にする
  /// </summary>
  public Book MarkAsAvailable()
  {
    Status = BookStatus.Available;
    return this;
  }

  /// <summary>
  /// 本を予約済みにする
  /// </summary>
  public Book MarkAsReserved()
  {
    Status = BookStatus.Reserved;
    return this;
  }

  /// <summary>
  /// 説明を更新
  /// </summary>

  public Book UpdateDescription(string newDescription)
  {
    Description = Guard.Against.NullOrEmpty(newDescription, nameof(newDescription));
    return this;
  }
}
