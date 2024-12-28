namespace LeetCode.DP._689._Maximum_Sum_of_3_Non_Overlapping_Subarrays;

public class Solution
{
  public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
  {
    var n = nums.Length;
    Span<int> prefixSum = stackalloc int[n + 1];
    for (var i = 0; i < n; i++)
      prefixSum[i + 1] = prefixSum[i] + nums[i];
    Span<int> left = stackalloc int[n];
    Span<int> right = stackalloc int[n];
    var maxS = prefixSum[k] - prefixSum[0];
    var maxI = 0;
    for (var i = k; i < n; i++)
    {
      var s = prefixSum[i + 1] - prefixSum[i + 1 - k];
      if (s > maxS)
      {
        maxI = i + 1 - k;
        maxS = s;
      }
      left[i] = maxI;
    }
    right[n - k] = n - k;
    maxS = prefixSum[n] - prefixSum[n - k];
    maxI = n - k;
    for (var i = n - k - 1; i >= 0; i--)
    {
      var s = prefixSum[i + k] - prefixSum[i];
      if (s >= maxS)
      {
        maxI = i;
        maxS = s;
      }
      right[i] = maxI;
    }
    maxS = 0;
    int[] result = [0, 0, 0];
    for (var i = k; i <= n - 2 * k; i++)
    {
      var s1 = prefixSum[i + k] - prefixSum[i];
      var s2 = prefixSum[left[i - 1] + k] - prefixSum[left[i - 1]];
      var s3 = prefixSum[right[i + k] + k] - prefixSum[right[i + k]];
      var s = s1 + s2 + s3;
      if (s > maxS)
      {
        maxS = s;
        (result[0], result[1], result[2]) = (left[i - 1], i, right[i + k]);
      }
    }

    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 2, 1, 2, 6, 7, 5, 1 }, 2, new[] { 0, 3, 5 })]
  [TestCase(new[] { 1, 2, 1, 2, 1, 2, 1, 2, 1 }, 2, new[] { 0, 2, 4 })]
  public void Test(int[] nums, int k, int[] expected)
  {
    new Solution().MaxSumOfThreeSubarrays(nums, k).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
