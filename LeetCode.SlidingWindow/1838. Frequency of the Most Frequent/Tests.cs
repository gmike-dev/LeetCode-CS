namespace LeetCode.SlidingWindow._1838._Frequency_of_the_Most_Frequent;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 4 }, 5, 3)]
  [TestCase(new[] { 1, 4, 8, 13 }, 5, 2)]
  [TestCase(new[] { 3, 9, 6 }, 2, 1)]
  [TestCase(new[] { 100 }, 20, 1)]
  public void Test(int[] nums, int k, int expected)
  {
    new Solution().MaxFrequency(nums, k).Should().Be(expected);
    new CountingSortSolution().MaxFrequency(nums, k).Should().Be(expected);
  }
}
