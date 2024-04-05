namespace LeetCode._1658._Minimum_Operations_to_Reduce_X_to_Zero;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 1, 4, 2, 3, }, 5, 2)]
  [TestCase(new[] { 5, 6, 7, 8, 9 }, 4, -1)]
  [TestCase(new[] { 3, 2, 20, 1, 1, 3 }, 10, 5)]
  [TestCase(new[] { 10, 1, 1, 1, 1, 1 }, 5, 5)]
  [TestCase(new[] { 5, 2, 3, 1, 1 }, 5, 1)]
  [TestCase(new[] { 1 }, 2, -1)]
  [TestCase(new[] { 2 }, 2, 1)]
  [TestCase(new[] { 6016,5483,541,4325,8149,3515,7865,2209,9623,9763,4052,6540,2123,2074,765,7520,4941,5290,5868,6150,6006,6077,2856,7826,9119 }, 31841, 6)]
  public void Test(int[] nums, int x, int expected)
  {
    new Solution().MinOperations(nums, x).Should().Be(expected);
    new BinarySearchSolution().MinOperations(nums, x).Should().Be(expected);
  }
}
