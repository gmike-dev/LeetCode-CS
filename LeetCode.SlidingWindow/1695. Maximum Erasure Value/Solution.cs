namespace LeetCode.SlidingWindow._1695._Maximum_Erasure_Value;

public class Solution
{
  public int MaximumUniqueSubarray(int[] nums)
  {
    Span<int> index = stackalloc int[10001];
    var score = 0;
    var maxScore = 0;
    var left = 0;
    var right = 0;
    while (right < nums.Length)
    {
      var num = nums[right];
      while (left < index[num])
      {
        score -= nums[left];
        index[nums[left]] = 0;
        left++;
      }
      score += num;
      index[num] = right + 1;
      maxScore = Math.Max(maxScore, score);
      right++;
    }
    return maxScore;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 4, 2, 4, 5, 6 }, 17)]
  [TestCase(new[] { 5, 2, 1, 2, 5, 2, 1, 2, 5 }, 8)]
  public void Test(int[] nums, int expected)
  {
    new Solution().MaximumUniqueSubarray(nums).Should().Be(expected);
  }
}
