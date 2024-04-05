namespace LeetCode.__Sliding_Window._1425._Constrained_Subsequence_Sum;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 10, 2, -10, 5, 20 }, 2, 37)]
  [TestCase(new[] { -1, -2, -3 }, 1, -1)]
  [TestCase(new[] { 10, -2, -10, -5, 20 }, 2, 23)]
  public void Test(int[] nums, int k, int expected)
  {
    new SortedSetSolution().ConstrainedSubsetSum(nums, k).Should().Be(expected);
    new QueueSolution().ConstrainedSubsetSum(nums, k).Should().Be(expected);
    new DequeSolution().ConstrainedSubsetSum(nums, k).Should().Be(expected);
    new LinkedListSolution().ConstrainedSubsetSum(nums, k).Should().Be(expected);
  }
}
