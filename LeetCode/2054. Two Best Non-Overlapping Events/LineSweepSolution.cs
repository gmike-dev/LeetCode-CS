namespace LeetCode._2054._Two_Best_Non_Overlapping_Events;

public class LineSweepSolution
{
  public int MaxTwoEvents(int[][] events)
  {
    var points = new List<(int x, int type, int value)>(2 * events.Length);
    foreach (var e in events)
    {
      points.Add((e[0], 1, e[2]));
      points.Add((e[1] + 1, 0, e[2]));
    }
    points.Sort();
    var maxValue = 0;
    var maxSum = 0;
    foreach (var p in points)
    {
      if (p.type == 0)
        maxValue = Math.Max(maxValue, p.value);
      else
        maxSum = Math.Max(maxSum, maxValue + p.value);
    }
    return maxSum;
  }
}

[TestFixture]
public class LineSweepSolutionTests
{
  [Test]
  public void Test1()
  {
    new LineSweepSolution().MaxTwoEvents([
      [1, 3, 2],
      [4, 5, 2],
      [2, 4, 3]
    ]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new LineSweepSolution().MaxTwoEvents([
      [1, 3, 2],
      [4, 5, 2],
      [1, 5, 5]
    ]).Should().Be(5);
  }

  [Test]
  public void Test3()
  {
    new LineSweepSolution().MaxTwoEvents([
      [1, 5, 3],
      [1, 5, 1],
      [6, 6, 5]
    ]).Should().Be(8);
  }

  [Test]
  public void Test4()
  {
    new LineSweepSolution()
      .MaxTwoEvents([[66, 97, 90], [98, 98, 68], [38, 49, 63], [91, 100, 42], [92, 100, 22], [1, 77, 50], [64, 72, 97]])
      .Should().Be(165);
  }
}
