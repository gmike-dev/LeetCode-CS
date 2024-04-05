namespace LeetCode._729._My_Calendar_I;

[TestFixture]
public class MyCalendarListImplTests
{
  [Test]
  public void Test1()
  {
    var calendar = new MyCalendarListImpl();
    calendar.Book(10, 20).Should().BeTrue();
    calendar.Book(15, 25).Should().BeFalse();
    calendar.Book(20, 30).Should().BeTrue();
  }
}
