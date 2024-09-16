namespace LeetCode.__Strings._539._Minimum_Time_Difference;

public class Solution
{
  public int FindMinDifference(IList<string> timePoints)
  {
    var n = timePoints.Count;
    var time = new int[n];
    for (var i = 0; i < n; i++)
      time[i] = int.Parse(timePoints[i][..2]) * 60 + int.Parse(timePoints[i][3..]);
    Array.Sort(time);
    var minTime = TimeDiff(time[0], time[^1]);
    for (var i = 1; i < time.Length; i++)
      minTime = Math.Min(minTime, TimeDiff(time[i - 1], time[i]));
    return minTime;
  }

  private static int TimeDiff(int t1, int t2)
  {
    var d = Math.Abs(t1 - t2);
    return Math.Min(d, 1440 - d);
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().FindMinDifference(["23:59", "00:00"]).Should().Be(1);
  }

  [Test]
  public void Test2()
  {
    new Solution().FindMinDifference(["00:00", "23:59", "00:00"]).Should().Be(0);
  }

  [Test]
  public void Test3()
  {
    new Solution().FindMinDifference(["00:00", "04:00", "22:00"]).Should().Be(120);
  }
}
