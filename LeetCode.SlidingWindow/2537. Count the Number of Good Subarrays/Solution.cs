namespace LeetCode.SlidingWindow._2537._Count_the_Number_of_Good_Subarrays;

public class Solution
{
  public long CountGood(int[] nums, int k)
  {
    var numCount = new Dictionary<int, int>();
    long result = 0;
    var pairs = 0;
    var left = 0;
    foreach (var num in nums)
    {
      numCount.TryGetValue(num, out var count);
      pairs += count;
      numCount[num] = count + 1;
      while (pairs >= k)
      {
        pairs -= --numCount[nums[left]];
        left++;
      }
      result += left;
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 1, 1, 1, 1 }, 10, 1)]
  [TestCase(new[] { 3, 1, 4, 3, 2, 2, 4 }, 2, 4)]
  public void Test(int[] nums, int k, long expected)
  {
    new Solution().CountGood(nums, k).Should().Be(expected);
  }
}
