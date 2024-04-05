namespace LeetCode._2616._Minimize_the_Maximum_Difference_of_Pairs;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 10, 1, 2, 7, 1, 3 }, 2, 1)]
  [TestCase(new[] { 4, 2, 1, 2 }, 1, 0)]
  [TestCase(new[] { 3, 11, 4, 3, 5, 7, 4, 4, 5, 5 }, 3, 0)]
  [TestCase(new[] { 3, 0, 5, 0, 0, 1, 6 }, 3, 1)]
  public void Test1(int[] nums, int p, int expected)
  {
    new Solution().MinimizeMax(nums, p).Should().Be(expected);
  }
}
