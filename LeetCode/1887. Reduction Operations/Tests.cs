namespace LeetCode._1887._Reduction_Operations;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 5, 1, 3 }, 3)]
  [TestCase(new[] { 1, 1, 1 }, 0)]
  [TestCase(new[] { 1, 1, 2, 2, 3 }, 4)]
  public void Test(int[] nums, int expected)
  {
    new Solution().ReductionOperations(nums).Should().Be(expected);
  }
}
