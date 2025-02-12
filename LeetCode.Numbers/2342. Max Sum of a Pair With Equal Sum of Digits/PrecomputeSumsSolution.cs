namespace LeetCode.Numbers._2342._Max_Sum_of_a_Pair_With_Equal_Sum_of_Digits;

public class PrecomputeSumsSolution
{
  public int MaximumSum(int[] nums)
  {
    Span<int> sums = stackalloc int[1001];
    PrecomputeDigitSums(sums);
    var result = -1;
    Span<int> maxNumWithSum = stackalloc int[100];
    foreach (var x in nums)
    {
      var s = sums[x % 1000] + sums[x / 1000 % 1000] + sums[x / 1000000];
      if (maxNumWithSum[s] != 0)
        result = Math.Max(result, x + maxNumWithSum[s]);
      if (x >= maxNumWithSum[s])
        maxNumWithSum[s] = x;
    }
    return result;
  }

  private static void PrecomputeDigitSums(Span<int> sums)
  {
    for (var i = 0; i < 1000; i++)
      sums[i] = i % 10 + i / 10 % 10 + i / 100;
  }
}

[TestFixture]
public class PrecomputeSumsSolutionTests
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
    new PrecomputeSumsSolution().MaximumSum(nums).Should().Be(expected);
  }
}
