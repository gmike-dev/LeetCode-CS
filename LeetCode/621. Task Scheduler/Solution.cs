namespace LeetCode._621._Task_Scheduler;

public class Solution
{
  public int LeastInterval(char[] tasks, int n)
  {
    Span<int> count = stackalloc int['Z' - 'A' + 1];
    foreach (var t in tasks)
      count[t - 'A']++;
    var max = 0;
    var maxFreq = 0;
    foreach (var c in count)
    {
      if (c == max)
      {
        maxFreq++;
      }
      else if (c > max)
      {
        max = c;
        maxFreq = 1;
      }
    }
    return Math.Max(tasks.Length, (max - 1) * (n + 1) + maxFreq);
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 2, 8)]
  [TestCase(new[] { 'A', 'C', 'A', 'B', 'D', 'B' }, 1, 6)]
  [TestCase(new[] { 'A' }, 10, 1)]
  [TestCase(new[] { 'A', 'A' }, 10, 12)]
  [TestCase(new[] { 'A', 'A' }, 0, 2)]
  [TestCase(new[] { 'A', 'B' }, 10, 2)]
  [TestCase(new[] { 'A', 'B' }, 0, 2)]
  public void Test(char[] tasks, int n, int expected)
  {
    new Solution().LeastInterval(tasks, n).Should().Be(expected);
  }
}
