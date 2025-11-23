using Clean.Architecture.Core.BookAggregate;

namespace Clean.Architecture.UnitTests.Core.BookAggregate;

/// <summary>
/// Bookのステータス変更メソッドのテスト
/// </summary>
public class BookStatusChange
{
  private readonly string _testTitle = "Clean Architecture";
  private readonly string _testAuthor = "Robert C. Martin";

  [Fact]
  public void MarksBookAsLent()
  {
    var book = new Book(_testTitle, _testAuthor);

    book.MarkAsLent();

    book.Status.ShouldBe(BookStatus.Lent);
  }

  [Fact]
  public void MarksBookAsAvailable()
  {
    var book = new Book(_testTitle, _testAuthor);
    book.MarkAsLent();

    book.MarkAsAvailable();

    book.Status.ShouldBe(BookStatus.Available);
  }

  [Fact]
  public void MarksBookAsReserved()
  {
    var book = new Book(_testTitle, _testAuthor);

    book.MarkAsReserved();

    book.Status.ShouldBe(BookStatus.Reserved);
  }
}

