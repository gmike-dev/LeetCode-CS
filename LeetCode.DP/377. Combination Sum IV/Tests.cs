namespace LeetCode.DP._377._Combination_Sum_IV;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 3 }, 4, 7)]
  [TestCase(new[] { 9 }, 3, 0)]
  [TestCase(new[] { 2 }, 8, 1)]
  [TestCase(new[] { 2 }, 2, 1)]
  public void Test(int[] nums, int target, int expected)
  {
    new Solution().CombinationSum4(nums, target).Should().Be(expected);
  }
}
