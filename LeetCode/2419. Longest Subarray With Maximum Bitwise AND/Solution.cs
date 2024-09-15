namespace LeetCode._2419._Longest_Subarray_With_Maximum_Bitwise_AND;

public class Solution
{
  public int LongestSubarray(int[] nums)
  {
    var max = nums.Max();
    var curLength = 0;
    var maxLength = 0;
    foreach (var num in nums)
    {
      if (num == max)
      {
        curLength++;
      }
      else
      {
        if (curLength > maxLength)
          maxLength = curLength;
        curLength = 0;
      }
    }
    if (curLength > maxLength)
      maxLength = curLength;
    return maxLength;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 2, 3, 3, 2, 2 }, 2)]
  [TestCase(new[] { 1, 2, 3, 4 }, 1)]
  [TestCase(new[] { 378034, 378034, 378034 }, 3)]
  [TestCase(new[] { 311155, 311155, 311155, 311155, 311155, 311155, 311155, 311155, 201191, 311155 }, 8)]
  public void Test(int[] nums, int expected)
  {
    new Solution().LongestSubarray(nums).Should().Be(expected);
  }
}
