namespace LeetCode.DP._1014._Best_Sightseeing_Pair;

/// <summary>
/// https://leetcode.com/problems/best-sightseeing-pair/
/// </summary>
public class Solution
{
  public int MaxScoreSightseeingPair(int[] values)
  {
    var maxScore = 0;
    var max = values[0];
    for (var i = 1; i < values.Length; i++)
    {
      max--;
      maxScore = Math.Max(maxScore, max + values[i]);
      max = Math.Max(max, values[i]);
    }
    return maxScore;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 8, 1, 5, 2, 6 }, 11)]
  [TestCase(new[] { 1, 2 }, 2)]
  public void Test(int[] values, int expected)
  {
    new Solution().MaxScoreSightseeingPair(values).Should().Be(expected);
  }
}
