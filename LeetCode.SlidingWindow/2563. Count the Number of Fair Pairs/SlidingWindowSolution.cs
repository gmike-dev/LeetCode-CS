namespace LeetCode.SlidingWindow._2563._Count_the_Number_of_Fair_Pairs;

public class SlidingWindowSolution
{
  public long CountFairPairs(int[] nums, int lower, int upper)
  {
    nums.AsSpan().Sort();
    var count = 0L;
    var n = nums.Length;
    var l = n - 1;
    var r = n - 1;
    for (var i = 0; i < r; i++)
    {
      var low = lower - nums[i];
      var up = upper - nums[i];
      l = Math.Max(i + 1, l);
      while (l > i && nums[l] >= low)
        l--;
      while (r > i && nums[r] > up)
        r--;
      count += r - l;
    }
    return count;
  }
}

[TestFixture]
public class SlidingWindowSolutionTests
{
  [TestCase(new[] { 0, 1, 7, 4, 4, 5 }, 3, 6, 6)]
  [TestCase(new[] { 1, 7, 9, 2, 5 }, 11, 11, 1)]
  [TestCase(new[] { 0, 0, 0, 0, 0, 0 }, 0, 0, 15)]
  public void Test(int[] nums, int lower, int upper, long expected)
  {
    new SlidingWindowSolution().CountFairPairs(nums, lower, upper).Should().Be(expected);
  }
}
