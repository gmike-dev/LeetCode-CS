namespace LeetCode.SlidingWindow._2461._Maximum_Sum_of_Distinct_Subarrays_With_Length_K;

public class Solution
{
  public long MaximumSubarraySum(int[] nums, int k)
  {
    var s = new Dictionary<int, int>();
    var sum = 0L;
    for (var i = 0; i < k - 1; i++)
    {
      s[nums[i]] = s.GetValueOrDefault(nums[i]) + 1;
      sum += nums[i];
    }
    var maxSum = 0L;
    for (var i = 0; i <= nums.Length - k; i++)
    {
      sum += nums[i + k - 1];
      s[nums[i + k - 1]] = s.GetValueOrDefault(nums[i + k - 1]) + 1;
      if (s.Count == k)
        maxSum = Math.Max(maxSum, sum);
      sum -= nums[i];
      if (--s[nums[i]] == 0)
        s.Remove(nums[i]);
    }
    return maxSum;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 5, 4, 2, 9, 9, 9 }, 3, 15)]
  [TestCase(new[] { 4, 4, 4 }, 3, 0)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 5)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, 9)]
  [TestCase(new[] { 1, 2, 1, 2, 1 }, 2, 3)]
  [TestCase(new[] { 1, 2, 1, 2, 1 }, 3, 0)]
  [TestCase(new[] { 2 }, 1, 2)]
  [TestCase(new[] { 9, 9, 9, 1, 2, 3 }, 3, 12)]
  public void Test(int[] nums, int k, long expected)
  {
    new Solution().MaximumSubarraySum(nums, k).Should().Be(expected);
  }
}
