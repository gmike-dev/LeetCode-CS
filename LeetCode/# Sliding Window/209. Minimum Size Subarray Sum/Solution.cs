namespace LeetCode.__Sliding_Window._209._Minimum_Size_Subarray_Sum;

public class Solution
{
  public int MinSubArrayLen(int target, int[] nums)
  {
    var result = int.MaxValue;
    var n = nums.Length;
    var l = 0;
    var s = 0;
    for (var r = 0; r < n; r++)
    {
      s += nums[r];
      while (s >= target)
      {
        result = Math.Min(result, r - l + 1);
        s -= nums[l++];
      }
    }
    return result == int.MaxValue ? 0 : result;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(7, new[] { 2, 3, 1, 2, 4, 3 }, 2)]
  [TestCase(4, new[] { 1, 4, 4 }, 1)]
  [TestCase(11, new[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 0)]
  [TestCase(7, new[] { 2, 3, 1, 2, 4, 3 }, 2)]
  public void Test1(int target, int[] nums, int expected)
  {
    new Solution().MinSubArrayLen(target, nums).Should().Be(expected);
  }
}
