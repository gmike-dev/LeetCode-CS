namespace LeetCode.__DP._560._Subarray_Sum_Equals_K;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 1, 1 }, 2, 2)]
  [TestCase(new[] { 1, 2, 3 }, 3, 2)]
  public void Test(int[] nums, int k, int expected)
  {
    new Bruteforce().SubarraySum(nums, k).Should().Be(expected);
    new BruteforceEnhanced().SubarraySum(nums, k).Should().Be(expected);
    new LinearSolution().SubarraySum(nums, k).Should().Be(expected);
  }
}
