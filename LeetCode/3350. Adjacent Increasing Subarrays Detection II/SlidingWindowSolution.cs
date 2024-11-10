namespace LeetCode._3350._Adjacent_Increasing_Subarrays_Detection_II;

public class SlidingWindowSolution
{
  public int MaxIncreasingSubarrays(IList<int> nums)
  {
    var n = nums.Count;
    int left = 0, right = 1, k = 1;
    for (var i = 1; i < n - 1; i++)
    {
      if (right < i)
      {
        for (right = i; right < n - 1; right++)
        {
          if (nums[right] >= nums[right + 1])
            break;
        }
      }
      k = Math.Max(k, Math.Min(i - left, right - i + 1));
      if (nums[i] <= nums[i - 1])
        left = i;
    }
    return k;
  }
}

[TestFixture]
public class SlidingWindowSolutionTests
{
  [TestCase(new[] { 2, 5, 7, 8, 9, 2, 3, 4, 3, 1 }, 3)]
  [TestCase(new[] { 1, 2, 3, 4, 4, 4, 4, 5, 6, 7 }, 2)]
  [TestCase(new[] { -15, 19 }, 1)]
  public void Test(IList<int> nums, int expected)
  {
    new SlidingWindowSolution().MaxIncreasingSubarrays(nums).Should().Be(expected);
  }
}
