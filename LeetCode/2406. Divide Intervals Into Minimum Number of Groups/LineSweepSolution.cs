namespace LeetCode._2406._Divide_Intervals_Into_Minimum_Number_of_Groups;

public class LineSweepSolution
{
  public int MinGroups(int[][] intervals)
  {
    var count = new int[(int)1e6 + 2];
    foreach (var interval in intervals)
    {
      count[interval[0]]++;
      count[interval[1] + 1]--;
    }
    var maxCount = 0;
    var currentCount = 0;
    foreach (var c in count)
    {
      currentCount += c;
      maxCount = Math.Max(maxCount, currentCount);
    }
    return maxCount;
  }
}

[TestFixture]
public class LineSweepSolutionTests
{
  [Test]
  public void Test1()
  {
    new LineSweepSolution().MinGroups([[5, 10], [6, 8], [1, 5], [2, 3], [1, 10]]).Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new LineSweepSolution().MinGroups([[1, 3], [5, 6], [8, 10], [11, 13]]).Should().Be(1);
  }

  [Test]
  public void Test3()
  {
    new LineSweepSolution().MinGroups([
      [441459, 446342], [801308, 840640], [871890, 963447], [228525, 336985], [807945, 946787], [479815, 507766],
      [693292, 944029], [751962, 821744]
    ]).Should().Be(4);
  }

  [Test]
  public void Test4()
  {
    new LineSweepSolution().MinGroups([[1, 1]]).Should().Be(1);
  }
}
