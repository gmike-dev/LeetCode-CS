namespace LeetCode.SlidingWindow._2100._Find_Good_Days_to_Rob_the_Bank;

public class Solution
{
  public IList<int> GoodDaysToRobBank(int[] security, int time)
  {
    var n = security.Length;
    if (n < 2 * time + 1)
      return Array.Empty<int>();
    var left = 0;
    var right = 0;
    var days = new List<int>();
    for (var i = 0; i < n; i++)
    {
      if (i > 0 && security[i - 1] < security[i])
        left = i;
      right = Math.Max(right, i);
      while (right + 1 < n && security[right] <= security[right + 1])
        right++;
      if (i - left >= time && right - i >= time)
        days.Add(i);
    }
    return days;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 5, 3, 3, 3, 5, 6, 2 }, 2, new[] { 2, 3 })]
  [TestCase(new[] { 1, 1, 1, 1, 1 }, 0, new[] { 0, 1, 2, 3, 4 })]
  [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, 2, new int[0])]
  [TestCase(new[] { 1, 2, 5, 4, 1, 0, 2, 4, 5, 3, 1, 2, 4, 3, 2, 4, 8 }, 2, new[] { 5, 10, 14 })]
  public void Test(int[] security, int time, int[] expected)
  {
    new Solution().GoodDaysToRobBank(security, time).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
