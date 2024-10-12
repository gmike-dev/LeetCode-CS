namespace LeetCode.Strings._539._Minimum_Time_Difference;

public class CountingSolution
{
  public int FindMinDifference(IList<string> timePoints)
  {
    const int m = 1440;
    var n = timePoints.Count;
    var time = new BitArray(m);
    var minTime = int.MaxValue;
    for (var i = 0; i < n; i++)
    {
      var t = int.Parse(timePoints[i].AsSpan(..2)) * 60 + int.Parse(timePoints[i].AsSpan(3..));
      if (time[t])
        return 0;
      time[t] = true;
      minTime = Math.Min(minTime, t);
    }
    var minDiff = int.MaxValue;
    var l = minTime;
    for (var r = l + 1; r < m; r++)
    {
      if (!time[r])
        continue;
      minDiff = Math.Min(minDiff, r - l);
      l = r;
    }
    return Math.Min(minDiff, m - l + minTime);
  }
}

[TestFixture]
public class CountingSolutionTests
{
  [Test]
  public void Test1()
  {
    new CountingSolution().FindMinDifference(["23:59", "00:00"]).Should().Be(1);
  }

  [Test]
  public void Test2()
  {
    new CountingSolution().FindMinDifference(["00:00", "23:59", "00:00"]).Should().Be(0);
  }

  [Test]
  public void Test3()
  {
    new CountingSolution().FindMinDifference(["00:00", "04:00", "22:00"]).Should().Be(120);
  }

  [Test]
  public void Test4()
  {
    new CountingSolution().FindMinDifference(["12:12", "00:13"]).Should().Be(719);
  }
}
