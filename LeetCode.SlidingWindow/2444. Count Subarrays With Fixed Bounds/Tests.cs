namespace LeetCode.SlidingWindow._2444._Count_Subarrays_With_Fixed_Bounds;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 3, 5, 2, 7, 5 }, 1, 5, 2)]
  [TestCase(new[] { 1, 1, 1, 1 }, 1, 1, 10)]
  [TestCase(
    new[]
    {
      35054, 398719, 945315, 945315, 820417, 945315, 35054, 945315, 171832, 945315, 35054, 109750, 790964, 441974,
      552913
    }, 35054, 945315, 81)]
  [TestCase(new[] { 1, 4, 9, 9, 8, 9, 1, 9, 3, 9, 1, 2, 7, 5, 6 }, 1, 9, 81)]
  public void Test(int[] nums, int minK, int maxK, long expected)
  {
    new MySolution().CountSubarrays(nums, minK, maxK).Should().Be(expected);
    new Solution().CountSubarrays(nums, minK, maxK).Should().Be(expected);
  }
}
