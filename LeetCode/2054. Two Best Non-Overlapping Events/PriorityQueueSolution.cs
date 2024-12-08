namespace LeetCode._2054._Two_Best_Non_Overlapping_Events;

public class PriorityQueueSolution
{
  private record struct Event(int StartTime, int EndTime, int Value);

  public int MaxTwoEvents(int[][] events)
  {
    var n = events.Length;
    Span<Event> sortedEvents = stackalloc Event[n];
    for (var i = 0; i < n; i++)
      sortedEvents[i] = new Event(events[i][0], events[i][1], events[i][2]);
    sortedEvents.Sort((x, y) => x.StartTime - y.StartTime);
    var q = new PriorityQueue<int, int>();
    var maxVal = 0;
    var maxSum = 0;
    foreach (var e in sortedEvents)
    {
      while (q.TryPeek(out var value, out var endTime) && endTime < e.StartTime)
      {
        maxVal = Math.Max(maxVal, value);
        q.Dequeue();
      }
      maxSum = Math.Max(maxSum, maxVal + e.Value);
      q.Enqueue(e.Value, e.EndTime);
    }
    return maxSum;
  }
}

[TestFixture]
public class PriorityQueueSolutionTests
{
  [Test]
  public void Test1()
  {
    new PriorityQueueSolution().MaxTwoEvents([
      [1, 3, 2],
      [4, 5, 2],
      [2, 4, 3]
    ]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new PriorityQueueSolution().MaxTwoEvents([
      [1, 3, 2],
      [4, 5, 2],
      [1, 5, 5]
    ]).Should().Be(5);
  }

  [Test]
  public void Test3()
  {
    new PriorityQueueSolution().MaxTwoEvents([
      [1, 5, 3],
      [1, 5, 1],
      [6, 6, 5]
    ]).Should().Be(8);
  }

  [Test]
  public void Test4()
  {
    new PriorityQueueSolution()
      .MaxTwoEvents([[66, 97, 90], [98, 98, 68], [38, 49, 63], [91, 100, 42], [92, 100, 22], [1, 77, 50], [64, 72, 97]])
      .Should().Be(165);
  }
}
