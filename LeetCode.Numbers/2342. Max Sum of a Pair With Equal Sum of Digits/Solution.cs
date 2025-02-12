namespace LeetCode.Numbers._2342._Max_Sum_of_a_Pair_With_Equal_Sum_of_Digits;

public class Solution
{
  public int MaximumSum(int[] nums)
  {
    Span<int> firstMax = stackalloc int[100];
    Span<int> secondMax = stackalloc int[100];
    foreach (var x in nums)
    {
      var s = 0;
      var n = x;
      while (n != 0)
      {
        s += n % 10;
        n /= 10;
      }
      if (x >= firstMax[s])
      {
        secondMax[s] = firstMax[s];
        firstMax[s] = x;
      }
      else if (x > secondMax[s])
      {
        secondMax[s] = x;
      }
    }
    var maxSum = -1;
    for (var s = 1; s < 100; s++)
    {
      if (secondMax[s] != 0)
        maxSum = Math.Max(maxSum, firstMax[s] + secondMax[s]);
    }
    return maxSum;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 18, 43, 36, 13, 7 }, 54)]
  [TestCase(new[] { 10, 12, 19, 14 }, -1)]
  [TestCase(new[]
  {
    229, 398, 269, 317, 420, 464, 491, 218, 439, 153,
    482, 169, 411, 93, 147, 50, 347, 210, 251, 366, 401
  }, 973)]
  public void Test(int[] nums, int expected)
  {
    new Solution().MaximumSum(nums).Should().Be(expected);
  }
}
