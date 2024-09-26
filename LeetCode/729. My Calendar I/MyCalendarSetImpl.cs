namespace LeetCode._729._My_Calendar_I;

public class MyCalendarSetImpl
{
  private readonly SortedSet<(int start, int end)> events;

  public MyCalendarSetImpl()
  {
    var comparer = Comparer<(int start, int end)>.Create((x, y) =>
    {
      if (x.end <= y.start)
        return -1;
      if (y.end <= x.start)
        return 1;
      return 0;
    });
    events = new SortedSet<(int start, int end)>(comparer);
  }

  public bool Book(int start, int end)
  {
    return events.Add((start, end));
  }
}

[TestFixture]
public class MyCalendarSetImplTests
{
  [Test]
  public void Test1()
  {
    var calendar = new MyCalendarSetImpl();
    calendar.Book(10, 20).Should().BeTrue();
    calendar.Book(15, 25).Should().BeFalse();
    calendar.Book(20, 30).Should().BeTrue();
  }
}
