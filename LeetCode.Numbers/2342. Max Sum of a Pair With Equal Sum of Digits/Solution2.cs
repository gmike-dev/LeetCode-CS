namespace LeetCode.Numbers._2342._Max_Sum_of_a_Pair_With_Equal_Sum_of_Digits;

public class Solution2
{
  public int MaximumSum(int[] nums)
  {
    var result = -1;
    Span<int> maxNumWithSum = stackalloc int[100];
    foreach (var x in nums)
    {
      var s = 0;
      var n = x;
      while (n != 0)
      {
        s += n % 10;
        n /= 10;
      }
      if (maxNumWithSum[s] != 0)
        result = Math.Max(result, x + maxNumWithSum[s]);
      if (x >= maxNumWithSum[s])
        maxNumWithSum[s] = x;
    }
    return result;
  }
}

[TestFixture]
public class Solution2Tests
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
    new Solution2().MaximumSum(nums).Should().Be(expected);
  }
}
