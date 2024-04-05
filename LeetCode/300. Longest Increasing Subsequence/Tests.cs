namespace LeetCode.LongestIncreasingSubsequence;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
  [TestCase(new[] { 1, 3, 5, 4, 7 }, 4)]
  [TestCase(new[] { 2, 2, 2, 2, 2 }, 1)]
  [TestCase(new[] { 1, 2, 4, 3, 5, 4, 7, 2 }, 5)]
  [TestCase(new[] { 4 }, 1)]
  [TestCase(new[] { 4, 5 }, 2)]
  [TestCase(new[] { -4, 5 }, 2)]
  [TestCase(new[] { -10000, 0, 10000 }, 3)]
  public void Test1(int[] nums, int expected)
  {
    new DpSolution().LengthOfLIS(nums).Should().Be(expected);
    new BinarySearchSolution().LengthOfLIS(nums).Should().Be(expected);
    new BitSolution().LengthOfLIS(nums).Should().Be(expected);
  }
}
