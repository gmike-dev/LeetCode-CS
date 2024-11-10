namespace LeetCode._3350._Adjacent_Increasing_Subarrays_Detection_II;

public class Solution
{
  public int MaxIncreasingSubarrays(IList<int> nums)
  {
    int n = nums.Count, size = 1, prevSize = 0, result = 1;
    for (var i = 1; i < n; i++)
    {
      if (nums[i] > nums[i - 1])
      {
        size++;
      }
      else
      {
        prevSize = size;
        size = 1;
      }
      result = Math.Max(result, Math.Max(size / 2, Math.Min(size, prevSize)));
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 2, 5, 7, 8, 9, 2, 3, 4, 3, 1 }, 3)]
  [TestCase(new[] { 1, 2, 3, 4, 4, 4, 4, 5, 6, 7 }, 2)]
  [TestCase(new[] { -15, 19 }, 1)]
  public void Test(IList<int> nums, int expected)
  {
    new Solution().MaxIncreasingSubarrays(nums).Should().Be(expected);
  }
}
