using Clean.Architecture.Core.BookAggregate;

namespace Clean.Architecture.UnitTests.Core.BookAggregate;

/// <summary>
/// BookのUpdateDescriptionメソッドのテスト
/// </summary>
public class BookUpdateDescription
{
  private readonly string _testTitle = "Clean Architecture";
  private readonly string _testAuthor = "Robert C. Martin";
  private readonly string _testDescription = "A book about clean architecture principles and practices.";
  private readonly string _newDescription = "Updated description about clean code and architecture.";

  [Fact]
  public void UpdatesDescriptionSuccessfully()
  {
    var book = new Book(_testTitle, _testAuthor);

    book.UpdateDescription(_testDescription);

    book.Description.ShouldBe(_testDescription);
  }

  [Fact]
  public void UpdatesDescriptionMultipleTimes()
  {
    var book = new Book(_testTitle, _testAuthor);
    book.UpdateDescription(_testDescription);

    book.UpdateDescription(_newDescription);

    book.Description.ShouldBe(_newDescription);
  }

  [Fact]
  public void ThrowsExceptionGivenNullDescription()
  {
    var book = new Book(_testTitle, _testAuthor);

    Action action = () => book.UpdateDescription(null!);

    action.ShouldThrow<ArgumentNullException>();
  }

  [Fact]
  public void ThrowsExceptionGivenEmptyDescription()
  {
    var book = new Book(_testTitle, _testAuthor);

    Action action = () => book.UpdateDescription("");

    action.ShouldThrow<ArgumentException>();
  }

  [Fact]
  public void ReturnsBookForFluentInterface()
  {
    var book = new Book(_testTitle, _testAuthor);

    var result = book.UpdateDescription(_testDescription);

    result.ShouldBe(book);
  }

  [Fact]
  public void AllowsMethodChaining()
  {
    var book = new Book(_testTitle, _testAuthor);

    var result = book
      .UpdateDescription(_testDescription)
      .MarkAsLent();

    result.Description.ShouldBe(_testDescription);
    result.Status.ShouldBe(BookStatus.Lent);
  }
}

