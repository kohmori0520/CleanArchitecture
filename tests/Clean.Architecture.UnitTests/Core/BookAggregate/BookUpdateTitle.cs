using Clean.Architecture.Core.BookAggregate;

namespace Clean.Architecture.UnitTests.Core.BookAggregate;

/// <summary>
/// BookのUpdateTitleメソッドのテスト
/// </summary>
public class BookUpdateTitle
{
  private readonly string _testTitle = "Clean Architecture";
  private readonly string _testAuthor = "Robert C. Martin";
  private readonly string _newTitle = "Clean Code";

  [Fact]
  public void UpdatesTitleSuccessfully()
  {
    var book = new Book(_testTitle, _testAuthor);

    book.UpdateTitle(_newTitle);

    book.Title.ShouldBe(_newTitle);
  }

  [Fact]
  public void ThrowsExceptionGivenNullTitle()
  {
    var book = new Book(_testTitle, _testAuthor);

    Action action = () => book.UpdateTitle(null!);

    action.ShouldThrow<ArgumentNullException>();
  }

  [Fact]
  public void ThrowsExceptionGivenEmptyTitle()
  {
    var book = new Book(_testTitle, _testAuthor);

    Action action = () => book.UpdateTitle("");

    action.ShouldThrow<ArgumentException>();
  }
}

