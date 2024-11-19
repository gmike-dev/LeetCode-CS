namespace LeetCode.SlidingWindow._2461._Maximum_Sum_of_Distinct_Subarrays_With_Length_K;

public class Solution2
{
  public long MaximumSubarraySum(int[] nums, int k)
  {
    Span<int> s = stackalloc int[100001];
    var sum = 0L;
    var distinct = 0;
    for (var i = 0; i < k - 1; i++)
    {
      if (s[nums[i]]++ == 0)
        distinct++;
      sum += nums[i];
    }
    var maxSum = 0L;
    for (var i = 0; i <= nums.Length - k; i++)
    {
      sum += nums[i + k - 1];
      if (s[nums[i + k - 1]]++ == 0)
        distinct++;
      if (distinct == k)
        maxSum = Math.Max(maxSum, sum);
      sum -= nums[i];
      if (--s[nums[i]] == 0)
        distinct--;
    }
    return maxSum;
  }
}

[TestFixture]
public class Solution2Tests
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
    new Solution2().MaximumSubarraySum(nums, k).Should().Be(expected);
  }
}
