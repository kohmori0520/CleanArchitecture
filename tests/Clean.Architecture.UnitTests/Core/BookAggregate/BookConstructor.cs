using Clean.Architecture.Core.BookAggregate;

namespace Clean.Architecture.UnitTests.Core.BookAggregate;

/// <summary>
/// Bookコンストラクタのテスト
/// </summary>
public class BookConstructor
{
  private readonly string _testTitle = "Clean Architecture";
  private readonly string _testAuthor = "Robert C. Martin";
  private Book? _testBook;

  private Book CreateBook()
  {
    return new Book(_testTitle, _testAuthor);
  }

  [Fact]
  public void InitializesTitle()
  {
    _testBook = CreateBook();

    _testBook.Title.ShouldBe(_testTitle);
  }

  [Fact]
  public void InitializesAuthor()
  {
    _testBook = CreateBook();

    _testBook.Author.ShouldBe(_testAuthor);
  }

  [Fact]
  public void InitializesStatusAsAvailable()
  {
    _testBook = CreateBook();

    _testBook.Status.ShouldBe(BookStatus.Available);
  }

  [Fact]
  public void ThrowsExceptionGivenNullTitle()
  {
    Action action = () => new Book(null!, _testAuthor);

    action.ShouldThrow<ArgumentNullException>();
  }

  [Fact]
  public void ThrowsExceptionGivenNullAuthor()
  {
    Action action = () => new Book(_testTitle, null!);

    action.ShouldThrow<ArgumentNullException>();
  }

  [Fact]
  public void ThrowsExceptionGivenEmptyTitle()
  {
    Action action = () => new Book("", _testAuthor);

    action.ShouldThrow<ArgumentException>();
  }

  [Fact]
  public void ThrowsExceptionGivenEmptyAuthor()
  {
    Action action = () => new Book(_testTitle, "");

    action.ShouldThrow<ArgumentException>();
  }
}

