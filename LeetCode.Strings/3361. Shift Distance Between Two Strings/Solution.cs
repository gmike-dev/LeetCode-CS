namespace LeetCode.Strings._3361._Shift_Distance_Between_Two_Strings;

public class Solution
{
  public long ShiftDistance(string s, string t, int[] nextCost, int[] previousCost)
  {
    var result = 0L;
    for (var i = 0; i < s.Length; i++)
    {
      var cost1 = 0L;
      for (int c1 = s[i] - 'a', c2 = t[i] - 'a'; c1 != c2; c1 = (c1 + 1) % 26)
        cost1 += nextCost[c1];
      var cost2 = 0L;
      for (int c1 = s[i] - 'a', c2 = t[i] - 'a'; c1 != c2; c1 = (25 + c1) % 26)
        cost2 += previousCost[c1];
      result += Math.Min(cost1, cost2);
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("abab", "baba", new[] { 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new[] { 1, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 2)]
  [TestCase("leet", "code", new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 31)]
  public void Test(string s, string t, int[] nextCost, int[] previousCost, int expected)
  {
    new Solution().ShiftDistance(s, t, nextCost, previousCost).Should().Be(expected);
  }
}
