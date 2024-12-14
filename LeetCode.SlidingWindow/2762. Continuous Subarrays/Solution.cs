namespace LeetCode.SlidingWindow._2762._Continuous_Subarrays;

public class Solution
{
  public long ContinuousSubarrays(int[] nums)
  {
    var s = new SortedSet<(int value, int pos)>();
    long count = nums.Length;
    for (int l = 0, r = 0; r < nums.Length; r++)
    {
      s.Add((nums[r], r));
      while (s.Max.value - s.Min.value > 2)
      {
        s.Remove((nums[l], l));
        l++;
      }
      count += r - l;
    }
    return count;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 5, 4, 2, 4 }, 8)]
  [TestCase(new[] { 1, 2, 3 }, 6)]
  public void Test(int[] nums, long expected)
  {
    new Solution().ContinuousSubarrays(nums).Should().Be(expected);
  }
}
