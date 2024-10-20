namespace LeetCode.DP._1751._Maximum_Number_of_Events_That_Can_Be_Attended_II;

public class RecursiveSolution
{
  public int MaxValue(int[][] events, int k)
  {
    Array.Sort(events, (x, y) => x[1].CompareTo(y[1]));
    var n = events.Length;
    var cache = new Dictionary<(int, int), int>();
    var prev = new int[n];
    prev[0] = -1;
    for (var i = 1; i < n; i++)
    {
      prev[i] = UpperBound(events, i, events[i][0] - 1) - 1;
    }

    return F(k, n - 1);

    int F(int m, int i)
    {
      if (i < 0 || m == 0)
      {
        return 0;
      }

      var key = (m, i);
      if (cache.TryGetValue(key, out var result))
      {
        return result;
      }

      result = Math.Max(F(m - 1, prev[i]) + events[i][2], F(m, i - 1));
      cache[key] = result;
      return result;
    }
  }

  private static int UpperBound(int[][] events, int n, int start)
  {
    var l = 0;
    var r = n - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (events[m][1] <= start)
        l = m + 1;
      else
        r = m;
    }
    return events[l][1] <= start ? n : l;
  }
}

[TestFixture]
public class RecursiveSolutionTests
{
  [Test]
  public void Test1()
  {
    new RecursiveSolution().MaxValue(new[]
    {
      new[] { 1, 2, 4 }, new[] { 3, 4, 3 }, new[] { 2, 3, 1 }
    }, 2).Should().Be(7);
  }

  [Test]
  public void Test2()
  {
    new RecursiveSolution().MaxValue(new[]
    {
      new[] { 1, 2, 4 }, new[] { 3, 4, 3 }, new[] { 2, 3, 10 }
    }, 2).Should().Be(10);
  }

  [Test]
  public void Test3()
  {
    new RecursiveSolution().MaxValue(new[]
    {
      new[] { 1, 1, 1 }, new[] { 2, 2, 2 }, new[] { 3, 3, 3 }, new[] { 4, 4, 4 }
    }, 3).Should().Be(9);
  }
}
