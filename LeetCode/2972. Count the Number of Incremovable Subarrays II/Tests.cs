namespace LeetCode._2972._Count_the_Number_of_Incremovable_Subarrays_II;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 3, 4 }, 10)]
  [TestCase(new[] { 6, 5, 7, 8 }, 7)]
  [TestCase(new[] { 8, 7, 6, 6 }, 3)]
  public void Test(int[] a, int expected)
  {
    new Solution().IncremovableSubarrayCount(a).Should().Be(expected);
  }
}
