namespace LeetCode.DP._2369._Check_if_There_is_a_Valid_Partition_For_The_Array;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 4, 4, 4, 5, 6 }, true)]
  [TestCase(new[] { 1, 1, 1, 2 }, false)]
  public void Test1(int[] nums, bool expected)
  {
    new SolutionUsingDp().ValidPartition(nums).Should().Be(expected);
    new SolutionUsingMemoization().ValidPartition(nums).Should().Be(expected);
  }
}
