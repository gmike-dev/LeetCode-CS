namespace LeetCode.Numbers._3097._Shortest_Subarray_With_OR_at_Least_K_II;

public class Solution
{
  public int MinimumSubarrayLength(int[] nums, int k)
  {
    var cnt = new int[32];
    var minLength = int.MaxValue;
    for (int l = 0, r = 0; r < nums.Length; r++)
    {
      AddValue(nums[r]);
      for (; l <= r && GetValue() >= k; l++)
      {
        minLength = Math.Min(minLength, r - l + 1);
        RemoveValue(nums[l]);
      }
    }
    return minLength == int.MaxValue ? -1 : minLength;

    int GetValue()
    {
      var result = 0;
      for (int mask = 1, bit = 0; bit < 32; mask <<= 1, bit++)
      {
        if (cnt[bit] != 0)
          result |= mask;
      }
      return result;
    }

    void AddValue(int n)
    {
      for (var bit = 0; n != 0; n >>= 1)
        cnt[bit++] += n & 1;
    }

    void RemoveValue(int n)
    {
      for (var bit = 0; n != 0; n >>= 1)
        cnt[bit++] -= n & 1;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 2, 3 }, 2, 1)]
  [TestCase(new[] { 2, 1, 8 }, 10, 3)]
  [TestCase(new[] { 1, 2 }, 0, 1)]
  public void Test(int[] nums, int k, int expected)
  {
    new Solution().MinimumSubarrayLength(nums, k).Should().Be(expected);
  }
}
