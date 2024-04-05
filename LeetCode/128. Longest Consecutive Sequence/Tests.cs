namespace LeetCode._128._Longest_Consecutive_Sequence;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 100, 4, 200, 1, 3, 2 }, 4)]
  [TestCase(new[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9)]
  [TestCase(new[] { 0 }, 1)]
  [TestCase(new[] { 1, 1 }, 1)]
  [TestCase(new[] { 0, 0, 1, 1 }, 2)]
  public void Test(int[] nums, int expected)
  {
    new Solution().LongestConsecutive(nums).Should().Be(expected);
    new ShortSolution().LongestConsecutive(nums).Should().Be(expected);
  }
}
