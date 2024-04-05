namespace LeetCode._2009._Minimum_Number_of_Operations;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 4, 2, 5, 3 }, 0)]
  [TestCase(new[] { 1, 2, 3, 5, 6 }, 1)]
  [TestCase(new[] { 1, 10, 100, 1000 }, 3)]
  [TestCase(new[] { 1, 1, 1, 1, 1, 1 }, 5)]
  [TestCase(new[] { 1 }, 0)]
  [TestCase(new[] { 1, 1000000000 }, 1)]
  public void Test(int[] nums, int expected)
  {
    new Solution().MinOperations(nums).Should().Be(expected);
  }
}
