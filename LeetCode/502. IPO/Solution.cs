namespace LeetCode._502._IPO;

public class Solution
{
  public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
  {
    var n = profits.Length;
    var projects = Enumerable.Range(0, n).Select(i => (capital: capital[i], profit: profits[i])).Order().ToArray();
    var q = new PriorityQueue<int, int>();
    var j = 0;
    for (var i = 0; i < k; i++)
    {
      while (j < n && projects[j].capital <= w)
      {
        q.Enqueue(projects[j].profit, -projects[j].profit);
        j++;
      }
      if (q.Count == 0)
        break;
      w += q.Dequeue();
    }
    return w;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(2, 0, new[] { 1, 2, 3 }, new[] { 0, 1, 1 }, 4)]
  [TestCase(3, 0, new[] { 1, 2, 3 }, new[] { 0, 1, 2 }, 6)]
  public void Test(int k, int w, int[] profits, int[] capital, int expected)
  {
    new Solution().FindMaximizedCapital(k, w, profits, capital).Should().Be(expected);
  }
}
