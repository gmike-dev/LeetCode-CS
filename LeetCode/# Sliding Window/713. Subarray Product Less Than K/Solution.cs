namespace LeetCode.__Sliding_Window._713._Subarray_Product_Less_Than_K;

public class Solution
{
  public int NumSubarrayProductLessThanK(int[] nums, int k)
  {
    if (k <= 1)
      return 0;

    var n = nums.Length;
    var ans = 0;
    for (int i = 0, j = 0, p = nums[0]; i < n; i++)
    {
      while (j < n && p < k)
      {
        ans += j - i + 1;
        j++;
        if (j < n)
          p *= nums[j];
      }
      p /= nums[i];
    }
    return ans;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 10, 5, 2, 6 }, 100, 8)]
  [TestCase(new[] { 1, 2, 3 }, 0, 0)]
  [TestCase(new[] { 2, 2, 3, 1 }, 2, 1)]
  [TestCase(new[] { 2, 2, 3, 1, 1 }, 2, 3)]
  [TestCase(new[] { 2, 2, 3, 1, 2, 1 }, 2, 2)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 0)]
  public void Test(int[] nums, int k, int expected)
  {
    new Solution().NumSubarrayProductLessThanK(nums, k).Should().Be(expected);
  }
}
