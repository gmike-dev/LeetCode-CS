namespace LeetCode._2406._Divide_Intervals_Into_Minimum_Number_of_Groups;

public class PriorityQueueSolution
{
  public int MinGroups(int[][] intervals)
  {
    intervals.AsSpan().Sort((x, y) => x[0] - y[0]);
    var groups = new PriorityQueue<int, int>();
    foreach (var interval in intervals)
    {
      if (groups.TryPeek(out _, out var right) && right < interval[0])
        groups.Enqueue(groups.Dequeue(), interval[1]);
      else
        groups.Enqueue(groups.Count, interval[1]);
    }
    return groups.Count;
  }
}

[TestFixture]
public class PriorityQueueSolutionTests
{
  [Test]
  public void Test1()
  {
    new PriorityQueueSolution().MinGroups([[5, 10], [6, 8], [1, 5], [2, 3], [1, 10]]).Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new PriorityQueueSolution().MinGroups([[1, 3], [5, 6], [8, 10], [11, 13]]).Should().Be(1);
  }

  [Test]
  public void Test3()
  {
    new PriorityQueueSolution().MinGroups([
      [441459, 446342], [801308, 840640], [871890, 963447], [228525, 336985], [807945, 946787], [479815, 507766],
      [693292, 944029], [751962, 821744]
    ]).Should().Be(4);
  }
}
