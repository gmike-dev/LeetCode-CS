namespace LeetCode._2054._Two_Best_Non_Overlapping_Events;

public class BinarySearchSolution2
{
  private record struct Event(int StartTime, int EndTime, int Value);

  public int MaxTwoEvents(int[][] events)
  {
    var n = events.Length;
    Span<Event> sortedEvents = stackalloc Event[n];
    for (var i = 0; i < n; i++)
      sortedEvents[i] = new Event(events[i][0], events[i][1], events[i][2]);
    sortedEvents.Sort(ByEndTime);

    var maxValue = new int[n];
    maxValue[0] = sortedEvents[0].Value;
    for (var i = 1; i < n; i++)
      maxValue[i] = Math.Max(sortedEvents[i].Value, maxValue[i - 1]);

    var result = maxValue[0];
    for (var i = 1; i < n; i++)
    {
      var value = sortedEvents[i].Value;
      var prev = FindLastEvent(sortedEvents, i);
      if (prev >= 0)
        value += maxValue[prev];
      result = Math.Max(result, value);
    }
    return result;

    int ByEndTime(Event x, Event y)
    {
      return x.EndTime - y.EndTime;
    }

    int FindLastEvent(Span<Event> sortedEvents, int i)
    {
      var l = 0;
      var r = i - 1;
      var start = sortedEvents[i].StartTime;
      while (l <= r)
      {
        var m = l + (r - l) / 2;
        if (sortedEvents[m].EndTime < start)
          l = m + 1;
        else
          r = m - 1;
      }
      return r;
    }
  }
}

[TestFixture]
public class BinarySearchSolution2Tests
{
  [Test]
  public void Test1()
  {
    new BinarySearchSolution2().MaxTwoEvents([
      [1, 3, 2],
      [4, 5, 2],
      [2, 4, 3]
    ]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new BinarySearchSolution2().MaxTwoEvents([
      [1, 3, 2],
      [4, 5, 2],
      [1, 5, 5]
    ]).Should().Be(5);
  }

  [Test]
  public void Test3()
  {
    new BinarySearchSolution2().MaxTwoEvents([
      [1, 5, 3],
      [1, 5, 1],
      [6, 6, 5]
    ]).Should().Be(8);
  }
}
