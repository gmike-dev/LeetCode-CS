namespace LeetCode._1685._Sum_of_Absolute_Differences_in_a_Sorted_Array;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 2, 3, 5 }, new[] { 4, 3, 5 })]
  [TestCase(new[] { 1, 4, 6, 8, 10 }, new[] { 24, 15, 13, 15, 21 })]
  [TestCase(new[] { 1, 20 }, new[] { 19, 19 })]
  public void Test(int[] nums, int[] expected)
  {
    new Solution().GetSumAbsoluteDifferences(nums).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
