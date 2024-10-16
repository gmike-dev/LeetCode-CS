namespace LeetCode._1405._Longest_Happy_String;

public class Solution
{
  public string LongestDiverseString(int a, int b, int c)
  {
    var s = new StringBuilder();
    var q = new PriorityQueue<char, int>();
    if (a > 0)
      q.Enqueue('a', -a);
    if (b > 0)
      q.Enqueue('b', -b);
    if (c > 0)
      q.Enqueue('c', -c);
    for (var i = 0; q.Count != 0; i++)
    {
      q.TryDequeue(out var first, out var firstCount);
      if (i == 0 || s[i - 1] != first || i < 2 || s[i - 2] != first)
      {
        s.Append(first);
        if (firstCount + 1 != 0)
          q.Enqueue(first, firstCount + 1);
      }
      else
      {
        if (!q.TryDequeue(out var second, out var secondCount))
          break;
        q.Enqueue(first, firstCount);
        s.Append(second);
        if (secondCount + 1 != 0)
          q.Enqueue(second, secondCount + 1);
      }
    }
    return s.ToString();
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(1, 1, 7, "ccaccbcc")]
  [TestCase(7, 1, 0, "aabaa")]
  public void Test(int a, int b, int c, string expected)
  {
    new Solution().LongestDiverseString(a, b, c).Should().Be(expected);
  }
}
