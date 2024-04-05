namespace LeetCode._1846._Maximum_Element_After_Decreasing;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 2, 2, 1, 2, 1 }, 2)]
  [TestCase(new[] { 100, 1, 1000 }, 3)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, 5)]
  public void Test(int[] arr, int expected)
  {
    new Solution().MaximumElementAfterDecrementingAndRearranging(arr).Should().Be(expected);
    new SortSolution().MaximumElementAfterDecrementingAndRearranging(arr).Should().Be(expected);
  }
}
