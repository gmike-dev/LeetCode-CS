namespace LeetCode._1793._Maximum_Score_of_a_Good_Subarray;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 4, 3, 7, 4, 5 }, 3, 15)]
  [TestCase(new[] { 5, 5, 4, 5, 4, 1, 1, 1 }, 0, 20)]
  [TestCase(new[] { 5, 5, 4, 5, 4, 1, 1, 1 }, 7, 8)]
  [TestCase(new[] { 5, 5, 4, 5, 4, 1, 1, 1 }, 5, 8)]
  [TestCase(new[] { 5, 5, 4, 5, 4, 1, 1, 1 }, 4, 20)]
  public void Test(int[] nums, int k, int expected)
  {
    new Solution().MaximumScore(nums, k).Should().Be(expected);
  }
}
