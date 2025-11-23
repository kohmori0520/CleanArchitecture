using Clean.Architecture.Core.BookAggregate;

namespace Clean.Architecture.UnitTests.Core.BookAggregate;

/// <summary>
/// BookのSetISBNメソッドのテスト
/// </summary>
public class BookSetISBN
{
  private readonly string _testTitle = "Clean Architecture";
  private readonly string _testAuthor = "Robert C. Martin";
  private readonly string _validISBN13 = "9780134494166";
  private readonly string _validISBN10 = "0134494164";

  [Fact]
  public void SetsISBN13Successfully()
  {
    var book = new Book(_testTitle, _testAuthor);

    book.SetISBN(_validISBN13);

    book.ISBN.ShouldNotBeNull();
    book.ISBN.Value.ShouldBe(_validISBN13);
  }

  [Fact]
  public void SetsISBN10Successfully()
  {
    var book = new Book(_testTitle, _testAuthor);

    book.SetISBN(_validISBN10);

    book.ISBN.ShouldNotBeNull();
    book.ISBN.Value.ShouldBe(_validISBN10);
  }

  [Fact]
  public void ThrowsExceptionGivenInvalidISBNLength()
  {
    var book = new Book(_testTitle, _testAuthor);

    Action action = () => book.SetISBN("123456");

    action.ShouldThrow<ArgumentException>();
  }

  [Fact]
  public void ThrowsExceptionGivenNullISBN()
  {
    var book = new Book(_testTitle, _testAuthor);

    Action action = () => book.SetISBN(null!);

    action.ShouldThrow<ArgumentNullException>();
  }
}

